using AutoMapper;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.Dto;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.MapProfiles;

public class CategoryMapProfile : Profile
{
    public CategoryMapProfile()
    {
        CreateMap<CategoryEntity, CategoryDto>();
    }
}