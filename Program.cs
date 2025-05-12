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
            Unit player = new Unit(100, 20, 12, "Player");
            Unit enemy = new Unit(85, 15, 20, "Enemy Mage");
            Random random = new Random();

            while (!player.IsDead || !enemy.IsDead)
            {
                Console.WriteLine($"{player.UnitName} HP = {player.Hp}. {enemy.UnitName} HP = {enemy.Hp}");
                Console.WriteLine("Player turn! What will you do?");
                Console.WriteLine("Type 'a' to attack, 'f' to escape, and 'h' to heal.");
                string choice = Console.ReadLine();

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

                if (rand == 0)
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
