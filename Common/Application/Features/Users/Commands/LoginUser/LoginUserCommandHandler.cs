using Application.Abstraction;
using Domain.Request.Users;
using Domain.Response.Users;
using MediatR;

namespace Application.Features.Users.Commands.LoginUser
{
    public class LoginUserCommandHandler : IRequestHandler<LoginUserCommand, LoginResponse>
    {
        private readonly IUser _userRepository;

        public LoginUserCommandHandler(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LoginResponse> Handle(LoginUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.LoginUserAsync(new LoginRequest { Email = request.Email, Password = request.Password });
        }
    }
}
