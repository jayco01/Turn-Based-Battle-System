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
            List<string> unitTypesList = new List<string>{"w", "m"};

            string unitSelected = null;
            bool isTypeFound = unitTypesList.Contains(unitSelected);
            bool isValidType = unitSelected != null && isTypeFound;

            Console.WriteLine("Choose a character class type that you would like to play.");
            Console.WriteLine("'w' for Warrior & 'm' for Mage");
            while (!isValidType) {
                unitSelected = Console.ReadLine().ToLower().Trim();
                isTypeFound = unitTypesList.Contains(unitSelected);
                isValidType = unitSelected != null && isTypeFound;
                if (!isValidType) { Console.WriteLine("Error: Please choose a valid character type."); }
            }
            Console.WriteLine();

            Console.WriteLine();
            Console.Write("Enter your Character's name: ");
            string playerName = Console.ReadLine().Trim();

            var (player, enemy) = AssignUnits(unitSelected, playerName);

            BattleManager battle = new BattleManager(player, enemy);
            battle.StartBattle();
        }


        public static (Unit, Unit) AssignUnits(string unitSelected, string playerName)
        {
            Unit player = null;
            Unit enemy = null;
            switch (unitSelected) //Assign the selected unit type to the player
            {
                case "w":
                    player = new Warrior(playerName);
                    enemy = new Mage();
                    break;
                case "m":
                    player = new Mage(playerName);
                    enemy = new Warrior();
                    break;
            }
            return (player, enemy);
        }
    }
}
