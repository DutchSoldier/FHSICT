using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace BallenWereld
{
    public partial class BallenWereldForm : Form
    {
        public MovingBallArea balls;
        public BallenWereldForm()
        {
            balls = new MovingBallArea(493,422);
            InitializeComponent();
            timer1.Start();
        }

        private void bNieuw_Click(object sender, EventArgs e)
        {
            Random random = new Random();
            double diameter = random.Next(10, 60);
            double x = random.Next(0,ClientRectangle.Width- Convert.ToInt32( diameter));
            double y = random.Next(0, ClientRectangle.Height - Convert.ToInt32(diameter)-50);
            
            double velocity = random.Next(1,100);
            double direction = random.Next(-180, 180);
            MovingBall ball = new MovingBall(x,y,diameter, velocity, direction);
            ball.State = MovingBallState.ACTIVE;
            balls.Add(ball);
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            balls.Update(50);
            Refresh();
        }

        private void BallenWereldForm_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            Pen rodePen = new Pen(Color.Red,1);
            g.DrawRectangle(rodePen,0,0,ClientRectangle.Width -1, ClientRectangle.Height -50);


            for (int i = 0; i < balls.BallCount; i++)
            {
                MovingBall b = balls.GetMovingBall(i);
                
                if (b.State == MovingBallState.ACTIVE)
                {

                    g.FillEllipse(Brushes.Blue, Convert.ToInt32(b.X) - (int)b.Diameter / 2, Convert.ToInt32(b.Y) - (int)b.Diameter / 2, Convert.ToInt32(b.Diameter), Convert.ToInt32(b.Diameter));
                }

                else if (b.State == MovingBallState.NOT_ACTIVE || b.State == MovingBallState.CRASHED)
                {
                    b.teller++;
                    if (b.teller >= 20)
                    {
                        b.Diameter--;

                        if (b.Diameter <= 5)
                        {
                            balls.Remove(b);
                        }
                    }
                    g.DrawEllipse(Pens.Red, Convert.ToInt32(b.X) - (int)b.Diameter / 2, Convert.ToInt32(b.Y) - (int)b.Diameter / 2, Convert.ToInt32(b.Diameter), Convert.ToInt32(b.Diameter));
                }
            }
            lBallen.Text = "Er zijn nu " + balls.BallCount + " bal(len) in het spel.";
        }
    }
}
