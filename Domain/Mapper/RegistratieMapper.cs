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
    internal class RegistratieMapper
    {
        private static readonly WerkRegistratieRepository repository = new WerkRegistratieRepository();
        

        public static List<WerkRegistratie> MapToDomainList()
        {
            List<WerkRegistratie> registraties = new List<WerkRegistratie>();
            List<WerkRegistratieDTO> registratieDTOs = repository.HaalAlleRegistratiesOp();
            


            foreach (WerkRegistratieDTO dto in registratieDTOs)
            {
                var vrijwilligersWerk = WerkMapper.MapToVrijwilligerswerk(dto.VrijwilligersWerk);
                var user = UserMapper.MapToUser(dto.User);

                registraties.Add(new WerkRegistratie(vrijwilligersWerk, user, dto.registratieId));

            }
            return registraties;

        }


       

        public static WerkRegistratieDTO MapToDTO(WerkRegistratie registratie)
        {
            return new WerkRegistratieDTO(
                WerkMapper.MapToDTO(registratie.vrijwilligersWerk),
                UserMapper.MapToDTO(registratie.User),
                registratie.RegistratieId);

        }


    }
}
