using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
using Microsoft.Xna.Framework.Graphics;

namespace GeometryFall.Sprite
{
    class Coin : SpriteBase
    {
        SoundEffect soundEffect;
        public Coin(Point location, Texture2D texture) : base(location, new Point(50, 50))
        {
            this.LoadTexture(texture);
        }
    }
}
