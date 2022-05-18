using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    public class AnimatedSprite : SpriteBase
    {
        protected int Animationcd { get; set; }
        protected List<Texture2D> Textures { get; set; }
        public int ActualTexture { get; set; }
        public AnimatedSprite(Rectangle r) : base(r)
        {
            ActualTexture = 0;
            Animationcd = 10;
        }
        public AnimatedSprite(Point location, Point size) : this(new Rectangle(location, size))
        { }

        public void LoadTextures(List<Texture2D> textures)
        {
            if (Textures == null)
            {
                Textures = textures;
            }
            else
            {
                foreach (var item in textures)
                {
                    this.LoadTexture(item);
                }
            }
        }
        public new void LoadTexture(Texture2D texture)
        {
            if (Textures == null)
            {
                Textures = new List<Texture2D>();
            }

            Textures.Add(texture);
        }

        private int cd = 0;
        public new void Draw(SpriteBatch sb)
        {

            if (cd == Animationcd)
            {
                if (ActualTexture < Textures.Count - 1)
                {
                    ActualTexture++;
                }
                else ActualTexture = 0;
                cd = 0;
            }

            this.Texture = Textures[ActualTexture];
            base.Draw(sb);

            cd++;
        }
    }
}