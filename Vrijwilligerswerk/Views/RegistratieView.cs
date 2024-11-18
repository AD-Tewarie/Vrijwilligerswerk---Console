﻿using Domain.Interfaces;
using Domain;
using Infrastructure.DTO;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI.Views
{
    internal class RegistratieView
    {
        private readonly IRegistratieBeheer registratieBeheer;

        public RegistratieView(IRegistratieBeheer registratieBeheer)
        {
            this.registratieBeheer = registratieBeheer;
        }

        public void ToonRegistratieMenu()
        {
            Console.WriteLine("\n--- Registratiebeheer ---");
            Console.WriteLine("1. Voeg een registratie toe");
            Console.WriteLine("2. Verwijder een registratie");
            Console.WriteLine("3. Ga terug");
            Console.Write("Kies een optie: ");

            if (int.TryParse(Console.ReadLine(), out int keuze))
            {
                switch (keuze)
                {
                    case 1:
                        RegistreerGebruiker();
                        break;
                    case 2:
                        VerwijderRegistratie();
                        break;
                    case 3:
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

        public void RegistreerGebruiker()
        {
            Console.Write("Voer gebruikers-ID in: ");
            int gebruikerId = int.Parse(Console.ReadLine());

            Console.Write("Voer vrijwilligerswerk-ID in: ");
            int werkId = int.Parse(Console.ReadLine());

            registratieBeheer.RegistreerGebruikerVoorWerk(gebruikerId, werkId);
            Console.WriteLine("Gebruiker succesvol geregistreerd!");
        }

        public void VerwijderRegistratie()
        {
            Console.Write("Voer registratie-ID in om te verwijderen: ");
            int registratieId = int.Parse(Console.ReadLine());

            registratieBeheer.VerwijderRegistratie(registratieId);
            Console.WriteLine("Registratie succesvol verwijderd.");
        }

    }
}