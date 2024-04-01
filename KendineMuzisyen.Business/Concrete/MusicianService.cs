using KendineMuzisyen.Business.Abstract;
using KendineMuzisyen.Core.Result;
using KendineMuzisyen.DataAccess.Abstract;
using KendineMuzisyen.Entity.Dtos.Musician;
using KendineMuzisyen.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Business.Concrete
{
    public class MusicianService : IMusicianService
    {
        private readonly IMusicianDal _musicianDal;

        public MusicianService(IMusicianDal musicianDal)
        {
            _musicianDal = musicianDal;
        }

        public IDataResult<bool> Add(Musician musician)
        {
            try
            {
                if (musician == null)
                {
                    return new ErrorDataResult<bool>(false, "Kullanıcı bilgilerini kontrol edin!");
                }
                _musicianDal.Add(musician);
                return new SuccessDataResult<bool>(true);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message);

            }
        }

        public IDataResult<Musician> GetByFilter(Expression<Func<Musician, bool>> filter)
        {
            try
            {
                var filteredmusician = _musicianDal.GetByFilter(filter);

                if (filteredmusician == null)
                {
                    return new ErrorDataResult<Musician>(null, "Kullanıcı bulunamadı!");
                }

                return new SuccessDataResult<Musician>(filteredmusician, "Ok");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<Musician>(null, e.Message);
            }
        }

        public IDataResult<List<MusicianListDto>> GetList()
        {
            try
            {
                var musicianList = _musicianDal.GetList();

                if (musicianList.Count == 0)
                {
                    return new ErrorDataResult<List<MusicianListDto>>(null, "Kullanıcı listesi bulunamadı!");
                }

                List<MusicianListDto> MusicianListDto = new List<MusicianListDto>();

                foreach (var musician in musicianList)
                {
                    MusicianListDto.Add(new MusicianListDto()
                    {
                        Name = musician.Name,
                        Surname = musician.Surname,
                        CreatedDate = musician.CreatedDate,
                        UpdatedDate = musician.UpdatedDate,
                        Email = musician.Email,
                        Id = musician.Id,
                        IsActive = musician.IsActive
                    });
                }

                return new SuccessDataResult<List<MusicianListDto>>(MusicianListDto);
            }
            catch (Exception e)
            {
                return new ErrorDataResult<List<MusicianListDto>>(null, e.Message);
            }
        }

      

        public IDataResult<bool> Remove(int musicianId)
        {
            try
            {
                var musician = _musicianDal.GetByFilter(x => x.Id == musicianId);

                if (musician == null)
                {
                    return new ErrorDataResult<bool>(false, "Kullanıcı bulunamadı");
                }

                musician.IsActive = false;

                _musicianDal.Update(musician);

                return new SuccessDataResult<bool>(true, "Ok");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message);
            }
        }

        public IDataResult<bool> Update(MusicianRequestDto musicianRequestDto)
        {
            try
            {
                var musician = _musicianDal.GetByFilter(x => x.Id == musicianRequestDto.Id);

                if (musician == null)
                {
                    return new ErrorDataResult<bool>(false, "Kullanıcı bulunamadı!");
                }

                musician.Name = musicianRequestDto.Name;
                musician.Surname = musicianRequestDto.Surname;
                musician.Email = musicianRequestDto.Email;

                _musicianDal.Update(musician);

                return new SuccessDataResult<bool>(true, "Ok");
            }
            catch (Exception e)
            {
                return new ErrorDataResult<bool>(false, e.Message);
            }
        }
    }
}
