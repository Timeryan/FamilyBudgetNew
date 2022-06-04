using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using FamilyBudgetContext.Application.AppServices.Shared.Repositories;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.Dto;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.DeleteOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.Dto;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.GetCategoryOperation;
using FamilyBudgetContext.Domain.Domain;


namespace FamilyBudgetContext.Application.AppServices.Operation.Services;

public class OperationService : IOperationService
{
    private readonly IOperationRepository _operationRepository;
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;

    public OperationService(IOperationRepository operationRepository, IMapper mapper, ICategoryRepository categoryRepository)
    {
        _operationRepository = operationRepository;
        _mapper = mapper;
        _categoryRepository = categoryRepository;
    }

    public async Task<CreateOperationResponse> CreateOperation(CreateOperationRequest request, CancellationToken cancellation)
    {
        var operation = _mapper.Map<OperationEntity>(request);
        var operationId = await _operationRepository.AddAsync(operation, cancellation);

        var createOperationResponse = _mapper.Map<CreateOperationResponse>(request);
        createOperationResponse.Id = operationId;

        return createOperationResponse;
    }

    public async Task<DeleteOperationResponse> DeleteOperation(DeleteOperationRequest request, CancellationToken cancellation)
    {
        await _operationRepository.DeleteAsync(request.Id, cancellation);
        return new DeleteOperationResponse
        {
            IsSuccess = true
        };
    }

    public async Task<GetCategoryOperationResponse> GetCategoryOperation(GetCategoryOperationRequest request, CancellationToken cancellation)
    {
        var category = await _categoryRepository.GetByIdAsync(request.CategoryId, cancellation);
        return new GetCategoryOperationResponse
        {
            Operations = _mapper.Map<IList<OperationEntity>, IList<OperationDto>>(category.Operations)
        };
    }
}