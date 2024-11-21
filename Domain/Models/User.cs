﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Models
{
    public class User
    {
        

        private int userId { get; set; }
        private string naam { get; set; }

        private string achterNaam { get; set; }


        public User(int userId, string naam, string achternaam)
        {
            this.userId = userId;
            this.naam = naam;
            this.achterNaam = achternaam;
        }


        public int UserId
        {
            get { return userId; }
            set { userId = value; }
        }

        public string Naam
        {
            get { return naam; }
            set { naam = value; }
        }

        public string AchterNaam
        {
            get { return achterNaam; }
            set { achterNaam = value; }
        }

    }
}
