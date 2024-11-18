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
            Console.WriteLine("1. Voeg een gebruiker toe");
            Console.WriteLine("2. Ga terug");
            Console.Write("Kies een optie: ");

            if (int.TryParse(Console.ReadLine(), out int keuze))
            {
                switch (keuze)
                {
                    case 1:
                        VoegGebruikerToe();
                        break;
                    case 2:
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




        public void VoegGebruikerToe()
        {
            Console.Write("Voer gebruikersnaam in: ");
            string naam = Console.ReadLine();
            int id = userBeheer.GenereerId();

            userBeheer.VoegGebruikerToe(id, naam);
            Console.WriteLine("Gebruiker succesvol toegevoegd.");
        }

      



    }
}
