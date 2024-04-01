using Autofac;
using KendineMuzisyen.DataAccess.Abstract;
using KendineMuzisyen.DataAccess.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Business.Autofac
{
    public class AutofacBusinessModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            //Dal
            builder.RegisterType<BandDal>().As<IBandDal>().SingleInstance();
            builder.RegisterType<BandAdvertDal>().As<IBandAdvertDal>().SingleInstance();
            builder.RegisterType<InstrumentDal>().As<IInstrumentDal>().SingleInstance();
            builder.RegisterType<MusicianAdvertDal>().As<IMusicianAdvertDal>().SingleInstance();
            builder.RegisterType<MusicianBandDal>().As<IMusicianBandDal>().SingleInstance();
            builder.RegisterType<MusicianDal>().As<IMusicianDal>().SingleInstance();
            builder.RegisterType<MusicianTalentedInstrumentDal>().As<IMusicianTalentedInstrumentDal>().SingleInstance();
            builder.RegisterType<UserSessionDal>().As<IUserSessionDal>().SingleInstance();

            //Service
           


        }
    }
}
