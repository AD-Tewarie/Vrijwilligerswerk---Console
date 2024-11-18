using Domain.Interfaces;
using Domain.Mapper;
using Domain.Models;
using Infrastructure.Repos_DB;
using Infrastructure;
using Infrastructure.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain
{
    public class VrijwilligersWerkBeheer : IVrijwilligersWerkBeheer
    {

        private readonly VrijwilligersWerkRepository werkRepository = new VrijwilligersWerkRepository();
        private List<VrijwilligersWerk> werkLijst = new List<VrijwilligersWerk>();
       

        public VrijwilligersWerkBeheer()
        {

            var werkDTOs = werkRepository.HaalAlleWerkOp();
            foreach (var dto in werkDTOs)
            {
                werkLijst.Add(WerkMapper.MapToVrijwilligerswerk(dto));
            }
        }

        public int GetNieweWerkId()
        {
            return werkRepository.GenereerNieweWerkId();
        }

        // Methode om een nieuw werk toe te voegen
        public void VoegWerkToe(VrijwilligersWerk werk)
        {
            var nieuwWerk = werk;
            werkLijst.Add(nieuwWerk);


            var werkDTO = WerkMapper.MapToDTO(nieuwWerk);
            werkRepository.MaakNieuweWerkAan(werkDTO);

            Console.WriteLine("Nieuw vrijwilligerswerk succesvol toegevoegd.");
        }

        // Methode om alle werken te bekijken
        public List<string> BekijkAlleWerk()
        {
            
            var werkTitels = new List<string>();
            foreach (var werk in werkRepository.HaalAlleWerkOp() )
            {
                werkTitels.Add($"WerkID: {werk.WerkId}, Titel: {werk.Titel}, Omschrijving: {werk.Omschrijving}, Capaciteit: {werk.AantalRegistraties} / {werk.MaxCapaciteit} ");
            }
            return werkTitels;
        }

        // Methode om een werk te verwijderen
        public void VerwijderWerk(int werkId)
        {
            for (int i = 0; i < werkLijst.Count; i++)
            {
                if (werkLijst[i].WerkId == werkId)
                {
                    werkRepository.VerwijderWerk(werkId);
                    werkLijst.RemoveAt(i);
                    Console.WriteLine("Vrijwilligerswerk succesvol verwijderd.");
                    return;
                }
            }
            Console.WriteLine("Werk niet gevonden.");
        }




        public void BewerkWerk(int werkId, string nieuweTitel, int nieuweCapaciteit, string nieuweBeschrijving)
        {
            // Haal het bestaande vrijwilligerswerk op
            var bestaandWerk = werkRepository.HaalWerkOpId(werkId);
            if (bestaandWerk == null)
            {
                throw new KeyNotFoundException("Vrijwilligerswerk met opgegeven ID bestaat niet.");
            }

            // Voer wijzigingen door
            bestaandWerk.Titel = nieuweTitel;
            bestaandWerk.MaxCapaciteit = nieuweCapaciteit;
            bestaandWerk.Omschrijving = nieuweBeschrijving;

            werkLijst.Add(Mapper.WerkMapper.MapToVrijwilligerswerk(bestaandWerk));
            

            // Sla de wijzigingen op via de repository
            werkRepository.BewerkVrijwilligersWerk(bestaandWerk);

            Console.WriteLine("Vrijwilligerswerk succesvol bijgewerkt.");
        }

    }

}

