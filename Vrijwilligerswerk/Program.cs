using ConsoleUI.Views;
using Domain;
using Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleUI
{
    public class Program
    {

        static void Main(string[] args)
        {
            try
            {
                // Instantiate management classes
                var registratieBeheer = new RegistratieBeheer();
                var vrijwilligersWerkBeheer = new VrijwilligersWerkBeheer();
                var userBeheer = new UserBeheer();

                // Instantiate views with dependencies
                var registratieView = new RegistratieView(registratieBeheer);
                var vrijwilligersWerkView = new VrijwilligersWerkView(vrijwilligersWerkBeheer);
                var userView = new UserView(userBeheer);

                // Instantiate main menu with all views
                var hoofdMenu = new HoofdMenu(registratieView, vrijwilligersWerkView, userView);

                // Run the main menu
                hoofdMenu.Start();
            }
            catch (Exception ex)
            {
                Console.WriteLine($"An unexpected error occurred: {ex.Message}");
            }
        }
    }
}





































