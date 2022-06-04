using System.Linq.Expressions;
using System.Reflection;

namespace Common.DataAccess.Repositories
{
    /// <summary>
    /// Базовый репозиторий.
    /// </summary>
    /// <typeparam name="TEntity">Тип сущности.</typeparam>
    public interface IRepository<TEntity> where TEntity : class
    {
        /// <summary>
        /// Сохраняет изменения.
        /// </summary>
        void SaveChanges();

        /// <summary>
        /// Асинхронно сохраняет изменения.
        /// </summary>
        /// <param name="cancellation">Токен отмены действия.</param>
        Task SaveChangesAsync(CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет добавление сущности.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        void Add(TEntity entity);

        /// <summary>
        /// Выполняет добавление сущности.
        /// </summary>
        /// <param name="entity">Сущность для добавления.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        Task<int> AddAsync(TEntity entity, CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет обновление сущности.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        void Update(TEntity entity);

        /// <summary>
        /// Выполняет обновление сущности.
        /// </summary>
        /// <param name="entity">Сущность для обновления.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        Task UpdateAsync(TEntity entity, CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет удаление сущности.
        /// </summary>
        /// <param name="key">Идентификатор.</param>
        /// <param name="throwIfNotFound">Выбрасывать исключение, если сущность не найдена.</param>
        void Delete(object key, bool throwIfNotFound = true);

        /// <summary>
        /// Выполняет удаление сущности.
        /// </summary>
        /// <param name="key">Идентификатор.</param>
        /// <param name="throwIfNotFound">Выбрасывать исключение, если сущность не найдена.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        Task DeleteAsync(object key, bool throwIfNotFound = true, CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет добавление массива сущностей.
        /// </summary>
        /// <param name="entities">Массив сущностей для добавления.</param>
        void AddRange(IEnumerable<TEntity> entities);

        /// <summary>
        /// Выполняет добавление массива сущностей.
        /// </summary>
        /// <param name="entities">Массив сущностей для добавления.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        Task AddRangeAsync(IEnumerable<TEntity> entities, CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет поиск сущности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <returns>Сущность.</returns>
        TEntity Find(object id);

        /// <summary>
        /// Выполняет поиск сущности по идентификатору.
        /// </summary>
        /// <param name="id">Идентификатор сущности.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        /// <returns>Сущность.</returns>
        Task<TEntity> FindAsync(object id, CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет запрос к базе данных для получения коллекции сущностей типа <typeparamref name="TProjection"/>.
        /// </summary>
        /// <typeparam name="TProjection">Выходной тип параметра.</typeparam>
        /// <param name="selector">Селектор.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        /// <returns>Коллекция элементов типа <typeparamref name="TProjection"/>.</returns>
        Task<IReadOnlyCollection<TProjection>> QueryAsync<TProjection>(
            Func<IQueryable<TEntity>, Task<IReadOnlyCollection<TProjection>>> selector,
            CancellationToken cancellation = default);

        /// <summary>
        /// Возвращает количество элементов в репозитории.
        /// </summary>
        /// <param name="predicate">Предикат выборки.</param>
        /// <returns>Количество элементов.</returns>
        int Count(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Возвращает количество элементов в репозитории.
        /// </summary>
        /// <param name="predicate">Предикат выборки.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        /// <returns>Количество элементов.</returns>
        Task<int> CountAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет проверку наличия сущности с определенным идентификатором в базе.
        /// </summary>
        /// <param name="key">Идентификатор сущности.</param>
        /// <returns>Признак наличия сущности в базе.</returns>
        bool Exists(object key);

        /// <summary>
        /// Выполняет проверку наличия сущности с определенным идентификатором в базе.
        /// </summary>
        /// <param name="key">Идентификатор сущности.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        /// <returns>Признак наличия сущности в базе.</returns> 
        Task<bool> ExistsAsync(object key, CancellationToken cancellation = default);

        /// <summary>
        /// Выполняет проверку наличия сущности в бд.
        /// </summary>
        /// <param name="predicate">Предикат.</param>
        /// <returns>Признак наличия сущности.</returns>
        bool Exists(Expression<Func<TEntity, bool>> predicate);

        /// <summary>
        /// Выполняет проверку наличия сущности в бд.
        /// </summary>
        /// <param name="predicate">Предикат.</param>
        /// <param name="cancellation">Токен отмены действия.</param>
        /// <returns>Признак наличия сущности.</returns>
        Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate, CancellationToken cancellation = default);
    
        /// <summary>
        /// Возвращает нематериализованный запрос.
        /// </summary>
        /// <returns>Нематериализованный запрос.</returns>
        IQueryable<TEntity> Query();
        
        /// <summary>
        /// Возвращает нематериализованный запрос с условием.
        /// </summary>
        /// <param name="predicate">Предикат.</param>
        /// <returns>Нематериализованный запрос с условием.</returns>
        IQueryable<TEntity> Where(Expression<Func<TEntity, bool>> predicate);
    
        /// <summary>
        /// Возвращает свойство сущности, являющееся первичным ключем.
        /// </summary>
        PropertyInfo GetPrimaryKeyProperty();
    }
}