using GeometryFall.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace GeometryFall
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont defaultFont;

        private Player player;
        private Background bg;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            _graphics.PreferredBackBufferWidth = 800;
            _graphics.PreferredBackBufferHeight = 600;
            _graphics.ApplyChanges();
        }

        protected override void Initialize()
        {
            player = new Player();

            bg = new Background();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.LoadTexture(Content.Load<Texture2D>("player1"));
            player.LoadTexture(Content.Load<Texture2D>("player2"));

            bg.LoadTexture(Content.Load<Texture2D>("bg"));

            defaultFont = Content.Load<SpriteFont>("Default");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.Up))
            {
                player.Move(Direction.Up, gameTime);
            }
            if (kbs.IsKeyDown(Keys.Down))
            {
                player.Move(Direction.Down, gameTime);
            }

            if (kbs.IsKeyDown(Keys.Right))
            {
                player.Move(Direction.Right, gameTime);
            }
            if (kbs.IsKeyDown(Keys.Left))
            {
                player.Move(Direction.Left, gameTime);
            }

            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            bg.Draw(_spriteBatch);

            player.Draw(_spriteBatch);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
