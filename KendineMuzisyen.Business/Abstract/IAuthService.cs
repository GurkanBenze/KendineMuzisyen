using KendineMuzisyen.Core.Result;
using KendineMuzisyen.Core.Security.Dto;
using KendineMuzisyen.Entity.Dtos.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Business.Abstract
{
    public interface IAuthService
    {
        IDataResult<AccessToken> Login(LoginDto loginDto);
        IDataResult<AccessToken> Register(RegisterDto registerDto);
    }
}
