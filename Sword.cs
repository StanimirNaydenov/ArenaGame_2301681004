using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class Sword:Weapon
    {
        public bool CausesBleeding { get; set; }
        public bool CausesFreezing { get; set; }

        public Sword(string name, int attackPower, bool causesBleeding, bool causesFreezing, int specialEffectChance)
            : base(name, attackPower, specialEffectChance)
        {
            CausesBleeding = causesBleeding;
            CausesFreezing = causesFreezing;
        }

        public override string SpecialAbility(Hero target)
        {
            string effect = null;
            if (CausesBleeding && target.ThrowDice(SpecialEffectChance))
            {
                effect = "bleeding";
                target.TakeDamage(10); // Example bleeding damage
            }
            if (CausesFreezing && target.ThrowDice(SpecialEffectChance))
            {
                effect = "freezing";
                target.ReduceAttack(10); // Example freezing effect
            }
            return effect;
        }
    }
}
