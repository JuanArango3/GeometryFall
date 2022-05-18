using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    public class SpriteBase
    {
        public Vector2 Origin { get; set; }
        protected Texture2D Texture { get; set; }
        public Rectangle Rectangle { get; set; }

        protected SpriteEffects Effects { get; set; }

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
            Effects = SpriteEffects.None;
        }

        public SpriteBase(Point location, Point size) : this(new Rectangle(location, size))
        {
            //
        }

        public void LoadTexture(Texture2D texture2D)
        {
            if (texture2D != null)
            {
                Texture = texture2D;
                Origin = new Vector2(0,0);
            }
        }

        public void Draw(SpriteBatch sb, Color c)
        {
            if (Texture != null) sb.Draw(this.Texture, this.Rectangle, null, c, 0f, Origin, Effects, 0f);
                
            
        }
        public void Draw(SpriteBatch sb)
        {
            Draw(sb, Color.White);
        }
    }
}