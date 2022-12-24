using AutoMapper;
using Common.Enums;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Services.BusinessObjects;
using Services.Services.Interfaces;
using TOMYCHFinale.Contracts.Request;
using TOMYCHFinale.Contracts.Response;
using TOMYCHFinale.Utils;

namespace TOMYCHFinale.Controllers
{
    
    [Route("User")]
    [ApiController]
    [Authorize(Roles = "User, Admin")]
    public class UserController : ControllerBase
    {
        private ICustomerReadService _customerReadService;
        private ICustomerCreateService _customerCreateService;
        private IConfiguration _config;
        private IMapper _mapper;
        private IEmailService _emailService;

        public UserController(ICustomerReadService customerReadService,
            ICustomerCreateService customerCreateService,
            IMapper mapper, 
            IConfiguration config, 
            IEmailService emailService) 
        {
            _customerReadService = customerReadService;
            _customerCreateService = customerCreateService;
            _mapper = mapper;
            _config = config;
            _emailService = emailService;
        }

        [Authorize(Roles = "Admin")]
        [HttpGet("/customers-list")]
        public async Task<IActionResult> CustomersList([FromQuery] int? limit,
            [FromQuery] int? offset,
            [FromQuery] UrgencyTypes? urgency,
            [FromQuery] RequestStatusTypes? status)
        {
            var data = await _customerReadService.GetUsersList(limit, offset, urgency, status);
            return Ok(_mapper.Map<IEnumerable<UserResponse>>(data.ToList()));
        }

        [AllowAnonymous]
        [HttpGet("{email}/login/{password}")]
        public async Task<IActionResult> Login([FromRoute] string email, [FromRoute] string password)
        {
            var user = await _customerReadService.Login(email, password);
            if (user != null)
            {
                var data = _mapper.Map<UserResponse>(user);
                var token = TokenGenerator.JwtGenerator(data, _config["Jwt:Key"], _config["Jwt:Issuer"]);
                return Ok(token);
            }
            return NotFound();
        }

        [AllowAnonymous]
        [HttpPost("/registration")]
        public async Task<IActionResult> Registration([FromBody] UserRegistrationRequest data) 
        {
            var token = await _customerCreateService.CreateUser(_mapper.Map<UserRegistrationRequest, UserBO>(data));
            var message = _emailService.CreateEmailMessage(
                new Message(data.Email, "Copy the token to confirm your email.", token));

            _emailService.Send(message);

            return Ok($"Email confirmation token was sent to {data.Email}");
        }

        [AllowAnonymous]
        [HttpPut("{token}")]
        public async Task<IActionResult> ConfirmEmail([FromRoute] string token) 
        {
            var user = _mapper.Map<UserResponse>(await _customerCreateService.ConfirmEmail(token));
            var jwtToken = TokenGenerator.JwtGenerator(user, _config["Jwt:Key"], _config["Jwt:Issuer"]);
            return Ok(jwtToken);
        }

        [AllowAnonymous]
        [HttpGet("{email}")]
        public async Task<IActionResult> ForgotPassword([FromRoute] string email) 
        {
            var token = await _customerCreateService.ForgotPassword(email);
            var message = _emailService.CreateEmailMessage(
                new Message(email, "Copy the token from this message.", token));

            _emailService.Send(message);

            return Ok($"a token being sent to {email}");
        }
        
        [HttpPut("/{token}/reset-password/{password}")]
        public async Task<IActionResult> ResetPassword([FromRoute] string token, [FromRoute] string password)
        {
            await _customerCreateService.ResetPassword(token, password);

            return Ok("Your password was changed.");
        }

        
    }
}
