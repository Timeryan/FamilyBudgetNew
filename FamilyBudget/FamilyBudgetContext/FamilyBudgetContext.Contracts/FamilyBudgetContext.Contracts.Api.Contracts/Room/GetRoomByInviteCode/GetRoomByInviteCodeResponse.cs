using System.Collections.Generic;
using FamilyBudgetContext.Contracts.Api.Contracts.Room.Dto;

namespace FamilyBudgetContext.Contracts.Api.Contracts.Room.GetRoomByInviteCode;

public class GetRoomByInviteCodeResponse
{
    public int Id { get; set; }
    public string Name { get; set; }
    public string Photo { get; set; }
    public string InviteCode { get; set; }
    public virtual IList<UserDto> Users { get; set; }
}