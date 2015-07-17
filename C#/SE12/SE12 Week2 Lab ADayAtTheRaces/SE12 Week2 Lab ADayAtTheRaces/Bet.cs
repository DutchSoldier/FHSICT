using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SE12_Week2_Lab_ADayAtTheRaces
{
    class Bet
    {
        public int Amount;
        public int Dog;
        public Guy Bettor;

        public string GetDescription()
        {
            if (Amount == 0)
            {
                return Bettor + " hasn't placed a bet.";
            }
            else
            {
                return Bettor + " bets " + Amount + " on dog #" + Dog;
            }
        }

        public int PayOut(int Winner)
        {
            if (Dog == Winner)
            {
                return Amount;
            }
            else
            {
                return -Amount;
            }
        }
    }
}
