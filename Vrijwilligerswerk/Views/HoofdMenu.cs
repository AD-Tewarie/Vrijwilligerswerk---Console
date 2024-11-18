using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Views
{
    internal class HoofdMenu
    {
        private readonly RegistratieView registratieView;
        private readonly VrijwilligersWerkView vrijwilligersWerkView;
        private readonly UserView userView;

        public HoofdMenu(RegistratieView registratieView, VrijwilligersWerkView vrijwilligersWerkView, UserView userView)
        {
            this.registratieView = registratieView;
            this.vrijwilligersWerkView = vrijwilligersWerkView;
            this.userView = userView;
        }

        public void Start()
        {
            bool doorgaan = true;
            while (doorgaan)
            {
                try
                {
                    Console.WriteLine("\n--- Hoofdmenu ---");
                    Console.WriteLine("1. Registratiebeheer");
                    Console.WriteLine("2. Vrijwilligerswerkbeheer");
                    Console.WriteLine("3. Gebruikersbeheer");
                    Console.WriteLine("4. Afsluiten");
                    Console.Write("Kies een optie: ");

                    if (int.TryParse(Console.ReadLine(), out int keuze))
                    {
                        switch (keuze)
                        {
                            case 1:
                                registratieView.ToonRegistratieMenu();
                                break;
                            case 2:
                                vrijwilligersWerkView.ToonVrijwilligerswerkMenu();
                                break;
                            case 3:
                                userView.ToonGebruikersMenu();
                                break;
                            case 4:
                                doorgaan = BevestigAfsluiten();
                                break;
                            default:
                                Console.WriteLine("Ongeldige keuze. Probeer opnieuw.");
                                break;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Ongeldige invoer. Voer een geldig nummer in.");
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Er is een fout opgetreden: {ex.Message}");
                }
            }
        }

        private bool BevestigAfsluiten()
        {
            Console.Write("Weet u zeker dat u wilt afsluiten? (j/n): ");
            string antwoord = Console.ReadLine()?.ToLower();
            return antwoord != "j";
        }

    }
}
