using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFall.Sprite.PowerUp
{
    class ScoreMultiplier : APowerUp
    {
        public ScoreMultiplier(Point location) : base(location)
        {

        }

        public override void doAction(Player p)
        {
            p.ScoreMultiplier += 1;

            Task.Delay(5000).ContinueWith(t => p.ScoreMultiplier -= 1);
        }

    }
}
