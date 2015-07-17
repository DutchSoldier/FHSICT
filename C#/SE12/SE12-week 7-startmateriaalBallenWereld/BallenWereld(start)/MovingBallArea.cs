using System;
using System.Collections.Generic;
using System.Text;
using System.Diagnostics;

namespace BallenWereld
{
    public class MovingBallArea
    {
        /*******data****************************************************/
        private List<MovingBall> movingBalls;

        /*******constructor*********************************************/
        /// <summary>
        /// er wordt een MovingBallArea gecreeerd met breedte width en hoogte height.
        /// </summary>
        /// <param name="width">breedte van deze MovingBallArea, groter dan 0</param>
        /// <param name="height">hoogte van deze MovingBallArea, groter dan 0</param>
        public MovingBallArea(int width, int height)
        {
            movingBalls = new List<MovingBall>();
            Width = width;
            Height = height;
        }

        /******properties***********************************************/

        /// <summary>
        /// het aantal bij deze MovingBallArea bekende MovingBalls
        /// </summary>
        public int BallCount
        {
            get
            {
                return movingBalls.Count;
            }
        }

        /// <summary>
        /// de breedte van deze MovingBallArea
        /// </summary>
        public int Width { get; private set; }

        /// <summary>
        /// de hoogte van deze MovingBallArea
        /// </summary>
        public int Height { get; private set; }

        /******methoden*************************************************/

        /// <summary>
        /// De movingBall wordt toegevoegd en geactiveerd aan deze
        /// MovingBallArea, mits deze in de MovingBallArea valt en
        /// niet met een andere actieve bal botst.
        /// </summary>
        /// <returns>true als movingBall door deze MovingBallArea is geaccepteerd,
        /// anders false </returns>
        public bool Add(MovingBall movingBall)
        {
            double straal = movingBall.Diameter / 2.0;

            //buiten BallArea?
            if ((movingBall.X - straal < 0.0) ||
                (movingBall.X + straal > Width) ||
                (movingBall.Y - straal < 0.0) ||
                (movingBall.Y + straal > Height)
               )
            {
                return false;
            }

            foreach (MovingBall mb in movingBalls)
            {
                if (mb.Collides(movingBall))
                {
                    return false;
                }
            }

            movingBall.State = MovingBallState.ACTIVE;
            movingBalls.Add(movingBall);
            return true;
        }

        /// <summary>
        /// movingBall wordt bij deze MovingBallArea afgemeld
        /// </summary>
        /// <returns>true als obj bij deze MovingBallArea bekend was, 
        /// anders false</returns>
        public bool Remove(MovingBall movingBall)
        {
            return movingBalls.Remove(movingBall);
        }

        /// <summary>
        /// alle ballen worden bij deze MovingBallArea afgemeld
        /// </summary>
        public void Clear()
        {
            movingBalls.Clear();
        }

        /// <summary>
        /// retourneert het i-e MovingBallObject dat in deze MovingBallArea bekend is;
        /// de nummering van de objecten is in volgorde dat ze bij 
        /// MovingBallArea bekend zijn geraakt;
        /// voorwaarde: 
        /// i grote of gelijk nul en kleiner dan CountMovingBalls
        /// </summary>   
        /// <returns>
        /// het i-e MovingBallObject
        /// </returns>
        public MovingBall GetMovingBall(int i)
        {
            return movingBalls[i];
        }

        /// <summary>
        /// Loopt de lijst van ballen af, verplaatst iedere actieve bal
        /// en werkt het speelveld bij met deze verplaatste bal (d.w.z.
        /// controleert op botsingen met randen en/of andere ballen).
        /// </summary>   
        public void Update(int time)
        {
            foreach (MovingBall ball in movingBalls)
            {
                if (ball.State == MovingBallState.ACTIVE)
                {
                    ball.Move(time);
                    ProcessBallMove(ball);
                }
            }
        }

        /// <summary>
        /// Verwerk het feit dat een bal verplaatst is in het veld.
        /// a) botst deze aan een van de zijkanten? Dan moet de richting aangepast. 
        ///    (hoek van inval = hoek van terugkaatsing)
        /// b) botsts boven of onder, stopt met bewegen --> toestand wordt NOT_ACTIVE
        /// c) botst met andere actieve MovingBall --> toestand wordt CRASHED
        /// </summary>
        /// <param name="movingBall">obj is actief</param>
        public void ProcessBallMove(MovingBall movingBall)
        {
            double straal = movingBall.Diameter / 2.0;

            if ((movingBall.Y + straal) > Height)
            {
                // botsing onderkant, stoppen
                movingBall.Y = Height - straal;
                movingBall.State = MovingBallState.NOT_ACTIVE;
                return;
            }
            else if ((movingBall.Y - straal) < 0.0)
            {
                // botsing bovenkant, stoppen
                movingBall.Y = straal;
                movingBall.State = MovingBallState.NOT_ACTIVE;
                return;
            }

            if ((movingBall.X + straal) > Width)
            {
                // botsing rechterzijde, richting aanpassen
                movingBall.X = Width - straal;
                movingBall.Direction = (Math.PI - movingBall.Direction);
            }
            else if ((movingBall.X - straal) < 0.0)
            {
                // botsing linkerzijde, richting aan
                movingBall.X = straal;
                movingBall.Direction = (Math.PI - movingBall.Direction);
            }

            //Verwerk botsingen met andere ballen
            ProcessBallCollisions(movingBall);
        }

        /// <summary>
        /// er wordt bepaald of bal met een andere actieve bal botst; 
        /// de positie van bal wordt aangepast dat er net geen overlap is 
        /// met andere objecten;
        /// als er een botsing heeft plaatsgevonden dan zijn beide betrokken
        /// objecten in de toestand CRASHED geraakt
        /// </summary>
        /// <param name="movingBall"></param>
        private void ProcessBallCollisions(MovingBall movingBall)
        {
            foreach (MovingBall ball in movingBalls)
            {
                if ((ball.State == MovingBallState.ACTIVE) && ball.Collides(movingBall))
                {
                    // botsing met andere actieve bal
                    // in dit geval wordt een correctie gemaakt
                    // om te zorgen dat de ballen elkaar niet ongeveer,
                    // maar precies raken.

                    // verschil in x- en y-coordinaten
                    double dx = movingBall.X - ball.X;
                    double dy = movingBall.Y - ball.Y;

                    // dist is de afstand ze elkaar precies raken,
                    // namelijk de som van de stralen
                    double dist = (movingBall.Diameter + ball.Diameter) / 2.0;

                    // factor bepalen, kwadraat schuine zijde is dx**2+dy**2
                    // kwadraat zou dist*dist moeten zijn, benodigde
                    // correctiefactor is wortel uit verhouding
                    double factor = Math.Sqrt(dist * dist / (dx * dx + dy * dy));

                    // correctie doorvoeren
                    movingBall.X = ball.X + factor * dx;
                    movingBall.Y = ball.Y + factor * dy;

                    // toestand aanpassen:
                    ball.State = MovingBallState.CRASHED;
                    movingBall.State = MovingBallState.CRASHED;
                }
            }
        }
    }
}
