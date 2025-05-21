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

        public int MaxHp 
        {
            get { return maxHp; }
        }
            
        public int Hp
        {
            get { return currentHp; }
        }

        public string UnitName
        {
            get { return unitName; }
        }

        public bool IsDead
        {
            get { return currentHp <= 0; }
        }

        // 
        // PROTECTED HELPERS FOR SUBCLASSES
        // 
        protected int AttackPower
        {
            get { return attackPower; }
        }

        protected int HealPower
        {
            get { return healPower; }
        }

        protected Random Rng
        {
            get { return random; }
        }

        // 
        // CONSTRUCTOR
        // 
        public Unit(int maxHp, int attackPower, int healPower, string unitName)
        {
            this.maxHp = maxHp;
            this.currentHp = maxHp;
            this.attackPower = attackPower;
            this.healPower = healPower;
            this.unitName = unitName;
            this.random = new Random();
        }

        // 
        // VIRTUAL ACTION METHODS
        // 
        public virtual void Attack(Unit target)
        {
            double roll = random.NextDouble();   
            roll = roll / 2 + 0.75;       
            int damage = (int)(attackPower * roll);

            target.TakeDamage(damage);
            Console.WriteLine($"{unitName} attacks {target.unitName} and deals {damage} damage!");
        }

        public virtual void Heal()
        {
            double roll = random.NextDouble();
            roll = roll / 2 + 0.75;         
            int amount = (int)(healPower * roll);

            currentHp = (currentHp + amount > maxHp) ? maxHp : currentHp + amount;
            Console.WriteLine($"{unitName} heals {amount} HP.");
        }

        // 
        // DAMAGE / HEAL HANDLER
        // 
        public void TakeDamage(int damage)
        {
            currentHp -= damage;

            if (IsDead)
            {
                Console.WriteLine($"{unitName} has been defeated!");
            }
        }
    }
}
