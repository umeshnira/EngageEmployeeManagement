using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using EAM.Application;
using EAM.Application.Services;
using EAM.Common.Entities;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Identity;

namespace EAM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IBService<UserService> _service;
        private readonly IOptions<JWTOptions> _options;

        public AccountController(ILogger<AccountController> logger, IBService<UserService> service, IOptions<JWTOptions> options)
        {
            _logger = logger;
            _service = service;
            _options = options;
        }
        [Authorize]
        [HttpGet]
        [Route("refreshtoken")]
        public string RefreshToken()
        {
            var principal = this.User;
            var claims = principal.Claims.ToDictionary(x => x.Type);
            List<Claim> newClaims = new List<Claim>();
            foreach(var name in claims.Keys)
            {
                if (string.Equals(name, ClaimTypes.Name)
                    || string.Equals(name, ClaimTypes.Role)
                    || string.Equals(name, ClaimTypes.NameIdentifier))                 {
                    newClaims.Add(claims[name]);
                }
            }
            var token = CreateToken(newClaims);
            return token;
        }
        public string CreateToken(IEnumerable<Claim> claims)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_options.Value.Secret);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(_options.Value.MinutesToExpire),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token1 = tokenHandler.CreateToken(tokenDescriptor);
            var token = tokenHandler.WriteToken(token1);
            return token;
        }
        [HttpGet]
        [Route("gettoken")]
        public string GetToken(string username, string password)
        {
            var info = _service.provider.Validate(username, password);
            if (info != null)
            {
                var claims = new List<Claim>();
                claims.Add(new Claim(ClaimTypes.NameIdentifier, info.EmployeeID.ToString()));
                foreach(var role in info.Roles)
                {
                    claims.Add(new Claim(ClaimTypes.Role, role));
                }
                var token = CreateToken(claims);
                return token;
            }
            return null;
        }
    }
}