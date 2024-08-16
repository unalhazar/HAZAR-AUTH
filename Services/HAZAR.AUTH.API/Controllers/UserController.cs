using Application.Features.Users.Commands.LoginUser;
using Application.Features.Users.Commands.LogoutUser;
using Application.Features.Users.Commands.RegisterUser;
using Application.Features.Users.Queries.RefreshToken;
using Domain.Response.Users;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace HAZAR.AUTH.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("login")]
        public async Task<ActionResult<LoginResponse>> LoginUser(LoginUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult<LoginResponse>> RegisterUser(RegisterUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult<LogoutResponse>> LogoutUser(LogoutUserCommand command)
        {
            command.Token = Request.Headers["Authorization"].ToString().Replace("Bearer ", "");
            var result = await _mediator.Send(command);
            if (!result.Success)
            {
                return BadRequest(result);
            }
            return Ok(result);
        }

        [HttpPost("refresh-token")]
        public async Task<IActionResult> RefreshToken(RefreshTokenQuery query)
        {
            var response = await _mediator.Send(query);
            if (!response.Success)
            {
                return Unauthorized(new { message = response.Message });
            }
            return Ok(new { token = response.JwtToken, refreshToken = response.RefreshToken });
        }
    }
}
