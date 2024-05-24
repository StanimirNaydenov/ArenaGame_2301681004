using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ArenaGame
{
    internal class Program
    {

        class ConsoleBattleListener : IArenaBattleListener
        {
            public void OnBattleTurn(BattleEvent e)
            {
                Console.WriteLine($"{e.Attacker.Name} attacks {e.Defender.Name} for {e.Damage} damage.");
                if (e.SpecialEffect != null)
                {
                    Console.WriteLine($"{e.Attacker.Name}'s weapon causes {e.SpecialEffect} effect on {e.Defender.Name}.");
                }

            }
        }

        static void Main(string[] args)
        {

            Hero knight = new Knight("Sir Lancelot");
            Hero rogue = new Rogue("Robin Hood");
            Hero mag = new Mag("Merlin");
            Hero assassin = new Assassin("Ezio");


            IWeapon sword = new Sword("Excalibur", 50, causesBleeding: true, causesFreezing: false, specialEffectChance: 10);
            IWeapon bow = new Bow("Longbow", 30, causesPoison: true, causesFire: false, specialEffectChance: 10);
            IWeapon crossbow = new Crossbow("Dragon Slayer", 40, causesStunning: true, causesBurning: true, specialEffectChance: 10);


            knight.EquipWeapon(sword);
            rogue.EquipWeapon(bow);
            mag.EquipWeapon(crossbow); 
            assassin.EquipWeapon(sword);

            Console.WriteLine("===================================================");

            Console.WriteLine($"Arena fight between: {mag.Name} and {assassin.Name}");
            Arena arena = new Arena(mag, assassin);
            arena.BattleListener = new ConsoleBattleListener();
            Hero winner = arena.Battle();
            Console.WriteLine($"Winner is: {winner.Name}");

            Console.WriteLine("============================================================");

            Console.WriteLine($"Arena fight between: {knight.Name} and {rogue.Name}");
            Arena arena1 = new Arena(knight, rogue);
            arena1.BattleListener = new ConsoleBattleListener();
            Hero winner1 = arena1.Battle();
            Console.WriteLine($"Winner is: {winner1.Name}");
            Console.ReadLine();
        }
    }
}
