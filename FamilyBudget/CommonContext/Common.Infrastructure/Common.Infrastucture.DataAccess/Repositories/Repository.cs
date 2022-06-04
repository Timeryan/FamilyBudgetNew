using System.Linq.Expressions;
using System.Reflection;
using Common.Domain;
using Common.Domain.Domain;
using Common.Infrastucture.DataAccess.Exception;
using Microsoft.EntityFrameworkCore;

namespace Common.DataAccess.Repositories;

/// <summary>
/// Обобщенный репозиторий для работы с сущностями.
/// </summary>
/// <typeparam name="TEntity">Тип сущности.</typeparam>
public class Repository<TEntity> : IRepository<TEntity> where TEntity : Entity
{
    /// <summary>
    /// Контекст подключения к базе.
    /// </summary>
    private DbContext DbContext { get; }

    /// <summary>
    /// Хранилище сущностей типа <typeparamref name="TEntity"/>.
    /// </summary>
    private DbSet<TEntity> DbSet { get; }

    /// <summary>
    /// Инициализирует репозиторий.
    /// </summary>
    /// <param name="context">Контекст.</param>
    public Repository(DbContext context)
    {
        DbContext = context;
        DbSet = DbContext.Set<TEntity>();
    }

    /// <inheritdoc />
    public TEntity Find(object id)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return DbSet.Find(id);
    }

    /// <inheritdoc />
    public async Task<TEntity> FindAsync(object id, CancellationToken cancellation = default)
    {
        if (id == null)
            throw new ArgumentNullException(nameof(id));

        return await DbSet.FindAsync(new[] { id }, cancellation);
    }

    /// <inheritdoc />
    public IQueryable<TEntity> Query()
    {
        return DbSet;
    }

    /// <inheritdoc />
    public IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null)
        {
            throw new ArgumentException(null, nameof(predicate));
        }

        return DbSet.Where(predicate);
    }

    /// <inheritdoc />
    public Task<IReadOnlyCollection<TProjection>> QueryAsync<TProjection>(
        Func<IQueryable<TEntity>, Task<IReadOnlyCollection<TProjection>>> selector,
        CancellationToken cancellation = new CancellationToken())
    {
        if (selector == null)
            throw new ArgumentNullException(nameof(selector));

        return selector(DbSet);
    }

    /// <inheritdoc />
    public int Count(Expression<Func<TEntity, bool>> predicate)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return DbSet.Count(predicate);
    }

    /// <inheritdoc />
    public async Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate,
        CancellationToken cancellation = default)
    {
        if (predicate == null)
            throw new ArgumentNullException(nameof(predicate));

        return await DbSet.CountAsync(predicate, cancellation);
    }

    /// <inheritdoc />
    public bool Exists(object key)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var parameter = Expression.Parameter(typeof(TEntity), "arg");
        var predicate = Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                Expression.Constant(key, key.GetType()),
                Expression.Property(parameter, GetPrimaryKeyProperty())), parameter);

        return DbSet.Any(predicate);
    }

    /// <inheritdoc />
    public async Task<bool> ExistsAsync(object key, CancellationToken cancellation = default)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var parameter = Expression.Parameter(typeof(TEntity), "arg");
        var predicate = Expression.Lambda<Func<TEntity, bool>>(
            Expression.Equal(
                Expression.Constant(key, key.GetType()),
                Expression.Property(parameter, GetPrimaryKeyProperty())), parameter);

        return await DbSet.AnyAsync(predicate, cancellation);
    }

    /// <inheritdoc />
    public bool Exists(Expression<Func<TEntity, bool>> predicate)
    {
        return DbSet.Any(predicate);
    }

    /// <inheritdoc />
    public Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default)
    {
        return DbSet.AnyAsync(predicate, cancellation);
    }

    /// <inheritdoc />
    public void SaveChanges()
    {
        DbContext.SaveChanges();
    }

    /// <inheritdoc />
    public async Task SaveChangesAsync(CancellationToken cancellation = default)
    {
        await DbContext.SaveChangesAsync(cancellation);
    }

    /// <inheritdoc />
    public void Add(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.ModifyDate = DateTime.UtcNow;
        DbContext.Add(entity);
        SaveChanges();
    }

    /// <inheritdoc />
    public async Task<int> AddAsync(TEntity entity, CancellationToken cancellation = default)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity)); 
        
        entity.ModifyDate = DateTime.UtcNow;
        var entityEntry = await DbContext.AddAsync(entity, cancellation);
        
        await SaveChangesAsync(cancellation);
        
        return entityEntry.Entity.Id;
    }

    /// <inheritdoc />
    public void Update(TEntity entity)
    {
        UpdateEntity(entity);

        SaveChanges();
    }

    /// <inheritdoc />
    public async Task UpdateAsync(TEntity entity, CancellationToken cancellation = default)
    {
        UpdateEntity(entity);

        await SaveChangesAsync(cancellation);
    }

    /// <inheritdoc />
    public void Delete(object key, bool throwIfNotFound)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var entry = Find(key);
        switch (entry)
        {
            case null when throwIfNotFound:
                throw new EntityNotFoundException(
                    $"Не удалось удалить сущность '{typeof(TEntity).Name}' с идентиыикатором '{key}', т.к. она не была найдена в базе");
            case null:
                return;
            default:
                DbSet.Remove(entry);
                SaveChanges();
                break;
        }
    }

    /// <inheritdoc />
    public async Task DeleteAsync(object key, bool throwIfNotFound, CancellationToken cancellation = default)
    {
        if (key == null)
            throw new ArgumentNullException(nameof(key));

        var entry = await FindAsync(key, cancellation);

        if (entry == null && throwIfNotFound)
            throw new EntityNotFoundException(
                $"Не удалось удалить сущность '{typeof(TEntity).Name}' с идентификатором '{key}', т.к. она не была найдена в базе");

        if (entry != null)
        {
            DbSet.Remove(entry);
            await SaveChangesAsync(cancellation);
        }
    }

    /// <inheritdoc />
    public void AddRange(IEnumerable<TEntity> entities)
    {
        var enumerable = entities.ToList();
        if (entities == null || !enumerable.Any())
            throw new ArgumentException(null, nameof(entities));

        foreach (var entity in entities)
        {
            entity.ModifyDate = DateTime.UtcNow;
        }
        
        DbContext.AddRange(enumerable);
        SaveChanges();
    }

    /// <inheritdoc />
    public async Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default)
    {
        var enumerable = entities.ToList();
        if (entities == null || !enumerable.Any())
            throw new ArgumentException(null, nameof(entities));

        foreach (var entity in entities)
        {
            entity.ModifyDate = DateTime.UtcNow;
        }
        
        await DbContext.AddRangeAsync(entities, cancellation);

        await SaveChangesAsync(cancellation);
    }
    
    /// <inheritdoc />
    public PropertyInfo GetPrimaryKeyProperty()
    {
        var keyProperties = DbContext.Model.FindEntityType(typeof(TEntity)).FindPrimaryKey().Properties
            .Select(s => s.PropertyInfo).ToList();

        if (keyProperties.Count < 1 || keyProperties.Count > 1)
            throw new InvalidOperationException("Получение идентификатора поддерживается только для сущностей с простым первичным ключом");

        return keyProperties.Single();
    }

    /// <summary>
    /// Метод обновление сущности.
    /// </summary>
    /// <param name="entity">Тип сущности.</param>
    private void UpdateEntity(TEntity entity)
    {
        if (entity == null)
            throw new ArgumentNullException(nameof(entity));

        entity.ModifyDate = DateTime.UtcNow;
        var state = DbContext.Entry(entity).State;
        if (state == EntityState.Detached)
            DbContext.Attach(entity);

        DbContext.Update(entity);
    }
}