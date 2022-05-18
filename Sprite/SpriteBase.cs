using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    public class SpriteBase
    {
        public Vector2 Rotation { get; set; }
        protected Texture2D Texture { get; set; }
        private Rectangle Rectangle { get; set; }

        public Point Size
        {
            get
            {
                return new Point(Rectangle.Width, Rectangle.Height);
            }
            set
            {
                Rectangle = new Rectangle(new Point(Rectangle.X, Rectangle.Y), value);
            }
        }

        public Point Location
        {
            get
            {
                return new Point(Rectangle.X, Rectangle.Y);
            }
            set
            {
                Rectangle = new Rectangle(value, new Point(Rectangle.Width, Rectangle.Height));
            }
        }

        public SpriteBase(Rectangle r)
        {
            Rectangle = r;
        }

        public SpriteBase(Point size, Point location) : this(new Rectangle(size, location))
        {
            //
        }

        public void LoadTexture(Texture2D texture2D)
        {
            if (texture2D != null)
            {
                Texture = texture2D;
                Rotation = new Vector2(Texture.Width, Texture.Height);
            }
        }

        public void Draw(SpriteBatch sb, Color c)
        {
            if (Texture != null) sb.Draw(this.Texture, this.Rectangle, null, c, 0f, Rotation, SpriteEffects.None, 0f);

        }
        public void Draw(SpriteBatch sb)
        {
            Draw(sb, Color.White);
        }
    }
}