using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace GeometryFall.Sprite
{
    class Spike : SpriteBase
    {
        public Spike(Point location, Texture2D texture) : base(location, new Point(50, 50))
        {
            LoadTexture(texture);
        }
    }
}
