using KendineMuzisyen.Entity.Entities;
using System.Data.Entity;

namespace KendineMuzisyen.DataAccess.Context
{
    public class KendineMuzisyenDbContext : DbContext
    {
        public KendineMuzisyenDbContext()
        {
            Database.Connection.ConnectionString = @"Server=DESKTOP-GE22EA4;Database=KendineMuzisyenDb;User Id=sa;Password=1234;";
        }

        public DbSet<Band> Bands { get; set; }
        public DbSet<BandAdvert> BandAdverts { get; set; }
        public DbSet<Instrument> Instruments { get; set; }
        public DbSet<Musician> Musicians { get; set; }
        public DbSet<MusicianAdvert> MusicianAdverts { get; set; }
        public DbSet<MusicianBand> MusicianBands { get; set; }
        public DbSet<MusicianTalentedInstrument> MusicianTalentedInstruments { get; set; }
        public DbSet<UserSession> UserSessions { get; set; }
    }
}
