using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE12_Week2_Lab_ADayAtTheRaces
{
    class Guy
    {
        public string Name;
        public Bet MyBet;
        public int Cash;

        public RadioButton MyRadioButton;
        public Label MyLabel;

        public void UpdateLabels()
        {
            if (MyBet != null)
            {
                MyRadioButton.Text = Name + " has " + Cash + " bucks.";
                MyLabel.Text = Name + " bets €" + MyBet.Amount + " on dog #" + MyBet.Dog;
            }
            else if (MyBet == null)
            {
                MyRadioButton.Text = Name + " has " + Cash + " bucks.";
                MyLabel.Text = Name + " hasn't placed a bet";
            }
        }

        public void ClearBet() { MyBet = null; }

        public void PlaceBet(int amount, int dog)
        {
            if (amount > Cash)
            {
                ClearBet();
                MessageBox.Show("You don't have enough money to place this bet.");
            }
            else
            {
                MyBet = new Bet() { Amount = amount, Dog = dog, Bettor = this };
            }
        }

        public void Collect(int Winner)
        {
            if (MyBet != null)
            {
                Cash = Cash + MyBet.PayOut(Winner);
            }
        }
    }
}
