
using Common.Electricity.Constant;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using ModelClass.DTO;
using ModelClass.ViewModel;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Service.Oxygen.Handler
{
    public class AuthenticationManager : IAuthenticationManager
    {
        private readonly JwtTokenSetting _jwtSetting;

        public AuthenticationManager(IOptions<JwtTokenSetting> jwtSettingOption)
        {
            _jwtSetting = jwtSettingOption.Value;
        }

        public string BuildToken(User user)
        {

            DateTime expDate = DateTime.Now.AddHours(Convert.ToInt16(_jwtSetting.ExpiresOn));

            var claims = new List<Claim> {
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UserType.ToString()?? string.Empty),
                    new Claim(JwtClaims.Email, user.Email?? string.Empty),
                    new Claim("Role", user.Role.ToString()?? string.Empty),
                    new Claim("userid", user.UserId.ToString()?? string.Empty),


                    new Claim(JwtClaims.ExpiresDate, expDate.ToString()),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim(JwtClaims.AccessRight, user.UserType.ToString() ?? string.Empty)
                };


            //claims.Add(new Claim(ClaimTypes.Role, user?.UserTypeName ?? string.Empty));

            SymmetricSecurityKey key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtSetting.Key));
            SigningCredentials credential = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            JwtSecurityToken token = new JwtSecurityToken(_jwtSetting.Issuer,
                                                          _jwtSetting.Issuer,
                                                          claims,
                                                          expires: expDate,
                                                          signingCredentials: credential);

            string tokenValue = new JwtSecurityTokenHandler().WriteToken(token);

            return string.IsNullOrEmpty(tokenValue) ? string.Empty : tokenValue;
        }
    }

    public interface IAuthenticationManager
    {
        string BuildToken(User user);
    }
}
