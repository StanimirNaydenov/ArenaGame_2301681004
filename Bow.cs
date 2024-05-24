using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Bow : Weapon
    {
        public bool CausesPoison { get; set; }
        public bool CausesFire { get; set; }

        public Bow(string name, int attackPower, bool causesPoison, bool causesFire, int specialEffectChance)
            : base(name, attackPower, specialEffectChance)
        {
            CausesPoison = causesPoison;
            CausesFire = causesFire;
        }

        public override string SpecialAbility(Hero target)
        {
            string effect = null;
            if (CausesPoison && target.ThrowDice(SpecialEffectChance))
            {
                effect = "poison";
                target.TakeDamage(10); 
            }
            if (CausesFire && target.ThrowDice(SpecialEffectChance))
            {
                effect = "fire";
                target.TakeDamage(20); 
            }
            return effect;
        }
    }
}

