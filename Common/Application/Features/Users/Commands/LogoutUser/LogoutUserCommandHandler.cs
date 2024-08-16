using Application.Abstraction;
using Domain.Response.Users;
using MediatR;

namespace Application.Features.Users.Commands.LogoutUser
{
    public class LogoutUserCommandHandler : IRequestHandler<LogoutUserCommand, LogoutResponse>
    {
        private readonly IUser _userRepository;

        public LogoutUserCommandHandler(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<LogoutResponse> Handle(LogoutUserCommand request, CancellationToken cancellationToken)
        {
            return await _userRepository.LogoutUserAsync(request.Token);
        }
    }
}
