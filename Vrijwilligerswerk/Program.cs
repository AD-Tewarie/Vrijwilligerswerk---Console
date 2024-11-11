using ConsoleUI.Views;
using Domain;
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
            
            var service = new Service();
            var vrijwilligersWerkBeheer = service.GetVrijwilligersWerkBeheer();
            var registratieBeheer = service.GetRegistratieBeheer();

            var hoofdMenu = new HoofdMenu(vrijwilligersWerkBeheer, registratieBeheer);
            hoofdMenu.Toon();
        
        
        
        
        
        }

    }
}





































