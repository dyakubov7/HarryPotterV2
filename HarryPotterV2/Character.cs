﻿using System;
using System.Collections.Generic;
using System.Text;

namespace HarryPotterV2
{
    public class Character
    {
        private string _id;
        private string name;
        private string role;
        private string house;
        private string school;
        private int __v;
        private bool ministryOfMagic;
        private bool orderOfThePhoenix;
        private bool dumbledoresArmy;
        private bool deathEater;
        private string bloodStatus;
        private string species;

        public string Id { get => _id; set => _id = value; }
        public string Name { get => name; set => name = value; }
        public string Role { get => role; set => role = value; }
        public string House { get => house; set => house = value; }
        public string School { get => school; set => school = value; }
        public int V { get => __v; set => __v = value; }
        public bool MinistryOfMagic { get => ministryOfMagic; set => ministryOfMagic = value; }
        public bool OrderOfThePhoenix { get => orderOfThePhoenix; set => orderOfThePhoenix = value; }
        public bool DumbledoresArmy { get => dumbledoresArmy; set => dumbledoresArmy = value; }
        public bool DeathEater { get => deathEater; set => deathEater = value; }
        public string BloodStatus { get => bloodStatus; set => bloodStatus = value; }
        public string Species { get => species; set => species = value; }

    }
}
