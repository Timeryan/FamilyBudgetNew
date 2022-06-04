using AutoMapper;
using FamilyBudgetContext.Application.AppServices.Shared.Helpers;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.Dto;
using FamilyBudgetContext.Domain.Domain;

namespace FamilyBudgetContext.Application.AppServices.Shared.MapProfiles;

public class OperationMapProfile : Profile
{
    public OperationMapProfile()
    {
        CreateMap<CreateOperationRequest, OperationEntity>()
            .ForMember(dest=>dest.Id,opt=>opt.Ignore())
            .ForMember(dest=>dest.ModifyDate,opt=>opt.Ignore())
            .ForMember(dest=>dest.Category,opt=>opt.Ignore())
            .ForMember(dest=>dest.Date,opt=>opt.MapFrom(src => src.Date.UnixTimeStampToDateTime()));
        CreateMap<CreateOperationRequest, CreateOperationResponse>()
            .ForMember(dest=>dest.Id,opt=>opt.Ignore());

        CreateMap<OperationEntity, OperationDto>()
            .ForMember(dest=>dest.Date,opt=>opt.MapFrom(src => src.Date.DateTimeToUnixTimeStamp()));
    }
}