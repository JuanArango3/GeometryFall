using GeometryFall.Sprite;
using GeometryFall.Sprite.PowerUp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeometryFall
{
    class PowerUpController
    {
        private Texture2D velocityTexture;
        private List<APowerUp> powerUps;
        public PowerUpController()
        {
            powerUps = new List<APowerUp>();
        }

        public void LoadAssets(ContentManager cm)
        {
            velocityTexture = cm.Load<Texture2D>("pu_speed");
        }


        public void spawnVelocityPowerUp(Point p)
        {
            Velocity vpu=new Velocity(p);
            vpu.LoadTexture(velocityTexture);
            powerUps.Add(vpu);
        }

        public void draw(SpriteBatch sb)
        {
            powerUps.ForEach(powerup => {
                powerup.Draw(sb);
            });
        }

        public void checkColisions(Player p)
        {

            for (int i = 0; i < powerUps.Count; i++)
            {
                APowerUp pw = powerUps[i];

                if (p.Rectangle.Intersects(pw.Rectangle))
                {
                    pw.pickUp(p);
                    powerUps.RemoveAt(i);
                }
            }

            
        }
    }
}
