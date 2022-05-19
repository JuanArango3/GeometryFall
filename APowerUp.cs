using GeometryFall.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Audio;

namespace GeometryFall
{
    abstract class APowerUp : SpriteBase
    {
        SoundEffect soundEffect;
        public APowerUp(Point location) : base(location, new Point(50, 50))
        {

        }

        public void setSoundEffect(SoundEffect sound)
        {
            soundEffect = sound;
        }

        public abstract void doAction(Player p);

        public void pickUp(Player p)
        {
            doAction(p);

            if (soundEffect != null) soundEffect.Play();
        }
    }
}
