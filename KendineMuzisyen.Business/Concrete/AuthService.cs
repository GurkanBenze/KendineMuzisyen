using KendineMuzisyen.Business.Abstract;
using KendineMuzisyen.Core.Result;
using KendineMuzisyen.Core.Security.Dto;
using KendineMuzisyen.Core.Security.Helpers;
using KendineMuzisyen.DataAccess.Abstract;
using KendineMuzisyen.Entity.Dtos.Auth;
using KendineMuzisyen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Business.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly IMusicianService _musicianService;
        private readonly ITokenHelper _tokenHelper;
        private readonly IUserSessionDal _userSessionDal;

        public AuthService(IMusicianService musicianService, ITokenHelper tokenHelper, IUserSessionDal userSessionDal)
        {
            _musicianService = musicianService;
            _tokenHelper = tokenHelper;
            _userSessionDal = userSessionDal;
        }

        public IDataResult<AccessToken> CreateToken(int userId)
        {
            try
            {
                var musician = _musicianService.GetByFilter(x => x.Id == userId);

                var userDto = new UserDto()
                {
                    Id = musician.Data.Id,
                    Email = musician.Data.Email
                };

                //aşağıdaki sessionAddDto içinde hashlenmiş token değeri ve userId tutmaktadır
                var sessionAddDto = _tokenHelper.CreateNewToken(userDto);


                var userSession = new UserSession()
                {
                    Token = sessionAddDto.TokenString,
                    ApplicationUserId = sessionAddDto.UserId,
                    CreatedDate = DateTime.Now,
                    ExpireDate = DateTime.Now.AddDays(1),
                };

                _userSessionDal.Add(userSession);

                var accessToken = new AccessToken()
                {
                    Expiration = userSession.ExpireDate,
                    Token = userSession.Token
                };

                return new SuccessDataResult<AccessToken>(accessToken, "Ok");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<AccessToken>(new AccessToken(), e.Message);
            }
        }

        public IDataResult<AccessToken> Login(LoginDto loginDto)
        {
            try
            {
                if (loginDto.Email == null || loginDto.Password == null)
                {
                    return new ErrorDataResult<AccessToken>(null, "Lütfen tüm bilgilerinizi eksiksiz doldurun.");
                }

                var musician = _musicianService.GetByFilter(x => x.Email == loginDto.Email).Data;

                var result = CreateToken(musician.Id);

                return new SuccessDataResult<AccessToken>(result.Data);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<AccessToken>(null, e.Message);
            }
        }

        public IDataResult<AccessToken> Register(RegisterDto registerDto)
        {
            try
            {
                if (registerDto.Name == null || registerDto.Surname == null || registerDto.Email == null || registerDto.Password == null)
                {
                    return new ErrorDataResult<AccessToken>(null, "Lütfen tüm bilgilerinizi eksiksiz doldurun.");
                }

                if (registerDto.Password.Contains(registerDto.Name.Trim()))
                {
                    return new ErrorDataResult<AccessToken>(null, "Parolanız adınızı içeremez.");
                }

                if (registerDto.Password.Length < 5)
                {
                    return new ErrorDataResult<AccessToken>(null, "Parolanız en az 5 karakterden oluşmalıdır.");
                }

                if (registerDto.Password.Contains(' '))
                {
                    return new ErrorDataResult<AccessToken>(null, "Parolanız boşluk içeremez.");
                }

                if (registerDto.Password != registerDto.ControlPassword)
                {
                    return new ErrorDataResult<AccessToken>(null, "Parolalar birbiri ile uyuşmuyor.");
                }

                byte[] passwordSalt, passwordHash;

                HashingHelper.CreatePasswordHash(registerDto.Password, out passwordSalt, out passwordHash);

                var musician = new Musician()
                {
                    Surname = registerDto.Surname,
                    Name = registerDto.Name,
                    CreatedDate = DateTime.Now,
                    PasswordSalt = passwordSalt,
                    PasswordHash = passwordHash,
                    Email = registerDto.Email,
                    IsActive = true
                };

                _musicianService.Add(musician);

                var result = CreateToken(musician.Id);

                return new SuccessDataResult<AccessToken>(result.Data);
            }
            catch (Exception ex)
            {
                return new ErrorDataResult<AccessToken>(null, ex.Message);

            }
        }
    }
}
