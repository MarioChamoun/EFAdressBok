using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFadressBok
{
   public class kontakter
    {
        public int contactId { get; set; }
        public string namn { get; set; }
        public string gatuadress { get; set; }
        public int postnummer { get; set; }
        public string postort { get; set; }
        public string telefon { get; set; }
        public string epost { get; set; }

        [Column(TypeName = "Date")]
        public DateTime födelsedag { get; set; }
    }
}
