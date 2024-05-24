using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Crossbow:Weapon
    {
        public bool CausesStunning { get; set; }
        public bool CausesBurning { get; set; }

        public Crossbow(string name, int attackPower, bool causesStunning, bool causesBurning, int specialEffectChance)
            : base(name, attackPower, specialEffectChance)
        {
            CausesStunning = causesStunning;
            CausesBurning = causesBurning;
        }

        public override string SpecialAbility(Hero target)
        {
            string effect = null;
            if (CausesStunning && target.ThrowDice(SpecialEffectChance))
            {
                effect = "stunning";
                target.ReduceAttack(20); 
            }
            if (CausesBurning && target.ThrowDice(SpecialEffectChance))
            {
                effect = "burning";
                target.TakeDamage(15);
            }
            return effect;
        }
    }
}
