using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Battle_System
{
    internal class Warrior : Unit
    {
        public Warrior(string name) : base(120, 22, 12, name) { }

        public override void Attack(Unit target)
        {
            // Warriors have 25% chance crit
            bool crit = Rng.NextDouble() < 0.25;
            double mult = crit ? 1.5 : 1.0;

            double roll = Rng.NextDouble();
            roll = roll / 2 + 0.75;

            int baseAttack = (int)(AttackPower * roll);
            int damage = (int)(baseAttack * mult);
            target.TakeDamage(damage);
            Console.WriteLine(crit ? $"{UnitName} lands a CRITICAL slash on {target.UnitName} for {damage}" : $"{UnitName} lands a slash on {target.UnitName} for {damage}");
        }
    }
}
