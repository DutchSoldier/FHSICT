using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace SE12_Week2_Lab_ADayAtTheRaces
{
    public partial class Form1 : Form
    {
        Guy[] guys;
        Greyhound[] dogs;

        Random random = new Random();

        public Form1()
        {
            InitializeComponent();
            guys = new Guy[3];
            guys[0] = new Guy() { Name = "Joe", Cash = 50, MyRadioButton = rbJoe, MyLabel = lJoesBet };
            guys[1] = new Guy() { Name = "Bob", Cash = 75, MyRadioButton = rbBob, MyLabel = lBobsBet };
            guys[2] = new Guy() { Name = "Al", Cash = 45, MyRadioButton = rbAl, MyLabel = lAlsBet };

            dogs = new Greyhound[4];
            dogs[0] = new Greyhound() { Location = 0, MyPictureBox = pbDog1, RacetrackLenght = pbRaceTrack.Width, StartingPosition = 0, randomizer = random };
            dogs[1] = new Greyhound() { Location = 0, MyPictureBox = pbDog2, RacetrackLenght = pbRaceTrack.Width, StartingPosition = 0, randomizer = random };
            dogs[2] = new Greyhound() { Location = 0, MyPictureBox = pbDog3, RacetrackLenght = pbRaceTrack.Width, StartingPosition = 0, randomizer = random };
            dogs[3] = new Greyhound() { Location = 0, MyPictureBox = pbDog4, RacetrackLenght = pbRaceTrack.Width, StartingPosition = 0, randomizer = random };
        }

        private void bBet_Click(object sender, EventArgs e)
        {
            if (rbJoe.Checked == true)
            {
                guys[0].PlaceBet(Convert.ToInt32(numBucks.Value), Convert.ToInt32(numDogs.Value));
                guys[0].UpdateLabels();
            }
            else if (rbBob.Checked == true)
            {
                guys[1].PlaceBet(Convert.ToInt32(numBucks.Value), Convert.ToInt32(numDogs.Value));
                guys[1].UpdateLabels();
            }
            else if (rbAl.Checked == true)
            {
                guys[2].PlaceBet(Convert.ToInt32(numBucks.Value), Convert.ToInt32(numDogs.Value));
                guys[2].UpdateLabels();
            }
        }

        private void bRace_Click(object sender, EventArgs e)
        {
            bRace.Enabled = false;
            bBet.Enabled = false;

            dogs[0].TakeStartingPosition();
            dogs[1].TakeStartingPosition();
            dogs[2].TakeStartingPosition();
            dogs[3].TakeStartingPosition();

            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (dogs[0].Run() == false && dogs[1].Run() == false && dogs[2].Run() == false && dogs[3].Run() == false)
            {
            }
            else
            {
                timer1.Stop();

                int winner = 479;
                int dog = 0;

                for (int i = 0; i <= 3; i++)
                {
                    if (dogs[i].MyPictureBox.Location.X > winner)
                    {
                        winner = dogs[i].MyPictureBox.Location.X;
                        dog = i + 1;

                        for (int j = 0; j <= 2; j++)
                        {
                            guys[j].Collect(dog);
                            guys[j].ClearBet();
                            guys[j].UpdateLabels();
                        }
                    }
                }

                MessageBox.Show("We have a winner - dog #" + dog + "!");

                bBet.Enabled = true;
                bRace.Enabled = true; 
            }
        }

        private void rbJoe_CheckedChanged(object sender, EventArgs e)
        {
            if (rbJoe.Checked == true)
            {
                lCurrentBidder.Text = "Joe";
            }
        }

        private void rbBob_CheckedChanged(object sender, EventArgs e)
        {
            if (rbBob.Checked == true)
            {
                lCurrentBidder.Text = "Bob";
            }
        }

        private void rbAl_CheckedChanged(object sender, EventArgs e)
        {
            if (rbAl.Checked == true)
            {
                lCurrentBidder.Text = "Al";
            }
        }
    }
}
