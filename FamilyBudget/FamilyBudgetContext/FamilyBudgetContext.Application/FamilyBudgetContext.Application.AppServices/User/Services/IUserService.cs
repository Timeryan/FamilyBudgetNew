using System.Threading;
using System.Threading.Tasks;
using FamilyBudgetContext.Contracts.Api.Contracts.User.ConfirmEmail;
using FamilyBudgetContext.Contracts.Api.Contracts.User.GetUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.LoginUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.PasswordRecovery;
using FamilyBudgetContext.Contracts.Api.Contracts.User.RegisterUser;
using FamilyBudgetContext.Contracts.Api.Contracts.User.UpdateUser;

namespace FamilyBudgetContext.Application.AppServices.User.Services
{
    public interface IUserService
    {
        Task<GetUserResponse> GetUser(GetUserRequest request, CancellationToken cancellation);
        Task<LoginUserResponse> LoginUser(LoginUserRequest request, CancellationToken cancellation);
        Task<RegisterUserResponse> RegisterUser(RegisterUserRequest request, CancellationToken cancellation);
        Task<ConfirmEmailResponse> ConfirmEmail(ConfirmEmailRequest request, CancellationToken cancellation);
        Task<UpdateUserResponse> UpdateUser(UpdateUserRequest request, CancellationToken cancellation);
        Task<PasswordRecoveryResponse> PasswordRecovery(PasswordRecoveryRequest requestRequest, CancellationToken cancellation);
    }
}
