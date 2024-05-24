using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    public class BattleEvent
    {
        public Hero Attacker { get; set; }
        public Hero Defender { get; set; }
        public int Damage { get; set; }
        public string SpecialEffect { get; set; }

        public BattleEvent(Hero attacker, Hero defender, int damage, string specialEffect = null)
        {
            Attacker = attacker;
            Defender = defender;
            Damage = damage;
            SpecialEffect = specialEffect;
        }
    }

    public interface IArenaBattleListener
    {
        void OnBattleTurn(BattleEvent e);
    }

    public class Arena
    {
        public Hero HeroA { get; private set; }
        public Hero HeroB { get; private set; }
        public IArenaBattleListener BattleListener { get; set; }
        Random random = new Random();

        public Arena(Hero a, Hero b)
        {
            HeroA = a;
            HeroB = b;
        }

        public Hero Battle()
        {
            Hero attacker, defender;

            if (random.Next(2) == 0)
            {
                attacker = HeroA;
                defender = HeroB;
            }
            else
            {
                attacker = HeroB;
                defender = HeroA;
            }

            while (true)
            {
                int damage = attacker.Attack();
                defender.TakeDamage(damage);

                string specialEffect = attacker.UseSpecialAbility(defender);

                if (BattleListener != null)
                {
                    BattleEvent e = new BattleEvent(attacker, defender, damage, specialEffect);
                    BattleListener.OnBattleTurn(e);
                }

                if (defender.IsDead) return attacker;

                Hero tmp = attacker;
                attacker = defender;
                defender = tmp;
            }
        }
    }
}
