using System;
using System.Drawing;

namespace BallenWereld
{
    public enum MovingBallState
    {
        ACTIVE,
        NOT_ACTIVE,
        CRASHED
    }

    public class MovingBall
    {
        // **************************** data ******************
        private double dx, dy;                      // wijziging van x en y per seconde
        private double v;                           // de snelheid
        private double phi;                         // de richting van de beweging
        public int teller = 0;

        // **************************** constructor ***********
        /// <summary>
        /// maak een bal op positie (x,y) met een diameter voor 
        /// snelheid velocity en richting direction; 
        /// </summary>
        public MovingBall(double x, double y, double diameter, double velocity, double direction)
        {
            X = x;
            Y = y;
            dx = 0.0;
            dy = 0.0;
            Velocity = velocity;
            Direction = direction;
            Diameter = diameter;
            State = MovingBallState.NOT_ACTIVE;
            
        }

        // **************************** properties ************
        /// <summary>
        /// de X coordinaat van deze bal
        /// </summary>
        public double X { get; set; }

        /// <summary>
        /// de Y coordinaat van deze bal
        /// </summary>
        public double Y { get; set; }

        /// <summary>
        /// de snelheid van dit object
        /// </summary>
        public double Velocity
        {
            get
            {
                return v;
            }

            set
            {
                v = value;
                dx = v * Math.Cos(phi);
                dy = v * Math.Sin(phi);
            }
        }

        /// <summary>
        /// In de ballenwereld ligt de oorsprong van het x,y assenstelsel 
        /// linksonder en wordt met het middelpunt van de bal gerekend.
        /// In de grafische wereld ligt de oorsprong linksboven en wordt
        /// met de linkerbovenhoek van het object gerekend.
        /// Hint: De eenheid van de hoek die de richting aangeeft is radialen en loopt van 0..(2*PI).
        ///       Zie http://en.wikipedia.org/wiki/Unit_circle
        ///        en http://en.wikipedia.org/wiki/File:Unit_circle_angles_color.svg
        /// </summary>
        public double Direction
        {
            get
            {
                return phi;
            }

            set
            {
                phi = value;
                dy = v * Math.Sin(phi);
                dx = v * Math.Cos(phi);
            }
        }

        /// <summary>
        /// de diameter van de bal
        /// </summary>
        public double Diameter { get; set; }

        /// <summary>
        /// de toestand waarin de bal zich bevindt
        /// </summary>
        public MovingBallState State { get; set; }

        // **************************** methods **************

        /// <summary>
        /// Verplaats de bal over de gepaste afstand, gegeven zijn snelheid
        /// waarvan afgeleid dx en dy, gegeven de vertreken tijd,
        /// uitgedrukt in milliseconden.
        /// </summary>
        /// <returns>void</returns>
        public void Move(int millisecondsPassed)
        {
            X += dx * millisecondsPassed / 1000.0;
            Y += dy * millisecondsPassed / 1000.0;
        }

        /// <returns>true als movingBall met deze bal botst (of als het deze bal zelf is), anders false</returns>
        public bool Collides(MovingBall movingBall)
        {
            if (movingBall == this)
            {
                return false;
            }

            double diffx = movingBall.X - X;
            double diffy = movingBall.Y - Y;

            return Math.Sqrt(diffx * diffx + diffy * diffy) <= (movingBall.Diameter + Diameter) / 2.0;
        }
    }
}