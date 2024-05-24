using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
   public abstract class Hero
   {
        public string Name { get; private set; }
        public int Health { get;  set; }
        public int Strength { get; private set; }
        protected int StartingHealth { get; private set; }
        public bool IsDead { get { return Health <= 0; } }
        public IWeapon EquippedWeapon { get; private set; }

        public Hero(string name)
        {
            Name = name;
            Health = 500;
            StartingHealth = Health;
            Strength = 100;
        }

        Random random = new Random();

        public virtual int Attack()
        {
            int weaponAttackPower = EquippedWeapon != null ? EquippedWeapon.AttackPower : 0;
            return ((Strength + weaponAttackPower) * random.Next(80, 121)) / 100;
        }

        public virtual void TakeDamage(int incomingDamage)
        {
            if (incomingDamage < 0) return;
            Health -= incomingDamage;
        }

        public void ReduceAttack(int amount)
        {
            Strength -= amount;
            if (Strength < 0) Strength = 0;
        }

        public bool ThrowDice(int chance)
        {
            int dice = random.Next(101);
            return dice <= chance;
        }

        protected void Heal(int value)
        {
            Health += value;
            if (Health > StartingHealth) Health = StartingHealth;
        }

        public void EquipWeapon(IWeapon weapon)
        {
            EquippedWeapon = weapon;
            Console.WriteLine($"{Name} equipped {weapon.Name}.");
        }

        public string UseSpecialAbility(Hero target)
        {
            if (EquippedWeapon != null)
            {
                return EquippedWeapon.SpecialAbility(target);
            }
            else
            {
                return null;
            }
        }
    }
}
