using Domain.Interfaces;
using Domain;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace ConsoleUI.Views
{
    internal class VrijwilligersWerkView
    {
        private readonly IVrijwilligersWerkBeheer vrijwilligersWerkBeheer;

        public VrijwilligersWerkView(IVrijwilligersWerkBeheer vrijwilligersWerkBeheer)
        {
            this.vrijwilligersWerkBeheer = vrijwilligersWerkBeheer;
        }


        public void ToonVrijwilligerswerkMenu()
        {
            Console.WriteLine("\n--- Vrijwilligerswerkbeheer ---");
            Console.WriteLine("1. Bekijk alle vrijwilligerswerk");
            Console.WriteLine("2. Voeg vrijwilligerswerk toe");
            Console.WriteLine("3. Bewerk vrijwilligerswerk");
            Console.WriteLine("4. Verwijder vrijwilligerswerk");
            Console.WriteLine("5. Ga terug");
            Console.Write("Kies een optie: ");

            if (int.TryParse(Console.ReadLine(), out int keuze))
            {
                switch (keuze)
                {
                    case 1:
                        BekijkAlleVrijwilligerswerk();
                        break;
                    case 2:
                        VoegVrijwilligersWerkToe();
                        break;
                    case 3:
                        BewerkVrijwilligersWerk();
                        break;
                    case 4:
                        VerwijderVrijwilligersWerk();
                        break;
                    case 5:
                        return;
                    default:
                        Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                        break;
                }
            }
            else
            {
                Console.WriteLine("Ongeldige invoer. Probeer opnieuw.");
            }
        }



        public void BekijkAlleVrijwilligerswerk()
        {
            var vrijwilligerswerken = vrijwilligersWerkBeheer.BekijkAlleWerk();
            Console.WriteLine("Alle beschikbare vrijwilligerswerken:");
            foreach (var werk in vrijwilligerswerken)
            {
                Console.WriteLine(werk);
            }
        }

        public void VoegVrijwilligersWerkToe()
        {
            Console.Write("Voer titel in voor het nieuwe vrijwilligerswerk: ");
            string titel = Console.ReadLine();

            Console.Write("Voer maximale capaciteit in: ");
            int maxCapaciteit = Convert.ToInt32(Console.ReadLine());

            Console.Write("Voer een beschrijving in: ");
            string beschrijving = Console.ReadLine();

            int werkId = vrijwilligersWerkBeheer.GetNieweWerkId();

            int aantalRegistraties = 0;


            VrijwilligersWerk werk = new VrijwilligersWerk(werkId ,titel, beschrijving, maxCapaciteit); 
            vrijwilligersWerkBeheer.VoegWerkToe(werk);
           
        }

        public void BewerkVrijwilligersWerk()
        {

            BekijkAlleVrijwilligerswerk();

            Console.Write("Voer het ID in van het vrijwilligerswerk dat je wilt bewerken: ");
            int werkId = int.Parse(Console.ReadLine());
            Console.ReadKey(); 
            Console.Clear(); 


            Console.Write("Voer de nieuwe titel in: ");
            string nieuweTitel = Console.ReadLine();

            Console.Write("Voer de nieuwe maximale capaciteit in: ");
            int nieuweCapaciteit = int.Parse(Console.ReadLine());

            Console.Write("Voer een nieuwe beschrijving in: ");
            string nieuweBeschrijving = Console.ReadLine();

            vrijwilligersWerkBeheer.BewerkWerk(werkId, nieuweTitel, nieuweCapaciteit, nieuweBeschrijving);
            
        }

        public void VerwijderVrijwilligersWerk()
        {
            BekijkAlleVrijwilligerswerk();

            Console.Write("Voer het ID in van het vrijwilligerswerk dat je wilt verwijderen: ");
            int werkId = int.Parse(Console.ReadLine());
            Console.ReadKey();
            Console.Clear();

            vrijwilligersWerkBeheer.VerwijderWerk(werkId);
            Console.WriteLine("Vrijwilligerswerk succesvol verwijderd.");
        }

    }
}
