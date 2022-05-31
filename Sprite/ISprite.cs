using Microsoft.Xna.Framework.Graphics;

namespace GeometryFall.Sprite
{
    public interface ISprite
    {
        void Draw(SpriteBatch sb);

        void LoadTexture(Texture2D texture2D);
    }
}
