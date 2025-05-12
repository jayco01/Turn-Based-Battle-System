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
            Unit player = new Unit(100, 20, 12, "Player Warrior");
            Unit enemy = new Unit(75, 10, 25, "Enemy Mage");

            Console.WriteLine("Player turn! What will you do?");
            string choice = Console.ReadLine();

            if (choice.Equals("a", StringComparison.OrdinalIgnoreCase)) {
                player.Attack(enemy);
            } 
        }
    }
}
