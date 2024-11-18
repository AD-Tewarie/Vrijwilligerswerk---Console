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



        private readonly UserRepository userRepository = new UserRepository();
        private readonly VrijwilligersWerkRepository werkRepository = new VrijwilligersWerkRepository();
        private readonly WerkRegistratieRepository registratieRepository = new WerkRegistratieRepository();

        

        public void RegistreerGebruikerVoorWerk(int gebruikerId, int werkId)
        {
            // Haal gebruiker op
            var gebruiker = UserMapper.MapToUser( userRepository.HaalUserOpId(gebruikerId));
            if (gebruiker == null)
            {
                throw new KeyNotFoundException("Gebruiker met opgegeven ID bestaat niet.");
            }

            // Haal vrijwilligerswerk op
            var werk = WerkMapper.MapToVrijwilligerswerk( werkRepository.HaalWerkOpId(werkId));
            if (werk == null)
            {
                throw new KeyNotFoundException("Vrijwilligerswerk met opgegeven ID bestaat niet.");
            }

            // Controleer capaciteit
            if (werk.AantalRegistraties >= werk.MaxCapaciteit)
            {
                throw new InvalidOperationException("Maximale capaciteit voor dit vrijwilligerswerk is bereikt.");
            }

            // Maak en voeg de registratie toe
            var registratie = new WerkRegistratie(werk, gebruiker, registratieRepository.GenereerNieuweId());
            registratieRepository.AddRegistratie(RegistratieMapper.MapToDTO( registratie));

            // Update aantal registraties
            werk.AantalRegistraties++;
            werkRepository.BewerkVrijwilligersWerk(WerkMapper.MapToDTO(werk));

            Console.WriteLine("Gebruiker succesvol geregistreerd voor vrijwilligerswerk.");
        }

        public void VerwijderRegistratie(int registratieId)
        {
            // Haal registratie op via de repository
            var registratie = registratieRepository.HaalRegistratieOpId(registratieId);
            if (registratie == null)
            {
                Console.WriteLine("Registratie niet gevonden.");
                return;
            }

            // Haal het gekoppelde vrijwilligerswerk op via de WerkId in de registratie
            var werk = werkRepository.HaalWerkOpId(registratieId);
            if (werk != null)
            {
                // Verminder het aantal registraties
                werk.AantalRegistraties--;
                werkRepository.BewerkVrijwilligersWerk(werk);
            }
            else
            {
                Console.WriteLine("Gekoppeld vrijwilligerswerk niet gevonden.");
            }

            // Verwijder registratie via de repository
            registratieRepository.VerwijderRegistratie(registratieId);
            Console.WriteLine("Registratie succesvol verwijderd.");
        }

        public bool IsWerkVol(int werkId)
        {
            var werk = werkRepository.HaalWerkOpId(werkId);
            if (werk == null)
            {
                throw new KeyNotFoundException("Vrijwilligerswerk met opgegeven ID bestaat niet.");
            }

            return werk.AantalRegistraties >= werk.MaxCapaciteit;
        }



    }

}
