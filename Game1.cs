using GeometryFall.Sprite;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.IO;
using System.Collections.Generic;

namespace GeometryFall
{
    public class Game1 : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        private SpriteFont defaultFont;

        private Player player;
        private Background bg;
        private GameOver go;

        private PowerUpController puController;

        private SpikesController spikesController;

        private MusicController musicController;

        private List<Coin> coins;
        private double score;
        private Texture2D coinTexture;

        private int scene;

        private string path = "C:/Users/Ender/Documents/geometryfall.txt";

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
            scene = 0;
            player = new Player();

            bg = new Background();
            go = new GameOver();

            puController = new PowerUpController();
            spikesController = new SpikesController();
            musicController = new MusicController();

            coins = new List<Coin>();

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);

            try
            {
                player.LoadTexture(Content.Load<Texture2D>("player1"));
                player.LoadTexture(Content.Load<Texture2D>("player2"));

                bg.LoadTexture(Content.Load<Texture2D>("bg"));
                go.LoadTexture(Content.Load<Texture2D>("gameover"));

                puController.LoadAssets(Content);

                defaultFont = Content.Load<SpriteFont>("Default");

                musicController.loadSongs(Content, true);

                coinTexture = Content.Load<Texture2D>("coin");
                score = 0;

                spikesController.setTexture(Content.Load<Texture2D>("spike"));

                if (!File.Exists(path))
                {
                    File.WriteAllText(path, "0");
                }
                
            }
            catch
            {
                this.Exit();
            }

            puController.spawnPowerUp(0, new Point(400, 200));
            puController.spawnPowerUp(1, new Point(200, 200));
            puController.spawnPowerUp(0, new Point(100, 200));

            coins.Add(new Coin(new Point(100,100), coinTexture));

            spikesController.generateSpikes(new Point(100, 400), 5);
            spikesController.generateSpikes(new Point(0, 500), 8);
            spikesController.generateSpikes(new Point(500, 600), 5);
            spikesController.generateSpikes(new Point(200, 800), 5);
            spikesController.generateSpikes(new Point(100, 1000), 5);
            spikesController.generateSpikes(new Point(400, 1240), 5);
            spikesController.generateSpikes(new Point(000, 1400), 20);


        }

        protected override void Update(GameTime gameTime)
        {
            if (scene!=-1)
            {
                score += (gameTime.ElapsedGameTime.TotalMilliseconds / 1000)*player.ScoreMultiplier;
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

                for (int i = 0; i < coins.Count; i++)
                {
                    Coin coin = coins[i];

                    if (player.Rectangle.Intersects(coin.Rectangle))
                    {
                        score += 10;
                        coins.RemoveAt(i);
                    }
                }

                if (spikesController.checkColision(player))
                {
                    scene = -1;
                    musicController.Pause();

                    if (score > int.Parse(File.ReadAllText(path)))
                    {
                        File.WriteAllText(path, Math.Round(score).ToString());
                    }
                }
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.Black);

            _spriteBatch.Begin();

            switch (scene)
            {
                case -1:
                    go.Draw(_spriteBatch);
                    _spriteBatch.DrawString(defaultFont, "Score: " + Math.Round(score), new Vector2(400, 50), Color.White);
                    _spriteBatch.DrawString(defaultFont, "Best score: " + int.Parse(File.ReadAllText(path)), new Vector2(400, 65), Color.White);
                    break;
                case 0:
                    bg.Draw(_spriteBatch);

                    player.Draw(_spriteBatch);

                    puController.draw(_spriteBatch);

                    coins.ForEach((coin) => coin.Draw(_spriteBatch));

                    spikesController.Draw(_spriteBatch);

                    _spriteBatch.DrawString(defaultFont, "Score: " + Math.Round(score), new Vector2(0, 0), Color.White);
                    break;
                default:
                    break;
            }

            

            _spriteBatch.End();

            base.Draw(gameTime);
        }
    }
}
