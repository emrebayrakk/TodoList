using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using TodoList.Business.Abstract;
using TodoList.Core.Utilities.Results.Abstract;
using TodoList.Core.Utilities.Results.Concrete;
using TodoList.Core.Utilities.Security.Token;
using TodoList.DataAccess.Abstract;
using TodoList.Entities.Concrete;
using TodoList.Entities.DTOs;

namespace TodoList.Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly AppSetting _appSettings;

        public UserManager(IUserDal userDal , IOptions<AppSetting> appSettings)
        {
            _userDal = userDal;
            _appSettings = appSettings.Value;
        }
        public IDataResult<List<User>> GetAll()
        {
            var result = _userDal.GetAll().ToList();
            if (result.Count==0)
            {
                return new ErrorDataResult<List<User>>("kullanıcı yok");
            }

            return new SuccessDataResult<List<User>>(result);
        }

        public IResult AddUser(User user)
        {
            _userDal.Add(user);
            return new SuccessResult("kullanıcı eklendi");
        }

        public IResult DeleteUser(User user)
        {
            _userDal.Delete(user);
            return new SuccessResult("kullanıcı silindi");
        }

        public IResult UpdateUser(User user)
        {
            _userDal.Update(user);
            return new SuccessResult("kullanıcı güncellendi");
        }

        public AccessToken Authenticate(UserForLoginDto userForLoginDto)
        {
            var user =  _userDal.Get(x => x.UserName == userForLoginDto.UserName && x.UserPassword == userForLoginDto.UserPassword);
            if (user == null)
                return null;
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_appSettings.SecurityKey);
            var tokenDescriptor = new SecurityTokenDescriptor()
            {
                Subject = new ClaimsIdentity(new[] {
                    new Claim(ClaimTypes.Name, user.UserId.ToString())
                }),
                Expires = DateTime.UtcNow.AddDays(7),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            AccessToken accessToken = new AccessToken()
            {
                Token = tokenHandler.WriteToken(token),
                UserName = user.UserName,
                Expiration = (DateTime)tokenDescriptor.Expires,
                UserId = user.UserId
            };
            return  accessToken;

        }
    }
}
