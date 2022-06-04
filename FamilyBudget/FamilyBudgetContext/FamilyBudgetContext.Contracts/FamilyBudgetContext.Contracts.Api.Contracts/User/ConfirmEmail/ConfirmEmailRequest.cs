namespace FamilyBudgetContext.Contracts.Api.Contracts.User.ConfirmEmail;

public class ConfirmEmailRequest
{
    public int UserId { get; set; }
    public string ConfirmCode { get; set; }

}