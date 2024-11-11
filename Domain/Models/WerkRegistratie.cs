using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class WerkRegistratie
    {
        

        public VrijwilligersWerk vrijwilligersWerk { get; set; }

        public User User { get; set; }

        public int RegistratieId { get; set; }



        public WerkRegistratie(VrijwilligersWerk vrijwilligersWerk, User user, int registratieId)
        {
            this.vrijwilligersWerk = vrijwilligersWerk;
            User = user;
            this.RegistratieId = registratieId;
        }





    }
}
