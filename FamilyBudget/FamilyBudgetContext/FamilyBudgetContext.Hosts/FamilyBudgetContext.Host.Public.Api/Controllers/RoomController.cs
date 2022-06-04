using System.Net;
using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Application.Handlers.Room.AddUserToRoom;
using FamilyBudgetContext.Application.Handlers.Room.CreateRoom;
using FamilyBudgetContext.Application.Handlers.Room.DeleteUserFromRoom;
using FamilyBudgetContext.Application.Handlers.Room.GetRoom;
using FamilyBudgetContext.Application.Handlers.Room.GetRoomByInviteCode;
using FamilyBudgetContext.Application.Handlers.Room.UpdateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.AddUserToRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.CreateRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.DeleteUserFromRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoom;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.UpdateRoom;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FamilyBudgetContext.Host.Public.Api.Controllers
{
    /// <summary>
    /// Контролер для работы с комнатами.
    /// </summary>
    [Authorize]
    [Route("api/room")]
    [Produces("application/json")]
    [ApiController]
    public class RoomController : ControllerBase
    {
        private readonly IMediator _mediator;

        /// <summary>
        /// Иницилизирует экзепляр класса <see cref="RoomController"/>.
        /// </summary>
        /// <param name="mediator">Медиатор.</param>
        public RoomController(IMediator mediator)
        {
            _mediator = mediator;
        }
        
        /// <summary>
        /// Метод создания комнаты.
        /// </summary>
        /// <param name="request">Данные для создания комнаты.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Комната.</returns>
        [HttpPost("create")]
        [ProducesResponseType(typeof(CreateRoomResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Create(CreateRoomRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new CreateRoomCommand(request), cancellation));
        }
        
        /// <summary>
        /// Метод обновления комнаты.
        /// </summary>
        /// <param name="request">Данные для обновления комнаты.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Индитификатор комнаты.</returns>
        [HttpPost("update")]
        [ProducesResponseType(typeof(UpdateRoomResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> Update(UpdateRoomRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new UpdateRoomCommand(request), cancellation));
        }
        
        /// <summary>
        /// Метод получения комнаты по коду приглашения.
        /// </summary>
        /// <param name="request">Данные кода приглашения.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Комната.</returns>
        [HttpGet("getRoomByInviteCode")]
        [ProducesResponseType(typeof(GetRoomByInviteCodeResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoomByInviteCode([FromQuery] GetRoomByInviteCodeRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetRoomByInviteCodeQuery(request), cancellation));
        }
        
        /// <summary>
        /// Метод добавления пользователя в комнату.
        /// </summary>
        /// <param name="request">Индитификатор комнаты и пользователя.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Признак успеха операции.</returns>
        [HttpPost("addUserToRoom")]
        [ProducesResponseType(typeof(AddUserToRoomResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> AddUserToRoom(AddUserToRoomRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new AddUserToRoomCommand(request), cancellation));
        }
        
        /// <summary>
        /// Метод получения комнаты.
        /// </summary>
        /// <param name="request">Индитификатор комнаты.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Комната.</returns>
        [HttpGet("getRoom")]
        [ProducesResponseType(typeof(GetRoomResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetRoom([FromQuery] GetRoomRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new GetRoomQuery(request), cancellation));
        }
        
        /// <summary>
        /// Метод удаления пользователя из комнаты.
        /// </summary>
        /// <param name="request">Индитификатор комнаты и пользователя.</param>
        /// <param name="cancellation">Отмена операции.</param>
        /// <returns>Признак успеха операции.</returns>
        [HttpPost("deleteUserFromRoom")]
        [ProducesResponseType(typeof(DeleteUserFromRoomResponse), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteUserFromRoom(DeleteUserFromRoomRequest request, CancellationToken cancellation)
        {
            return Ok(await _mediator.Send(new DeleteUserFromRoomCommand(request), cancellation));
        }
    }
}
