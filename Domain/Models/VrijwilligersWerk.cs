using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class VrijwilligersWerk
    {
        

        public int WerkId { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public int MaxCapaciteit { get; set; }
        public int AantalRegistraties { get; set; }



        public VrijwilligersWerk(int werkId, string titel, string omschrijving, int maxCapaciteit)
        {
            WerkId = werkId;
            Titel = titel;
            Omschrijving = omschrijving;
            MaxCapaciteit = maxCapaciteit;
        }



    }
}
