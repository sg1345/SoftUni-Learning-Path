﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PersonsInfo
{
    public class Team
    {
        private string name;
        private List<Person> firstTeam;
        private List<Person> reserveTeam;

        public Team(string name)
        {
            this.name = name;
            firstTeam = new List<Person>();
            reserveTeam = new List<Person>();
        }

        public List<Person> FirstTeam { get => firstTeam; }
        public List<Person> ReserveTeam { get => reserveTeam; }

        public void AddPlayer(Person person)
        {
            if(person.Age< 40)
            {
                firstTeam.Add(person);
                return;
            }

            reserveTeam.Add(person);
        }
    }
}
