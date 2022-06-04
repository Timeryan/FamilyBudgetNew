using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.Handlers.Operation.CreateOperation;
using FamilyBudgetContext.Application.Handlers.Operation.DeleteOperation;
using FamilyBudgetContext.Application.Handlers.Operation.GetCategoryOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.CreateOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.DeleteOperation;
using FamilyBudgetContext.Contracts.Api.Contracts.Operation.GetCategoryOperation;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetContext.Host.Public.Api.Controllers
{
    /// <summary>
    /// Контролер для работы с операциями.
    /// </summary>
    [Route("api/operation")]
    [Produces("application/json")]
    [ApiController]
    public class OperationController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Иницилизирует экзепляр класса <see cref="OperationController"/>.
        /// </summary>
        /// <param name="mediator">Медиатор.</param>
        public OperationController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Метод создания операции.
        /// </summary>
        /// <param name="request">Данные для создания операции.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Операция.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateOperationResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CreateOperationRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new CreateOperationCommand(request), cancellation));
        }
        
        /// <summary>
        /// Метод удаления операции.
        /// </summary>
        /// <param name="request">Данные для удаления операции.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Признак успеха операции.</returns>
        [HttpPost("delete")]
        [ProducesResponseType(typeof(DeleteOperationResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Delete(DeleteOperationRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new DeleteOperationCommand(request), cancellation));
        }
        
        /// <summary>
        /// Метод получания операций по категории.
        /// </summary>
        /// <param name="request">Данные для получения операций.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Операции.</returns>
        [HttpGet("getCategoryOperation")]
        [ProducesResponseType(typeof(GetCategoryOperationResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetCategoryOperation([FromQuery]GetCategoryOperationRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetCategoryOperationQuery(request), cancellation));
        }
    }
}
