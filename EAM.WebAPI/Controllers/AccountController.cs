using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing;
using System.Security.Claims;
using Microsoft.Extensions.Logging;
using EAM.Data;
using EAM.Data.Repositories;
using EAM.Common.Entities;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Authorization;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace EAM.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly ILogger<AccountController> _logger;
        private readonly IRepository<UserRepository> _repository;
        private readonly IOptions<JWTOptions> _options;

        public AccountController(ILogger<AccountController> logger, IRepository<UserRepository> repository, IOptions<JWTOptions> options)
        {
            _logger = logger;
            _repository = repository;
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
                    || string.Equals(name, "userid"))                 {
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
            if (_repository.Provider.Validate(username, password))
            {
                var claims = new Claim[]
                {
                    new Claim(ClaimTypes.Name, "abc"),
                    new Claim(ClaimTypes.Role, "admin"),
                    new Claim("userid", "1")
                };
                var token = CreateToken(claims);
                return token;
            }
            return null;
        }
    }
}