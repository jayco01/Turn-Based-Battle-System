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

            Console.WriteLine("Choose a character class type that you would like to play.");
            Console.WriteLine("'w' for Warrior");
            Console.WriteLine("'m' for Mage");
            string characterType = Console.ReadLine();
            bool isWarrior = characterType.Equals("w", StringComparison.OrdinalIgnoreCase);
            bool isMage = characterType.Equals("m", StringComparison.OrdinalIgnoreCase);

            Console.Write("Enter your Character's name: ");
            string playerName = Console.ReadLine();

            Unit player = null;
            Unit enemy = null;

            if (isWarrior)
            {
                player = new Warrior(playerName);
                enemy = new Mage("Lux");
            }
            else if (isMage) 
            {
                player = new Mage(playerName);
                enemy = new Warrior("Garen");
            }

            BattleManager battle = new BattleManager(player, enemy);  
        }
    }
}
