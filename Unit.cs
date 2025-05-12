using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Turn_Based_Battle_System
{
    internal class Unit
    {
        private int currentHp;
        private int maxHp;
        private int attackPower;
        private int healPower;
        private string unitName;
        private Random random;

        public int Hp { get { return currentHp; } }
        public string UnitName { get { return unitName; } }

        public bool IsDead { get { return currentHp <= 0; } }

        public Unit(int maxHp,  int attackPower, int healPower, string unitName)
        {
            this.maxHp = maxHp;
            //Initialize currentHP to maxHp so the unit will have full HP at the beginning
            this.currentHp = maxHp;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random();
        }

        public void Attack(Unit unitAttack)
        {
            double rng = random.NextDouble();
            rng = (rng / 2) + 0.75f; //Set the attack damage range from 75% To 125%(critical hit)
            int randDamage = (int)(attackPower * rng);
            unitAttack.TakeDamage(randDamage);
            Console.WriteLine($"{unitName} attacks {unitAttack.unitName} and deals {randDamage} damage!");
        }

        public void TakeDamage(int damage)
        {
            currentHp -= damage;

            if (IsDead) {
                Console.WriteLine($"{unitName} has been defeated!");
            }
        }

        public void Heal()
        {
            double rng = random.NextDouble();
            rng = (rng / 2) + 0.75f; //Set the heal range from 75% To 125%
            int randHeal = (int)(rng * healPower);
            //Ensure that player/enemy does not heal past their maxHP
            currentHp = ((randHeal + currentHp) > maxHp) ? maxHp : (randHeal + currentHp);
            Console.WriteLine($"{unitName} heals {randHeal}HP");
        }
    }
}
