using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Battle_System
{
    internal class Mage : Unit
    {
        public Mage(string name) : base(100, 15, 15, name) { }

        public override void Attack(Unit target)
        {
            // Mages have 25% chance to double cast and 15% chance to triple cast 
            double castChance = Rng.NextDouble();
            int castCount = 0;

            if (castChance < 0.15)
            {
                castCount = 3;
            }
            else if (castChance < 0.25)
            {
                castCount = 2;
            }
            else
            {
                castCount = 1;
            }

            int damage = (int)(AttackPower * castCount);
            target.TakeDamage(damage);
            Console.WriteLine((castCount > 1) ? $"{UnitName} casted {castCount} attack spells, dealing {damage} damage on {target.UnitName}" : $"{UnitName} casted an attack spell, dealing {damage} damage on {target.UnitName}");
        }
    }
}
