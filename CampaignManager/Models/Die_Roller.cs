using System;
using System.Collections.Generic;

namespace Die_Roller
{
    public class DiceBag
    {
        public enum Dice : uint
        {
            D4 = 4,    
            D6 = 6,   
            D8 = 8,    
            D10 = 10,  
            D12 = 12,  
            D20 = 20,  
            D100 = 100 
        };

        private Random rng;

        public DiceBag()
        {
            rng = new Random();
        }

        private int InternalRoll(uint dice)
        {
            return 1 + rng.Next((int)dice);
        }

        public int Roll(Dice d)
        {
            return InternalRoll((uint)d);
        }

        public int RollWithModifier(Dice dice, uint modifier)
        {
            return InternalRoll((uint)dice) + (int)modifier;
        }

        public List<int> RollQuantity(Dice d, uint times)
        {
            List<int> rolls = new List<int>();
            for (int i = 0; i < times; i++)
            {
                rolls.Add(InternalRoll((uint)d));
            }
            return rolls;
        }
    }
}
