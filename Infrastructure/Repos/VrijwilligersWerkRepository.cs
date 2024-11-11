using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repos
{
    public class VrijwilligersWerkRepository
    {
        private readonly List<VrijwilligersWerkDTO> vrijwilligersWerk = new List<VrijwilligersWerkDTO>();


        // werk

        VrijwilligersWerkDTO werk1 = new VrijwilligersWerkDTO(1, "Voedselbank", "Help bij het distribueren van voedsel", 5);
        VrijwilligersWerkDTO werk2 = new VrijwilligersWerkDTO(2, "Kleding Sorteren", "Sorteer gedoneerde kleding voor distributie", 4);
        VrijwilligersWerkDTO werk3 = new VrijwilligersWerkDTO(3, "Ondersteuning in onderdak", "Help bij het vinden van onderdak voor daklozen", 10);



        public VrijwilligersWerkRepository()
        {

            {
                vrijwilligersWerk.Add(werk1);
                vrijwilligersWerk.Add(werk2);
                vrijwilligersWerk.Add(werk3);


            };


        }

        public List<VrijwilligersWerkDTO> HaalAlleWerkOp()
        {
            return vrijwilligersWerk;
        }



        public VrijwilligersWerkDTO HaalWerkOpId(int id)
        {
            for (int i = 0; i < vrijwilligersWerk.Count; i++)
            {
                if (vrijwilligersWerk[i].WerkId == id)
                {
                    return vrijwilligersWerk[i];
                }
    
            }
            return null;
        }

        public void MaakNieuweWerkAan(VrijwilligersWerkDTO vrijwilligersWerk)
        {
            this.vrijwilligersWerk.Add(vrijwilligersWerk);
        }

       

        public bool VerwijderWerk(int id)
        {
            VrijwilligersWerkDTO vrijwilligersWerk = HaalWerkOpId(id);
            if (vrijwilligersWerk != null)
            {
                this.vrijwilligersWerk.Remove(vrijwilligersWerk);
                return true;
            }
            return false;


        }
    }




}
