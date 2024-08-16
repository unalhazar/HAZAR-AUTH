using Application.Abstraction;
using Domain.Request.Users;
using Domain.Response.Users;
using MediatR;

namespace Application.Features.Users.Commands.RegisterUser
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, RegistrationResponse>
    {
        private readonly IUser _userRepository;

        public RegisterUserCommandHandler(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RegistrationResponse> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.RegisterUserAsync(new RegisterUserRequest { Name = request.Name, Email = request.Email, Password = request.Password });
        }
    }
}
