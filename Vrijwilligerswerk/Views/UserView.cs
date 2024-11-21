using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Views
{
    class UserView
    {
        private readonly IUserBeheer userBeheer;

        public UserView(IUserBeheer userBeheer)
        {
            this.userBeheer = userBeheer;
        }



        public void ToonGebruikersMenu()
        {
            Console.WriteLine("\n--- Gebruikersbeheer ---");
            Console.WriteLine("1. Bekijk alle gebruikers");
            Console.WriteLine("2. Voeg een gebruiker toe");
            Console.WriteLine("3. Verwijder een gebruiker");
            Console.WriteLine("4. Ga terug");
            Console.Write("Kies een optie: ");

            if (int.TryParse(Console.ReadLine(), out int keuze))
            {
                switch (keuze)
                {
                    case 1:
                        BekijkAlleGebruikers();
                        break;
                    case 2:
                        VoegGebruikerToe();
                        break;
                    case 3:
                        VerwijderGebruiker();
                        break;
                    case 4:
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


        public void BekijkAlleGebruikers()
        {
            var users = userBeheer.GetAllUsers();
            Console.WriteLine("Alle Gebruikers:");
            foreach (var user in users)
            {
                Console.WriteLine(user);
            }


        }

        public void VoegGebruikerToe()
        {
            Console.Write("Voer uw voornaam in: ");
            string naam = Console.ReadLine();

            Console.Write("Voer uw achternaam in: ");
            string achterNaam = Console.ReadLine();

            userBeheer.VoegGebruikerToe(naam, achterNaam);
            Console.WriteLine("Gebruiker succesvol toegevoegd.");
        }

      
        public void VerwijderGebruiker()
        {
            Console.Write("Voer de gebruiker ID in, van de gebruiker die u wilt verwijdern");
            int id = Convert.ToInt32(Console.ReadLine());
            userBeheer.VerwijderGebruiker(id);

            Console.WriteLine("Gebruiker is verwijderd");
        }



    }
}
