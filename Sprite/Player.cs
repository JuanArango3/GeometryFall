using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace GeometryFall.Sprite
{
    class Player : AnimatedSprite
    {
        public Player(List<Texture2D> textures) :base(textures, new Point(300, 300), new Point(200, 200))
        {

        }
    }
}
