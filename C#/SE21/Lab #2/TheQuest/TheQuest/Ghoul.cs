using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace TheQuest
{
    class Ghoul : Enemy
    {
        public Ghoul(Game game, Point location)
            : base(game, location, 10)
        { }
        public override void Move(Random random)
        {
            if (random.Next(1, 3) == 1 && HitPoints > 0)
            {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }
            else if (random.Next(1, 3) == 2 && HitPoints > 0)
            {
                location = Move(FindPlayerDirection(game.PlayerLocation), game.Boundaries);
            }
            else
            {
                return;
            }
            if (NearPlayer() && HitPoints > 0)
            {
                game.HitPlayer(4, random);
            }
        }
    }
}
