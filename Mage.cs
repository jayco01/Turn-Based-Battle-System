using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Battle_System
{
    internal class Mage : Unit
    {
        public Mage(string name) : base(100, 17, 25, name) { }

        public override void Attack(Unit target)
        {
            // Mages have 35% chance to double cast and 15% chance to triple cast 
            double castChance = Rng.NextDouble();
            int castCount = 0;
            int damage = 0;
            
            double roll = Rng.NextDouble();
            roll = roll / 2 + 0.75;

            int baseAttack = (int)(AttackPower * roll);
            // The attackpower of each spell decline as the cast count increase
            if (castChance < 0.15)
            {
                castCount = 3;
                damage = (int)(baseAttack * 0.60) * castCount;
            }
            else if (castChance < 0.50)
            {
                castCount = 2;
                damage = (int)(baseAttack * 0.70) * castCount;
            }
            else
            {
                castCount = 1;
                damage = baseAttack;
            }

            //int damage = (int)(AttackPower * castCount);
            target.TakeDamage(damage);
            Console.WriteLine((castCount > 1) ? $"{UnitName} casted {castCount} attack spells, dealing {damage} damage on {target.UnitName}" : $"{UnitName} casted an attack spell, dealing {damage} damage on {target.UnitName}");
        }

    }
}
