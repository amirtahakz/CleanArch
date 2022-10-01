using Api.ViewModels.Products;
using AutoMapper;
using CleanArch.Application.Products.Create;
using CleanArch.Application.Users.Register;
using CleanArch.Query.Products.GetById;
using CleanArch.Query.Users.GetByEmail;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Api.Controllers.V1
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0" , Deprecated =true)]
    [ApiController]
    public class AuthController : ControllerBase
    {
        IMediator _mediator;
        IMapper _mapper;
        private readonly IConfiguration _configuration;

        public AuthController(IMediator mediator, IMapper mapper, IConfiguration configuration)
        {
            _mediator = mediator;
            _mapper = mapper;
            _configuration = configuration;
        }
        [HttpPost]
        public async Task<IActionResult> RegisterUser(RegisterUserCommand command)
        {
            var res = await _mediator.Send(command);

            return Created("", res);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login(string email, string phoneNumber)
        {
            var user = await _mediator.Send(new GetByEmailQuery(email));
            if (user == null)
                return NotFound("کاربری با مشخصات وارد شده یافت نشد");

            if (user.PhoneNumber.Phone != phoneNumber)
                return NotFound("کاربری با مشخصات وارد شده یافت نشد");

            var claims = new List<Claim>()
            {
                new Claim("email",user.Email),
                new Claim(ClaimTypes.NameIdentifier,user.Id.ToString())
            };
            var secretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:AccessTokenSecret"]));
            var credential = new SigningCredentials(secretKey, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                expires: DateTime.Now.AddDays(7),
                signingCredentials: credential);

            var jwtToken = new JwtSecurityTokenHandler().WriteToken(token);
            return Ok(jwtToken);
        }
    }
}
