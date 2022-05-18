using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    public enum Direction
    {
        Up, Down, Left, Right
    }
    class Player : AnimatedSprite
    {

        public Player() : base(new Point(50, 20), new Point(50, 50))
        {
            
        }

        public void Move(Direction direction, int amount, GameTime gt)
        {
            switch (direction)
            {
                case Direction.Up:
                    Location = new Point(Location.X, (int)(Location.Y - amount * gt.ElapsedGameTime.TotalMilliseconds));
                    break;
                case Direction.Down:
                    Location = new Point(Location.X, (int)(Location.Y + amount * gt.ElapsedGameTime.TotalMilliseconds));
                    break;
                case Direction.Right:
                    Location = new Point((int)(Location.X + amount * gt.ElapsedGameTime.TotalMilliseconds), Location.Y);
                    break;
                case Direction.Left:
                    Location = new Point((int)(Location.X - amount * gt.ElapsedGameTime.TotalMilliseconds), Location.Y);
                    break;
            }
        }
        public void Move(Direction direction, GameTime gt)
        {
            Move(direction, 10, gt);
        }

        
    }
}