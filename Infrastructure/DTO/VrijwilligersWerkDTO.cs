﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure
{
    public class VrijwilligersWerkDTO
    {
        public int WerkId { get; set; }
        public string Titel { get; set; }
        public string Omschrijving { get; set; }
        public int MaxCapaciteit { get; set; }
        public int AantalRegistraties { get; set; }


        public VrijwilligersWerkDTO(int werkId, string titel, string omschrijving, int maxCapaciteit) 
        {   
            WerkId = werkId;
            Titel = titel;
            Omschrijving = omschrijving;
            MaxCapaciteit = maxCapaciteit;
            AantalRegistraties = 0;
        }

        public bool IsBeschikbaar()
        {
            return AantalRegistraties < MaxCapaciteit;
        }

        public void AddDeelnemer()
        {
            AantalRegistraties++;
        }


    }
}
