using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Weapon
    {
        public String WeaponName { get; set; }
        public int Damage { get; set; }

        public Weapon(String name, int damage)
        {
            this.WeaponName = name;
            this.Damage = damage;
        }
    }
}
