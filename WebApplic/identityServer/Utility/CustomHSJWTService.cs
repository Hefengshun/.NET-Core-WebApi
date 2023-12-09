using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Zhaoxi.NET6Demo.IdentitySer.Utility
{
    public class CustomHSJWTService : ICustomJWTService
    {

        #region Option注入
        private readonly JWTTokenOptions _JWTTokenOptions;
        // 通过IOptionsMonitor获取到Program配置的信息
        public CustomHSJWTService(IOptionsMonitor<JWTTokenOptions> jwtTokenOptions)
        {
            _JWTTokenOptions = jwtTokenOptions.CurrentValue;
        }
        #endregion

        /// <summary>
        /// 获取Token
        /// </summary>
        /// <param name="user"></param>
        /// <returns></returns>
        public string GetToken(CurrentUser user)
        {
            //准备有效载荷
          

            List<Claim> claims = new List<Claim>()
            {
                 new Claim(ClaimTypes.Name, user.Name),
                 new Claim("NickName",user.NikeName), 
                 new Claim("Description",user.Description),
                 new Claim("Age",user.Age.ToString()),
            }; 
            //foreach (var role in user.RoleList)
            //{
            //    claims.Add(new Claim(ClaimTypes.Role, role));
            //}
            



            //准备加密key
            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_JWTTokenOptions.SecurityKey));

            //Sha256 加密方式
            SigningCredentials creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);


            JwtSecurityToken token = new JwtSecurityToken(
                  issuer: _JWTTokenOptions.Issuer,
                  audience: _JWTTokenOptions.Audience,
                  claims: claims,
                  expires: DateTime.Now.AddMinutes(5),//5分钟有效期
                  signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
