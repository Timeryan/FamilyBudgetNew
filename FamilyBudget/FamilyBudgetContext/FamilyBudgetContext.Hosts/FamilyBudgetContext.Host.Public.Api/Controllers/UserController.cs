using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.Handlers.User.ConfirmEmail;
using FamilyBudgetContext.Application.Handlers.User.GetUser;
using FamilyBudgetContext.Application.Handlers.User.LoginUser;
using FamilyBudgetContext.Application.Handlers.User.PasswordRecovery;
using FamilyBudgetContext.Application.Handlers.User.RegisterUser;
using FamilyBudgetContext.Application.Handlers.User.UpdateUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.ConfirmEmail;
using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.PasswordRecovery;
using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetContext.Host.Public.Api.Controllers
{
    /// <summary>
    /// Контролер для работы с пользователями.
    /// </summary>
    [Route("api/user")]
    [Produces("application/json")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Иницилизирует экзепляр класса <see cref="UserController"/>.
        /// </summary>
        /// <param name="mediator">Медиатор.</param>
        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Метод подтверждения почты.
        /// </summary>
        /// <param name="request">Данные для подтверждения почты.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Признак успеха операции.</returns>
        [HttpPost("confirmEmail")]
        [ProducesResponseType(typeof(ConfirmEmailResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> ConfirmEmail(ConfirmEmailRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new ConfirmEmailCommand(request), cancellation));
        }

        /// <summary>
        /// Метод регистрации пользователя.
        /// </summary>
        /// <param name="request">Данные для регистрации пользователя.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Индитификатор пользователя.</returns>
        [HttpPost("register")]
        [ProducesResponseType(typeof(RegisterUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Register(RegisterUserRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new RegisterUserCommand(request), cancellation));
        }

        /// <summary>
        /// Метод авторизации пользователя.
        /// </summary>
        /// <param name="request">Данные для авторизации пользователя.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Данные пользователя.</returns>
        [HttpPost("login")]
        [ProducesResponseType(typeof(LoginUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Login(LoginUserRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new LoginUserQuery(request), cancellation));
        }
        
        /// <summary>
        /// Метод обновления пользователя.
        /// </summary>
        /// <param name="request">Данные для обновления пользователя.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Индитификатор пользователя.</returns>
        [HttpPost("update")]
        [ProducesResponseType(typeof(UpdateUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateUserRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new UpdateUserCommand(request), cancellation));
        }

        /// <summary>
        /// Метод получения пользователя.
        /// </summary>
        /// <param name="request">Данные для получения пользователя.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Данные пользователя.</returns>
        [Authorize]
        [HttpGet("getUserById")]
        [ProducesResponseType(typeof(GetUserResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetUserInfoAsync([FromQuery] GetUserRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetUserQuery(request), cancellation));
        }
        
        /// <summary>
        /// Метод востановления пароля.
        /// </summary>
        /// <param name="request">Данные для востановления пароля.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Индитификатор пользователя.</returns>
        [HttpPost("passwordRecovery")]
        [ProducesResponseType(typeof(PasswordRecoveryResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> PasswordRecovery(PasswordRecoveryRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new PasswordRecoveryCommand(request), cancellation));
        }
    }
}
