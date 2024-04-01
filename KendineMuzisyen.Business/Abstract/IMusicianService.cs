using KendineMuzisyen.Core.Result;
using KendineMuzisyen.Entity.Dtos.Musician;
using KendineMuzisyen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Business.Abstract
{
    public interface IMusicianService
    {
        IDataResult<bool> Update(MusicianRequestDto musicianRequestDto);
        IDataResult<bool> Add(Musician musician);
        IDataResult<bool> Remove(int userId);
        IDataResult<List<MusicianListDto>> GetList();
        IDataResult<Musician> GetByFilter(Expression<Func<Musician, bool>> filter);
    }
}
