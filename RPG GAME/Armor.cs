using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Armor
    {
        public String ArmorName { get; set; }
        public int Defense { get; set; }

        public Armor(String name, int defense)
        {
            this.ArmorName = name;
            this.Defense = defense;
        }
    }
}
