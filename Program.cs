using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Battle_System
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Unit player = new Warrior("Garen");
            Unit enemy = new Mage("Lux");
            Random random = new Random();

            while (!player.IsDead && !enemy.IsDead)
            {
                Console.WriteLine($"{player.UnitName} HP = {player.Hp}. {enemy.UnitName} HP = {enemy.Hp}");
                Console.WriteLine($"{player.UnitName}'s turn! What will you do?");
                Console.WriteLine("Type 'a' to attack, 'f' to escape, and 'h' to heal.");
                string choice = Console.ReadLine();
                bool invalidChoice = (choice == null) || ( (!choice.Equals("a", StringComparison.OrdinalIgnoreCase) && !choice.Equals("f", StringComparison.OrdinalIgnoreCase) && !choice.Equals("h", StringComparison.OrdinalIgnoreCase)) );

                while (invalidChoice)
                {
                    Console.WriteLine("You chose an invalid option. Please enter a valid option.");
                    Console.WriteLine("Type 'a' to attack, 'f' to escape, and 'h' to heal.");
                    choice = Console.ReadLine();
                    invalidChoice = (choice == null) || ((!choice.Equals("a", StringComparison.OrdinalIgnoreCase) && !choice.Equals("f", StringComparison.OrdinalIgnoreCase) && !choice.Equals("h", StringComparison.OrdinalIgnoreCase)));
                } 

                if (choice.Equals("a", StringComparison.OrdinalIgnoreCase)) 
                {
                    player.Attack(enemy);
                }
                else if (choice.Equals("f", StringComparison.OrdinalIgnoreCase))
                {
                    Console.WriteLine("You fled the fight!");
                    break;
                }
                else
                {
                    player.Heal();
                }

                if (enemy.IsDead)
                {
                    Console.WriteLine("CONGRATULATIONS! YOU WON THE FIGHT!");
                    break;
                } 

                int rand = random.Next(0, 2);

                if (rand == 0 || enemy.Hp > (enemy.MaxHp * 0.75))
                {
                    enemy.Attack(player);
                }
                else
                {
                    enemy.Heal();
                }

                if (player.IsDead)
                {
                    Console.WriteLine("You were DEFEATED!");
                    break;
                }
            }

        }
    }
}
