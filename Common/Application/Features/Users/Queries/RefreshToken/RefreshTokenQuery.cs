using Domain.Response.Users;
using MediatR;

namespace Application.Features.Users.Queries.RefreshToken
{
    public class RefreshTokenQuery : IRequest<RefreshTokenResponse>
    {
        public string Token { get; set; }
    }
}
