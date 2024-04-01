using KendineMuzisyen.Core.Security.Dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Core.Security.Helpers
{
    public interface ITokenHelper
    {
        SessionAddDto CreateNewToken(UserDto userDto);
    }
}
