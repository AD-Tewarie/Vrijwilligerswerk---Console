using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Views
{
    public class VoegWerkToeVIew
    {
        private readonly IVrijwilligersWerkBeheer vrijwilligersWerkBeheer;

        public VoegWerkToeVIew(IVrijwilligersWerkBeheer vrijwilligersWerkBeheer)
        {
            this.vrijwilligersWerkBeheer = vrijwilligersWerkBeheer;
        }

        public void Toon()
        {
            Console.Clear();
            Console.WriteLine("Voeg een nieuwe vrijwilligerswerk toe:");

            string titel = VraagString("Voer de titel van het vrijwilligerswerk in: ");
            string omschrijving = VraagString("Voer de omschrijving van het vrijwilligerswerk in: ");
            int maxCapaciteit = VraagCapaciteit("Voer de maximale capaciteit in: ");

            vrijwilligersWerkBeheer.VoegWerkToe(titel,omschrijving, maxCapaciteit);

            Console.WriteLine("De vacature is succesvol toegevoegd!");
        }


        private string VraagString(string vraag)
        {
            Console.WriteLine(vraag);
            return Console.ReadLine();
        }


        private int VraagCapaciteit(string vraag)
        {
            while (true)
            {
                Console.WriteLine(vraag);
                var input = Console.ReadLine();

                if(int.TryParse(input, out var capaciteit) && capaciteit > 0)
                {
                    return capaciteit;
                }

                Console.WriteLine("Ongeldige invoer. Voer een geldig getal in.");
                    
            }
        }
    }
}
