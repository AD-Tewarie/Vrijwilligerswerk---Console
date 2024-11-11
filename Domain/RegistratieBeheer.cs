using Domain.Interfaces;
using Domain.Mapper;
using Domain.Models;
using Infrastructure.DTO;
using Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class RegistratieBeheer : IRegistratieBeheer
    {



        private WerkRegistratieRepository registratieRepository = new WerkRegistratieRepository();
        private List<WerkRegistratie> registraties = new List<WerkRegistratie>();

        public RegistratieBeheer()
        {
            // Initialize registrations by mapping DTOs to domain models
            var registratieDTOs = registratieRepository.HaalAlleRegistratiesOp();
            foreach (var dto in registratieDTOs)
            {
                var werk = WerkMapper.MapToVrijwilligerswerk(dto.VrijwilligersWerk);
                var user = UserMapper.MapToUser(dto.User);
                registraties.Add(new WerkRegistratie(werk, user, dto.registratieId));
            }
        }

        // Methode om een gebruiker voor een vrijwilligerswerk te registreren
        public void RegistreerGebruikerVoorWerk(WerkRegistratieDTO registratieDto)
        {
            var werk = WerkMapper.MapToVrijwilligerswerk(registratieDto.VrijwilligersWerk);
            var user = UserMapper.MapToUser(registratieDto.User);

            if (werk.AantalRegistraties < werk.MaxCapaciteit)
            {
                var nieuweRegistratie = new WerkRegistratie(werk, user, registratieDto.registratieId);
                registraties.Add(nieuweRegistratie);

                // Map the WerkRegistratie to a DTO and save it to the repository
                var registratieDTO = RegistratieMapper.MapToDTO(nieuweRegistratie);
                registratieRepository.AddRegistratie(registratieDTO);

                werk.AantalRegistraties++;
                Console.WriteLine("Gebruiker succesvol geregistreerd.");
            }
            else
            {
                Console.WriteLine("Registratie mislukt: Het werk is vol.");
            }
        }

        // Methode om de capaciteit van het geselecteerde werk te bekijken
        public int BekijkCapaciteit(int werkId)
        {
            foreach (var werk in WerkMapper.MapToWerkLijst())
            {
                if (werk.WerkId == werkId)
                {
                    return werk.MaxCapaciteit;
                }
            }
            return 0;
        }

        // Methode om te controleren of het werk vol is
        public bool IsWerkVol(int werkId)
        {
            foreach (var werk in WerkMapper.MapToWerkLijst())
            {
                if (werk.WerkId == werkId)
                {
                    return werk.AantalRegistraties >= werk.MaxCapaciteit;
                }
            }
            return false;
        }

        // Methode om een registratie te verwijderen
        public void VerwijderRegistratie(int registratieId)
        {
            for (int i = 0; i < registraties.Count; i++)
            {
                if (registraties[i].RegistratieId == registratieId)
                {
                    var werk = registraties[i].vrijwilligersWerk;
                    werk.AantalRegistraties--;

                    // Map and remove from repository
                    registratieRepository.VerwijderRegistratie(registratieId);
                    registraties.RemoveAt(i);

                    Console.WriteLine("Registratie succesvol verwijderd.");
                    return;
                }
            }
            Console.WriteLine("Registratie niet gevonden.");
        }




    }

}
