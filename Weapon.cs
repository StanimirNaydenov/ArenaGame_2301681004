using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public interface IWeapon
    {
        string Name { get; }
        int AttackPower { get; }
        string SpecialAbility(Hero target);
    }

    public abstract class Weapon : IWeapon
    {
        public string Name { get; protected set; }
        public int AttackPower { get; protected set; }
        public int SpecialEffectChance { get; protected set; }

        public Weapon(string name, int attackPower, int specialEffectChance)
        {
            Name = name;
            AttackPower = attackPower;
            SpecialEffectChance = specialEffectChance;
        }

        public abstract string SpecialAbility(Hero target);
    }
}
