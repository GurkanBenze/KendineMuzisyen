using KendineMuzisyen.Core.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KendineMuzisyen.Entity.Entities
{
    public class Band : IEntity
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int BandOwnerMusicianId { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime UpdatedDate { get; set; }
        public bool IsActive { get; set; }
    }
}
