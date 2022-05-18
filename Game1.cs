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

        private PowerUpController puController;

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

            puController = new PowerUpController();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            player.LoadTexture(Content.Load<Texture2D>("player1"));
            player.LoadTexture(Content.Load<Texture2D>("player2"));

            bg.LoadTexture(Content.Load<Texture2D>("bg"));

            puController.LoadAssets(Content);

            puController.spawnVelocityPowerUp(new Point(400, 400));

            defaultFont = Content.Load<SpriteFont>("Default");
        }

        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            KeyboardState kbs = Keyboard.GetState();
            if (kbs.IsKeyDown(Keys.Up) || kbs.IsKeyDown(Keys.W))
            {
                player.Move(Direction.Up);
            }
            if (kbs.IsKeyDown(Keys.Down) || kbs.IsKeyDown(Keys.S))
            {
                player.Move(Direction.Down);
            }

            if (kbs.IsKeyDown(Keys.Right) || kbs.IsKeyDown(Keys.D))
            {
                player.Move(Direction.Right);
            }
            if (kbs.IsKeyDown(Keys.Left) || kbs.IsKeyDown(Keys.A))
            {
                player.Move(Direction.Left);
            }


            puController.checkColisions(player);
            

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            bg.Draw(_spriteBatch);

            player.Draw(_spriteBatch);

            puController.draw(_spriteBatch);

            string info = "X:" + player.Location.X + " Y:" + player.Location.Y + " Vel:" +player.Velocidad;

            _spriteBatch.DrawString(defaultFont, info, new Vector2(0, 0), Color.White);

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
