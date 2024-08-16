using Domain.Response.Users;
using MediatR;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommand : IRequest<LoginResponse>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
