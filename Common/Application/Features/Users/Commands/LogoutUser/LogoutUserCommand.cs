using Domain.Response.Users;
using MediatR;

namespace Application.Features.Users.Commands.LogoutUser
{
    public class LogoutUserCommand : IRequest<LogoutResponse>
    {
        public string Token { get; set; }
    }
}
