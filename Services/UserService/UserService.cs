using Microsoft.Extensions.Logging;
using APILibary.Data;
using APILibary.Models;
using System;
using System.Threading.Tasks;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Collections.Generic;

namespace APILibary.Services
{
    public class UserService : IUserService
    {
        private readonly ILogger _logger;
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository, ILogger<UserService> logger)
        {
            this._userRepository = userRepository;
            this._logger = logger;
        }

        public async Task<string> addUser(User user)
        {
            await this._userRepository.addUser(user);

            var identity = GetIdentity(user);

            if (identity == null)
            {
                throw new Exception("login incorrect");
            }

            var encodedJwt = createJwtSecurityToken(identity);
            return encodedJwt;
        }

        public string signInWithPassword(User user)
        {
            var dbUser = this._userRepository.getUser(user);

            if (dbUser == null)
            {
                throw new Exception("login incorrect");
            }

            var identity = GetIdentity(dbUser);
            var encodedJwt = createJwtSecurityToken(identity);
            return encodedJwt;
        }

        private string createJwtSecurityToken(ClaimsIdentity identity)
        {
            var now = DateTime.UtcNow;
            var jwt = new JwtSecurityToken(
                    issuer: AuthOptions.ISSUER,
                    audience: AuthOptions.AUDIENCE,
                    notBefore: now,
                    claims: identity.Claims,
                    expires: now.Add(TimeSpan.FromMinutes(AuthOptions.LIFETIME)),
                    signingCredentials: new SigningCredentials(AuthOptions.GetSymmetricSecurityKey(), SecurityAlgorithms.HmacSha256));
            var encodedJwt = new JwtSecurityTokenHandler().WriteToken(jwt);
            return encodedJwt;
        }
        private ClaimsIdentity GetIdentity(User user)
        {

            var claims = new List<Claim>();
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, user.Login);
            };

            ClaimsIdentity claimsIdentity =
            new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                ClaimsIdentity.DefaultRoleClaimType);
            return claimsIdentity;
        }
    }
}