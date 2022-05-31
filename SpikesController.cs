using GeometryFall.Sprite;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFall
{
    class SpikesController
    {
        private Texture2D texture2D;
        private List<Spike> spikes;

        public SpikesController()
        {
            spikes = new List<Spike>();
        }

        public void setTexture(Texture2D texture)
        {
            texture2D = texture;
        }

        public void generateSpikes(Point initialLoc, int amount)
        {
            int x = initialLoc.X, y = initialLoc.Y;
            for (int i = 0; i < amount; i++)
            {
                spikes.Add(new Spike(new Point(x, y), texture2D));
                x += 48;
            }
        }

        public void Draw(SpriteBatch sb)
        {
            spikes.ForEach((spike)=>spike.Draw(sb));
        }

        public bool checkColision(Player p)
        {
            foreach (var spike in spikes) if (p.Rectangle.Intersects(spike.Rectangle)) return true;
            return false;
        }
    }
}
