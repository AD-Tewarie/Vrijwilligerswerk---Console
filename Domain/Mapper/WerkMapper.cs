using Domain.Models;
using Infrastructure;
using Infrastructure.DTO;
using Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Mapper
{
    internal static class WerkMapper
    {
        private static VrijwilligersWerkRepository WerkRepo = new VrijwilligersWerkRepository();

        public static List<VrijwilligersWerk> MapToWerkLijst()
        {
            List<VrijwilligersWerk> werk = new List<VrijwilligersWerk>();
            List<VrijwilligersWerkDTO> werkDTOs = WerkRepo.HaalAlleWerkOp();

            foreach (VrijwilligersWerkDTO dto in werkDTOs) {
                werk.Add(new VrijwilligersWerk(dto.WerkId, dto.Titel, dto.Omschrijving, dto.MaxCapaciteit));
            
            }
            return werk;

        }


        public static void AddWerk(VrijwilligersWerk werk)
        {
            VrijwilligersWerkDTO vrijwilligersWerkDTO = new VrijwilligersWerkDTO(werk.WerkId, werk.Titel, werk.Omschrijving, werk.MaxCapaciteit);
            WerkRepo.MaakNieuweWerkAan(vrijwilligersWerkDTO);
        }
        
        public static VrijwilligersWerkDTO MapToDTO(VrijwilligersWerk werk)
        {
            return new VrijwilligersWerkDTO(
                werk.WerkId,
                werk.Titel,
                werk.Omschrijving,
                werk.MaxCapaciteit

                );
        
                
            
        }

        public static VrijwilligersWerk MapToVrijwilligerswerk(VrijwilligersWerkDTO dto)
        {
            return new VrijwilligersWerk(
                dto.WerkId,
                dto.Titel,
                dto.Omschrijving,
                dto.MaxCapaciteit
                );
        }

    }
}
