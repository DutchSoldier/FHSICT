using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Diagnostics;

namespace TopSecret2
{
    class Collision
    {
        public string checkPlayerLevelCollision(PlayerAnimations animation, Player player, Level level)
        {
            string collision = "";
            foreach (Rectangle rectangle in level.levelRec)
            {
                if (player.playerRecRight.Intersects(rectangle))
                {
                    collision += "Right";
                }

                if (player.playerRecLeft.Intersects(rectangle))
                {
                    collision += "Left";
                }

                if (player.playerRecBottom.Intersects(rectangle))
                {
                    collision += "Bottom";
                }
            }
            return collision;
        }

        public string checkEnemyLevelCollision(Enemy enemy, Level level)
        {
            string collision = "";
            foreach (Rectangle rectangle in level.levelRec)
            {
                if (enemy.enemyRecRight.Intersects(rectangle))
                {
                    collision += "Right";
                }

                if (enemy.enemyRecLeft.Intersects(rectangle))
                {
                    collision += "Left";
                }

                if (enemy.enemyRecBottom.Intersects(rectangle))
                {
                    collision += "Bottom";
                }
            }
            return collision;
        }

        public bool checkIfPlayerHitEnemy(Enemy enemy, Player player)
        {
            if (player.playerRec.Intersects(enemy.enemyRec))
            {
                return true;
            }
            return false;
        }

        public bool checkIfEnemyHitPlayer(Enemy enemy, Player player)
        {
            if (enemy.enemyRec.Intersects(player.playerRec))
            {
                return true;
            }
            return false;
        }

        public int CheckEventCollision(Level level, Player player)
        {
            for (int i = 0; i < level.eventRec.Count; i++)
            {
                if (player.playerRecRight.Intersects(level.eventRec[i]))
                {
                    Rectangle r = level.eventRec[i];
                    r.Y = 5000;
                    level.eventRec[i] = r;
                    return i;
                }
            }
            return -1;
        }

        public int CheckObjectCollision(Level level, Player player)
        {
            for (int i = 0; i < level.objectRec.Count; i++)
            {
                if (player.playerRecRight.Intersects(level.objectRec[i]))
                {
                    Rectangle r = level.objectRec[i];
                    r.Y = 5000;
                    level.objectRec[i] = r;
                    return i;
                }
            }
            return -1;
        }

        public int CheckDamageCollision(Level level, Player player)
        {
            for (int i = 0; i < level.damageRec.Count; i++)
            {
                if (player.playerRecBottom.Intersects(level.damageRec[i]))
                {
                    return i;
                }
            }
            return -1;
        }
    }
}
