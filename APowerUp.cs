using GeometryFall.Sprite;
using Microsoft.Xna.Framework;

namespace GeometryFall
{
    abstract class APowerUp : SpriteBase
    {
        public APowerUp(Point location) : base(location, new Point(50, 50))
        {

        }
        public abstract void pickUp(Player p);
    }
}
