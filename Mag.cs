using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Mag : Hero
    {
        public Mag(string name) : base(name)
        {
           
        }

        Random random = new Random();

        public override int Attack()
        {
           
            int weaponAttackPower = EquippedWeapon != null ? EquippedWeapon.AttackPower : 0;
            return ((Strength + weaponAttackPower) * random.Next(100, 151)) / 100; 
        }

        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
            if (ThrowDice(15)) 
            {
                Heal(20);
                Console.WriteLine($"{Name} used magic to heal 20 health.");
            }
        }
    }
}
