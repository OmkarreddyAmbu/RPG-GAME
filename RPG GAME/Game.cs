using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Game
    {
        public Monster Monster1 = new Monster("Dragon King", 45, 10);
        public Monster Monster2 = new Monster("Khali", 30, 70);
        public Monster Monster3 = new Monster("Battle Dog", 60, 20);

        public Monster[] monsterList = { new Monster("Dragon King", 45, 10), new Monster("Khali", 30, 70), new Monster("Battle Dog", 60, 20) };

        public Weapon[] WeaponList = { new Weapon("Sward", 10), new Weapon("Time Bomb", 25), new Weapon("Machine Gun", 35) };
        public Armor[] ArmorList = { new Armor("Gold Armor", 10), new Armor("Platinum Armor", 25), new Armor("Silver Armor", 35) };

        public Hero human = new Hero("Player");


        public void StartGame()
        {
            FillWeaponAndArmor();
            Fight NewFight = new Fight(human, Monster2);

            Console.WriteLine("Please enter Any name to create a Hero:");
            String UserInput = Console.ReadLine().ToString();
            human.HeroChar = UserInput;

            while (UserInput != "4")
            {
                Console.WriteLine("Main Menu\n Please Pick A Number To Proceed\n 1 - Statistics\n 2 - Inventory\n 3 - StartFight!..\n 4 - Quit RPG");
                bool ValidInput = false;
                while (ValidInput != true)
                {
                    UserInput = Console.ReadLine();

                    if (UserInput.Length > 0 && UserInput.Length < 2)
                    {
                        if (UserInput[0] >= '1' && UserInput[0] <= '4')
                        {
                            ValidInput = true;
                        }
                    }
                    if (ValidInput != true)
                    {
                        Console.WriteLine("Please enter a number only:");
                    }

                }

                if (ValidInput == true)
                {
                    if (UserInput[0] == '1')
                    {
                        human.ShowStats();
                    }
                    else if (UserInput[0] == '2')
                    {
                        human.CreateInventory();
                    }
                    else if (UserInput[0] == '3')
                    {
                        Console.WriteLine("Please enter a number to pick monstar:");
                        for (int i = 0; i < monsterList.Length; i++)
                        {
                            Console.WriteLine(i + " - " + monsterList[i].MonsterChar);
                        }

                        bool valid = false;

                        while (valid != true)
                        {
                            UserInput = Console.ReadLine();
                            if (UserInput.Length > 0 && UserInput.Length < 2)
                            {
                                if (UserInput[0] >= '0' && UserInput[0] <= '2')
                                {
                                    valid = true;
                                }

                            }
                            if (valid != true)
                            {
                                Console.WriteLine("Please eneter a valid number");
                            }

                        }

                        if (valid == true)
                        {
                            if (UserInput[0] == '0')
                            {
                                NewFight.PlayingMonster = Monster1;
                            }
                            else if (UserInput[0] == '1')
                            {
                                NewFight.PlayingMonster = Monster2;
                            }
                            else if (UserInput[0] == '2')
                            {
                                NewFight.PlayingMonster = Monster3;
                            }
                            NewFight.PlayFight();

                        }
                    }

                }
            }



        }

        public void FillWeaponAndArmor()
        {
            human.ArmorBagSize = ArmorList.Length;
            human.WeaponBagSize = WeaponList.Length;

            for (int j = 0; j < 3; j++)
            {
                human.ArmorBag[j] = ArmorList[j];
                human.WeaponsBag[j] = WeaponList[j];
            }

        }
    }
}
