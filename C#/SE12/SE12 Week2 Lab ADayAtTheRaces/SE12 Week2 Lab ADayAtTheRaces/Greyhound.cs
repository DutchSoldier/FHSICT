using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing;

namespace SE12_Week2_Lab_ADayAtTheRaces
{
    class Greyhound
    {
        public int StartingPosition;
        public int RacetrackLenght;
        public PictureBox MyPictureBox = null;
        public int Location = 0;
        public Random randomizer;

        public bool Run()
        {
            int distance = randomizer.Next(1, 6);
            Point p = MyPictureBox.Location;
            p.X += distance;
            MyPictureBox.Location = p;

            if (MyPictureBox.Location.X >= 480)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void TakeStartingPosition()
        {
            Point p = MyPictureBox.Location;
            p.X = 30;
            MyPictureBox.Location = p;
        }
    }
}