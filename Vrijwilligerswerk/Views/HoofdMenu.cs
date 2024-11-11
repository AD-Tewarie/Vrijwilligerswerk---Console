using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Views
{
    internal class HoofdMenu
    {
        private readonly IVrijwilligersWerkBeheer vrijwilligersWerkBeheer;
        private readonly IRegistratieBeheer registratieBeheer;

        // Inject services via the constructor
        public HoofdMenu(IVrijwilligersWerkBeheer vrijwilligersWerkBeheer, IRegistratieBeheer registratieBeheer)
        {
            this.vrijwilligersWerkBeheer = vrijwilligersWerkBeheer;
            this.registratieBeheer = registratieBeheer;
        }

        public void Toon()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Welkom bij het Vrijwilligerswerk platform");
                Console.WriteLine("1. Bekijk beschikbare vrijwilligerswerk");
                Console.WriteLine("2. Meld je aan voor een vrijwilligerswerk");
                Console.WriteLine("3. Bekijk gebruikers die zich hebben Aangemeld");
                Console.WriteLine("4. Voeg een vrijwilligerswerk toe");
                Console.WriteLine("5. Verwijder een vrijwilligerswerk");
                Console.WriteLine("6. Afsluiten");
                Console.Write("Maak een keuze: ");
                var keuze = Console.ReadLine();

                switch (keuze)
                {
                    case "1":
                        vrijwilligersWerkBeheer.ToonBeschikbareWerk();
                        break;

                    case "2":
                        Console.Write("\nVoer het ID van het vrijwilligerswerk in waarvoor je je wilt aanmelden: ");
                        var input = Console.ReadLine();
                        if (int.TryParse(input, out int werkId))
                        {
                            Console.Write("Voer je userID in: ");
                            var userInput = Console.ReadLine();
                            if (int.TryParse(userInput, out int userId))
                            {
                                var resultaat = registratieBeheer.MeldAanVoorWerk(werkId, userId);
                                Console.WriteLine(resultaat);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige invoer. Voer een geldig vacature-ID in.");
                        }
                        break;

                    case "3":
                        Console.Write("\nVoer het ID van het vrijwilligerswerk in waarvoor je de gebruikers wilt bekijken: ");
                        var werkIdVoorUser = Console.ReadLine();
                        if (int.TryParse(werkIdVoorUser, out int id))
                        {
                            registratieBeheer.ToonGeregistreerdeUsers(id);
                        }
                        break;

                    case "4":
                        var voegWerkToeView = new VoegWerkToeVIew(vrijwilligersWerkBeheer);
                        voegWerkToeView.Toon();
                        break;

                    case "5":  // Deleting a vacature
                        Console.Write("\nVoer het ID van het vrijwilligerswerk in die je wilt verwijderen: ");
                        var werkInput = Console.ReadLine();
                        if (int.TryParse(werkInput, out int werkIdVoorVerwijderen))
                        {
                            if (vrijwilligersWerkBeheer.VerwijderWerk(werkIdVoorVerwijderen))
                            {
                                Console.WriteLine("Vrijwilligerswerk is succesvol verwijderd.");
                            }
                            else
                            {
                                Console.WriteLine("Verwijderen mislukt. Vrijwilligerswerk niet gevonden.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("Ongeldige invoer. Voer een geldig vrijwilligerswerk-ID in.");
                        }
                        break;

                    case "6":
                        return;

                    default:
                        Console.WriteLine("Ongeldige keuze. Maak een geldige keuze.");
                        break;
                }

                Console.WriteLine("\nDruk op een toets om door te gaan...");
                Console.ReadKey();
            }
        }
    }

}

