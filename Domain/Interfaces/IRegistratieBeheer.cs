using Domain.Models;
using Infrastructure.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Interfaces
{
    public interface IRegistratieBeheer
    {
        void RegistreerGebruikerVoorWerk(int userId, int werkId);
        bool IsWerkVol(int werkId);
        void VerwijderRegistratie(int registratieId);
    }
}
