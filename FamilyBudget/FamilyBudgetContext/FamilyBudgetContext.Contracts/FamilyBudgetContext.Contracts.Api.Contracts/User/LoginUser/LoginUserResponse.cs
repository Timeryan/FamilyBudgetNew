namespace FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser
{
    public class LoginUserResponse
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string? Photo { get; set; }
        public string Token { get; set;}
        public int? RoomId { get; set; }
    }
}