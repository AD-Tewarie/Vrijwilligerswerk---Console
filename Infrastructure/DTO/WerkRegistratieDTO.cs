using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.DTO
{
    public class WerkRegistratieDTO
    {
        public VrijwilligersWerkDTO VrijwilligersWerk { get; set; }
        public UserDTO User { get; set; }
        public int registratieId { get; set; }



        public WerkRegistratieDTO(VrijwilligersWerkDTO werk, UserDTO user, int registratieId)
        {
            VrijwilligersWerk = werk;
            User = user;
            this.registratieId = registratieId;
        }


    }
}
