using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    public class SpriteBase
    {
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
                Rectangle = new Rectangle(new Point(Rectangle.Width, Rectangle.Height), value);
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
                Rectangle = new Rectangle(value, new Point(Rectangle.X, Rectangle.Y));
            }
        }

        public SpriteBase(Texture2D texture, Rectangle r)
        {
            Texture = texture;
            Rectangle = r;
        }

        public SpriteBase(Texture2D texture, Point size, Point location) : this(texture, new Rectangle(size, location))
        {

        }

        public void Draw(SpriteBatch sb, Color c)
        {
            sb.Draw(this.Texture, this.Rectangle, c);
        }
        public void Draw(SpriteBatch sb)
        {
            Draw(sb, Color.White);
        }
    }
}
