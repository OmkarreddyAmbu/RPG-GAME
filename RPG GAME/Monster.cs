using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Monster
    {
        public String MonsterChar { get; set; }
        public int Strength { get; set; }
        public int Defense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }

        public Monster(String name, int strength, int defense)
        {
            this.MonsterChar = name;
            this.Strength = strength;
            this.Defense = defense;
            OriginalHealth = 100;
            CurrentHealth = OriginalHealth;
        }
    }
}
