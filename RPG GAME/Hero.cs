using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Hero
    {
        public String HeroChar { get; set; }
        public int BaseStrength { get; set; }
        public int BaseDefense { get; set; }
        public int TotalStrength { get; set; }
        public int TotalDefense { get; set; }
        public int OriginalHealth { get; set; }
        public int CurrentHealth { get; set; }
        public int GamesPlayed { get; set; }
        public int GamesWon { get; set; }
        public Weapon EquippedWeapon { get; set; }
        public Armor EquippedArmor { get; set; }
        public Armor[] ArmorBag { get; set; }
        public int ArmorBagSize { get; set; }
        public Weapon[] WeaponsBag { get; set; }
        public int WeaponBagSize { get; set; }

        public Hero(String name)
        {
            this.HeroChar = name;
            BaseStrength = 60;
            BaseDefense = 40;
            TotalStrength = BaseStrength;
            TotalDefense = BaseDefense;
            OriginalHealth = 100;
            CurrentHealth = OriginalHealth;
            GamesPlayed = 0;
            GamesWon = 0;
            ArmorBag = new Armor[10];
            ArmorBagSize = 0;
            WeaponsBag = new Weapon[10];
            WeaponBagSize = 0;
            EquippedWeapon = null;
            EquippedArmor = null;
        }

        public void ResetHero()
        {
            BaseStrength = 40;
            BaseDefense = 60;
            TotalStrength = BaseStrength;
            TotalDefense = BaseDefense;
            OriginalHealth = 100;
            CurrentHealth = OriginalHealth;


            EquippedWeapon = null;
            EquippedArmor = null;
        }

        public void ShowStats()
        {
            String stat = "Statisticsof the Hero:\n Games Played: " + GamesPlayed + "\n Games won: " + GamesWon + "\n";

            Console.WriteLine(stat);
        }

        public void CreateInventory()
        {
            String inventory = "Inventory:\n Equip Weapon Available:\n";

            for (int i = 0; i < WeaponBagSize; i++)
            {
                inventory += "" + WeaponsBag[i].WeaponName + "\n";
            }

            inventory += "Equip armor Available:\n";

            for (int i = 0; i < ArmorBagSize; i++)
            {
                inventory += "" + ArmorBag[i].ArmorName + "\n";
            }

            Console.WriteLine(inventory);
        }
        public void ChooseWeapon(Weapon newWeapon)
        {
            this.EquippedWeapon = newWeapon;
            TotalStrength += EquippedWeapon.Damage;
            Console.WriteLine(EquippedWeapon.WeaponName+ " Was sucessfully Equip by the Hero.and total strength now: " + TotalStrength);
        }

        public void ChooseArmor(Armor newArmor)
        {
            this.EquippedArmor = newArmor;
            TotalDefense += EquippedArmor.Defense;
            Console.WriteLine(EquippedArmor.ArmorName + " Was sucessfully Equip by the Hero.and total Defence now: "+ TotalDefense);
        }

    }
}
