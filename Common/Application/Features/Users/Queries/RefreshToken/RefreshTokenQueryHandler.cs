using Application.Abstraction;
using Domain.Request.Users;
using Domain.Response.Users;
using MediatR;

namespace Application.Features.Users.Queries.RefreshToken
{
    public class RefreshTokenQueryHandler : IRequestHandler<RefreshTokenQuery, RefreshTokenResponse>
    {
        private readonly IUser _userRepository;

        public RefreshTokenQueryHandler(IUser userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task<RefreshTokenResponse> Handle(RefreshTokenQuery request, CancellationToken cancellationToken)
        {
            return await _userRepository.RefreshTokenAsync(new RefreshTokenRequest { Token = request.Token });
        }
    }
}
