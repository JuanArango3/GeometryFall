using GeometryFall.Sprite;
using GeometryFall.Sprite.PowerUp;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;
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
        //private Texture2D velocityTexture;
        private List<Texture2D> textures;
        private List<SoundEffect> sounds;
        private List<APowerUp> powerUps;
        public PowerUpController()
        {
            textures = new List<Texture2D>();
            sounds = new List<SoundEffect>();
            powerUps = new List<APowerUp>();
        }

        public void LoadAssets(ContentManager cm)
        {
            textures.Add( cm.Load<Texture2D>("pu_speed"));
            textures.Add( cm.Load<Texture2D>("pu_x2") );
            sounds.Add( cm.Load<SoundEffect>("se1") );
            sounds.Add(cm.Load<SoundEffect>("se1")); // TODO
        }

        // 0 Velocity
        public void spawnPowerUp(int type, Point p)
        {
            APowerUp powerUp;
            switch (type)
            {
                case 0:
                    powerUp = new Velocity(p);
                    break;
                case 1:
                    powerUp = new ScoreMultiplier(p);
                    break;
                default:
                    throw new ArgumentException(type+  " is not a valid power up type") ;
            }


            powerUp.LoadTexture(textures[type]);
            powerUp.setSoundEffect(sounds[type]);

            powerUps.Add(powerUp);
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
