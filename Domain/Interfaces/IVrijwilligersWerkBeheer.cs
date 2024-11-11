using Domain.Models;
using Infrastructure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IVrijwilligersWerkBeheer
    {
        void VoegWerkToe(VrijwilligersWerkDTO werk);
        List<string> BekijkAlleWerk();
        void VerwijderWerk(int werkId);
    }
}
