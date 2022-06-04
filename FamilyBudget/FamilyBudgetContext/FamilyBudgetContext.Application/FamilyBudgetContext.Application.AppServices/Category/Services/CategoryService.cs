using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyBudgetContext.Application.AppServices.Category.Helpers;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.CreateDefaultCategories;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.Dto;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.GetUserCategory;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Category.Services;

public class CategoryService : ICategoryService
{
    private readonly IUserRepository _userRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;


    public CategoryService(IMapper mapper, IUserRepository userRepository, ICategoryRepository categoryRepository)
    {
        _mapper = mapper;
        _userRepository = userRepository;
        _categoryRepository = categoryRepository;
    }

    public async Task<GetUserCategoryResponse> GetUserCategory(GetUserCategoryRequest request, CancellationToken cancellation)
    {
        var user = await _userRepository.GetByIdAsync(request.UserId, cancellation);
        return new GetUserCategoryResponse
        {
            Categories = _mapper.Map<IList<CategoryEntity>, IList<CategoryDto>>(user.Categories)
        };
    }
    
    public Task<CreateDefaultCategoriesResponse> CreateDefaultCategories(CreateDefaultCategoriesRequest request, CancellationToken cancellation)
    {
        var categories = CategoryHelpers.DefaultCategories.ToList();
        foreach (var category in categories)
        {
            category.Id = 0;
            category.UserId = request.UserId;
            category.ModifyDate = DateTime.UtcNow;
        }

        return Task.FromResult(new CreateDefaultCategoriesResponse
        {
            DefaultCategories = categories
        });
    }
}