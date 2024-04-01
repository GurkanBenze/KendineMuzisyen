using KendineMuzisyen.Core.EntityFramework.Repository.Abstract;
using KendineMuzisyen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.DataAccess.Abstract
{
    public interface IUserSessionDal : IEfRepositoryBase<UserSession>
    {
    }
}
