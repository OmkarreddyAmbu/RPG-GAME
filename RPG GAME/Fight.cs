using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RPG_Game
{
    internal class Fight
    {
        public Hero PlayingHero { get; set; }
        public Monster PlayingMonster { get; set; }
        bool GameOver { get; set; }

        public Fight(Hero hero, Monster monster)
        {
            this.PlayingHero = hero;
            this.PlayingMonster = monster;
            GameOver = false;

        }

        public void PlayFight()
        {
            GameOver = false;
            Console.WriteLine("Match between Hero: " + PlayingHero.HeroChar + " VS Monster: " + PlayingMonster.MonsterChar);
            int counter = 0;
            while (GameOver == false)
            {
                if (counter % 2 == 0)
                {
                    heroTurn();

                }
                else
                {
                    MonsterTurn();
                }

                String MonsterHealth = "Monster Health: ";
                String HeroHealth = "Hero health: ";

                if (PlayingMonster.CurrentHealth < 0)
                {
                    MonsterHealth += "0";
                }
                else
                {
                    MonsterHealth += "" + PlayingMonster.CurrentHealth;
                }

                if (PlayingHero.CurrentHealth < 0)
                {
                    HeroHealth += "0";
                }
                else
                {
                    HeroHealth += "" + PlayingHero.CurrentHealth;
                }

                Console.WriteLine(MonsterHealth + " " + HeroHealth);

                if (PlayingHero.CurrentHealth <= 0 || PlayingMonster.CurrentHealth <= 0)
                {
                    GameOverMessage();
                    GameOver = true;

                }

                counter++;
            }
        }

        public void GameOverMessage()
        {

            if (PlayingHero.CurrentHealth <= 0)
            {
                PlayingHero.GamesPlayed++;

                Console.WriteLine("Monster won!...");
            }
            else if (PlayingMonster.CurrentHealth <= 0)
            {
                PlayingHero.GamesPlayed++;
                PlayingHero.GamesWon++;

                Console.WriteLine("Hero won!....");
            }
            PlayingHero.ResetHero();
            PlayingMonster.CurrentHealth = PlayingMonster.OriginalHealth;
            Console.WriteLine("\n Retunning to the main menu.....");
        }

        public void heroTurn()
        {
            Console.WriteLine("\n Now Hero's turn: \n Please choose a valid number:\n0 - Attack monster");
            int OptionNum = 1;
            bool optionsAvailable = false;

            if (PlayingHero.EquippedWeapon == null)
            {
                optionsAvailable = true;
                Console.WriteLine(OptionNum + " - Equip weapon");
                OptionNum++;
            }

            if (PlayingHero.EquippedArmor == null)
            {
                optionsAvailable = true;
                Console.WriteLine(OptionNum + " - Equip armor");
            }

            bool ValidInput = false;

            String UserInput = "";
            while (ValidInput != true)
            {
                UserInput = Console.ReadLine();


                if (UserInput.Length > 0 && UserInput.Length < 2)
                {
                    if (UserInput[0] >= '0')
                    {
                        if (optionsAvailable == true)
                        {
                            if (OptionNum == 1)
                            {
                                if (UserInput[0] <= '1')
                                {
                                    ValidInput = true;
                                }

                            }
                            else if (OptionNum == 2)
                            {
                                if (UserInput[0] <= '2')
                                {
                                    ValidInput = true;
                                }

                            }
                        }
                        else
                        {
                            ValidInput = true;
                        }

                    }
                }
                if (ValidInput != true)
                {
                    Console.WriteLine("Choose a valid number:");
                }

            }

            if (ValidInput == true)
            {
                int ChosenOption = int.Parse("" + UserInput[0]);
                if (ChosenOption == 0)
                {
                    int TotalHit = Math.Abs(PlayingMonster.Defense - PlayingHero.TotalStrength);
                    Console.WriteLine("Hero does " + TotalHit + " Damage to monster");
                    PlayingMonster.CurrentHealth = PlayingMonster.CurrentHealth - TotalHit;

                }
                else if (ChosenOption == 1)
                {
                    if (OptionNum == 2)
                    {
                        SelectWeaponInventory();

                    }
                    else if (OptionNum == 1)
                    {
                        SelectArmorInventory();

                    }
                }
                else if (ChosenOption == 2)
                {
                    SelectArmorInventory();

                }

            }

        }

        public void SelectArmorInventory()
        {
            bool ValidInput = false;
            String UserInput = "";

            Console.WriteLine("Choose a valid number for selecting Armor:");
            for (int i = 0; i < PlayingHero.ArmorBagSize; i++)
            {
                Console.WriteLine(i + " - " + PlayingHero.ArmorBag[i].ArmorName);
            }

            while (ValidInput != true)
            {
                UserInput = Console.ReadLine();

                if (UserInput.Length > 0 && UserInput.Length < 2)
                {
                    if (UserInput[0] >= '0' && UserInput[0] <= '2')
                    {
                        ValidInput = true;
                    }
                }
                if (ValidInput != true)
                {
                    Console.WriteLine("please eneter a valid number:");
                }

            }

            if (ValidInput == true)
            {
                int index = int.Parse("" + UserInput[0]);
                PlayingHero.ChooseArmor(PlayingHero.ArmorBag[index]);
            }

        }

        public void SelectWeaponInventory()
        {
            bool ValidInput = false;
            String UserInput = "";

            Console.WriteLine("please enter a valid number to choose weapon");
            for (int k = 0; k < PlayingHero.WeaponBagSize; k++)
            {
                Console.WriteLine(k + " - " + PlayingHero.WeaponsBag[k].WeaponName);
            }

            while (ValidInput != true)
            {
                UserInput = Console.ReadLine();

                if (UserInput.Length > 0 && UserInput.Length < 2)
                {
                    if (UserInput[0] >= '0' && UserInput[0] <= '2')
                    {
                        ValidInput = true;
                    }
                }
                if (ValidInput != true)
                {
                    Console.WriteLine("please eneter a valid number:");
                }

            }

            if (ValidInput == true)
            {
                int index = int.Parse("" + UserInput[0]);
                PlayingHero.ChooseWeapon(PlayingHero.WeaponsBag[index]);
            }

        }

        public void MonsterTurn()
        {
            Console.WriteLine("\n Now monster's turn:");

            int TotalHit = Math.Abs(PlayingHero.TotalDefense - PlayingMonster.Strength);
            Console.WriteLine("Monsterdoes " + TotalHit + " Damage  to Hero");
            PlayingHero.CurrentHealth = PlayingHero.CurrentHealth - TotalHit;

        }
    }
}
