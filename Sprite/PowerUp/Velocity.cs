using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GeometryFall.Sprite.PowerUp
{
    class Velocity : APowerUp
    {

        public Velocity(Point location) : base(location)
        {

        }

        public override void doAction(Player p)
        {
            p.Velocidad = p.Velocidad + 8;

            Task.Delay(5000).ContinueWith(t => p.Velocidad= p.Velocidad - 8);
        }
    }
}
