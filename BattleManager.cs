using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Battle_System
{
    internal class BattleManager
    {
        private Unit PlayerUnit { get; }
        private Unit EnemyUnit { get; }
        public bool HasPlayerFled { get; private set; }
        public BattleManager(Unit player, Unit enemy) 
        {
            this.PlayerUnit = player;
            this.EnemyUnit = enemy;
            this.HasPlayerFled = false;
        }//closes BattleManager

        public void StartBattle() 
        {
            while (!PlayerUnit.IsDead && !EnemyUnit.IsDead && !HasPlayerFled) 
            {
                Console.WriteLine($"{PlayerUnit.UnitName} HP = {PlayerUnit.Hp}. {EnemyUnit.UnitName} HP = {EnemyUnit.Hp}");
                Console.WriteLine($"{PlayerUnit.UnitName}'s turn! What will you do?");
                Console.WriteLine("Type 'a' to attack, 'f' to escape, and 'h' to heal.");
                string choice = Console.ReadLine();
                bool invalidChoice = (choice == null) || ((!choice.Equals("a", StringComparison.OrdinalIgnoreCase) && !choice.Equals("f", StringComparison.OrdinalIgnoreCase) && !choice.Equals("h", StringComparison.OrdinalIgnoreCase)));
                Random rng = new Random();

                while (invalidChoice)
                {
                    Console.WriteLine("You chose an invalid option. Please enter a valid option.");
                    Console.WriteLine("Type 'a' to attack, 'f' to escape, and 'h' to heal.");
                    choice = Console.ReadLine();
                    invalidChoice = (choice == null) || ((!choice.Equals("a", StringComparison.OrdinalIgnoreCase) && !choice.Equals("f", StringComparison.OrdinalIgnoreCase) && !choice.Equals("h", StringComparison.OrdinalIgnoreCase)));
                }

                if (choice.Equals("a", StringComparison.OrdinalIgnoreCase))
                {
                    PlayerUnit.Attack(EnemyUnit);
                }
                else if (choice.Equals("f", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("You fled the fight!");
                    break;
                }
                else
                {
                    PlayerUnit.Heal();
                }

                if (EnemyUnit.IsDead)
                {
                    Console.WriteLine("CONGRATULATIONS! YOU WON THE FIGHT!");
                    break;
                }

                int rand = rng.Next(0, 2);

                if (rand == 0 || EnemyUnit.Hp > (EnemyUnit.MaxHp * 0.75))
                {
                    EnemyUnit.Attack(PlayerUnit);
                }
                else
                {
                    EnemyUnit.Heal();
                }

                if (PlayerUnit.IsDead)
                {
                    Console.WriteLine("You were DEFEATED!");
                    break;
                }
            }//closes while loop
        }//closes StartBattle()
    }//closes class
}
