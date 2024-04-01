using KendineMuzisyen.Core.EntityFramework.Repository.Concrete;
using KendineMuzisyen.DataAccess.Abstract;
using KendineMuzisyen.DataAccess.Context;
using KendineMuzisyen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.DataAccess.Concrete
{
    public class UserSessionDal : EfRepositoryBase<UserSession, KendineMuzisyenDbContext>, IUserSessionDal
    {
    }
}
