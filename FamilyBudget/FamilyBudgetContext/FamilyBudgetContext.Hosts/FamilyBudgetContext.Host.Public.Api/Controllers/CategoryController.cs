using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.Handlers.Category.GetUserCategory;
using FamilyBudgetContext.Contracts.Api.Contracts.Category.GetUserCategory;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetContext.Host.Public.Api.Controllers
{
    /// <summary>
    /// Контролер для работы с категориями.
    /// </summary>
    [Route("api/category")]
    [Produces("application/json")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Иницилизирует экзепляр класса <see cref="CategoryController"/>.
        /// </summary>
        /// <param name="mediator">Медиатор.</param>
        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        /// <summary>
        /// Метод получения комнаты пользователя.
        /// </summary>
        /// <param name="request">Данные для получения комнаты.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Комната.</returns>
        [HttpGet("getUserCategory")]
        [ProducesResponseType(typeof(GetUserCategoryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoom([FromQuery] GetUserCategoryRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetUserCategoryQuery(request), cancellation));
        }
    }
}
