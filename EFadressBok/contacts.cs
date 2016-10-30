using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EFadressBok
{
   public class contacts : DbContext
    {
        [Key]
        public int contactId { get; set; }
        public string namn { get; set; }
        public string gatuadress { get; set; }
        public int postnummer { get; set; }
        public string postort { get; set; }
        public string telefon { get; set; }
        public string epost { get; set; }
        [Column(TypeName = "Date")]
        public DateTime födelsedag { get; set; }

        public DbSet<contacts> contact { get; set; }

    }
}
