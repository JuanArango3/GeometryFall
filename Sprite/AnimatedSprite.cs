using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    public class AnimatedSprite : SpriteBase
    {
        public List<Texture2D> Textures { get; private set; }
        public int ActualTexture { get; set; }
        public AnimatedSprite(List<Texture2D> textures, Rectangle r) : base(null, r)
        {
            Textures=textures;
            ActualTexture = 0;
        }
        public AnimatedSprite(List<Texture2D> textures, Point size, Point location) : this(textures, new Rectangle(size, location))
        {}

        public new void Draw(SpriteBatch sb)
        {
            this.Texture = Textures[ActualTexture];
            base.Draw(sb);
        }
    }
}
