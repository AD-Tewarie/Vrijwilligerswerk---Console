using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastructure.DTO;

namespace Infrastructure.Repos
{
    public class WerkRegistratieRepository
    {
        private readonly List<WerkRegistratieDTO> werkRegistraties;
        private readonly VrijwilligersWerkRepository vrijwilligersWerkRepo = new VrijwilligersWerkRepository();



        public WerkRegistratieRepository()
        {

            UserRepository userRepository = new UserRepository();


            werkRegistraties = new List<WerkRegistratieDTO>
            {
                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(1), userRepository.HaalUserOpId(1) , 1),
                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(1), userRepository.HaalUserOpId(2) , 2),
                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(1), userRepository.HaalUserOpId(3), 3),
                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(1), userRepository.HaalUserOpId(4), 4),
                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(1), userRepository.HaalUserOpId(5), 5),


                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(2), userRepository.HaalUserOpId(2) , 6),
                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(2), userRepository.HaalUserOpId(4) , 7),
                new WerkRegistratieDTO(vrijwilligersWerkRepo.HaalWerkOpId(2), userRepository.HaalUserOpId(6), 8),


               
            };

            UpdateAantalRegistraties();



        }

        public void UpdateAantalRegistraties()
        {
            
            foreach (var werk in vrijwilligersWerkRepo.HaalAlleWerkOp())
            {
                werk.AantalRegistraties = 0;
            }

            
            foreach (var registratie in werkRegistraties)
            {
                var werk = vrijwilligersWerkRepo.HaalWerkOpId(registratie.VrijwilligersWerk.WerkId);
                if (werk != null)
                {
                    werk.AantalRegistraties++;
                }
            }
        }

        public void AddRegistratie(WerkRegistratieDTO registratie)
        {
            werkRegistraties.Add(registratie);
            UpdateAantalRegistraties();
        }



        public List<WerkRegistratieDTO> HaalAlleRegistratiesOp()
        {
            return werkRegistraties;
        }

    


        public void VerwijderRegistratie(int registratieId)
        {
            for (int i = 0; i < werkRegistraties.Count; i++)
            {

                if (werkRegistraties[i].registratieId == registratieId)
                {
                    werkRegistraties.RemoveAt(i);
                }


            }



        }

        public int GenereerNieuweId()
        {
            int maxId = 0;
            foreach (var registratie in werkRegistraties)
            {
                if (registratie.registratieId > maxId)
                {
                    maxId = registratie.registratieId;
                }
            }
            return maxId + 1;
        }

        public object HaalRegistratieOpId(int registratieId)
        {
            for (int i = 0; i < werkRegistraties.Count; i++)
            {
                if (werkRegistraties[i].registratieId == registratieId)
                {
                    return werkRegistraties[i];
                }

            }
            return null;
        }
    }
}
