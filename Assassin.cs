using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Assassin : Hero
    {

        public Assassin(string name) : base(name)
        {
            
        }

        Random random = new Random();
        public override int Attack()
        {
           
            int weaponAttackPower = EquippedWeapon != null ? EquippedWeapon.AttackPower : 0;
            if (ThrowDice(20))
            {
                Console.WriteLine($"{Name} performed a critical strike!");
                return ((Strength + weaponAttackPower) * random.Next(150, 201)) / 100; 
            }
            return ((Strength + weaponAttackPower) * random.Next(80, 121)) / 100;
        }

        public override void TakeDamage(int incomingDamage)
        {
            base.TakeDamage(incomingDamage);
            if (ThrowDice(10)) 
            {
                Console.WriteLine($"{Name} dodged the attack!");
                Health += incomingDamage; 
            }
        }

    }


}
