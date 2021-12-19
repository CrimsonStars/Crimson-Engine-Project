using CrimsonEngine.SimpleGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using System.Collections.Generic;

namespace CrimsonEngine.GL
{
    public class SimpleGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World GameWorld;
        private int TotalFrameCount;


        #region Console variables and stuff
        private const string CommandCursor = "> ";
        private List<string> CommandHistory = new List<string>(5);
        private string actualInputStringCommand = "";
        private Texture2D consoleBackground;
        #endregion

        SpriteFont sf;
        KeyboardState previousKS, newKS;
        TajmerTemp tt;
        MouseStateExtended LastMS, CurrentMS;

        KeyboardStateExtended newKSE, oldKSE;



        void updateKeyboardAndMouseState()
        {
            previousKS = newKS;
            newKS = Keyboard.GetState();

            oldKSE = newKSE;
            newKSE = KeyboardExtended.GetState();

            LastMS = CurrentMS;
            CurrentMS = MonoGame.Extended.Input.MouseExtended.GetState();
        }

        bool WasPresed(Keys key)
        {
            return newKS.IsKeyDown(key) && !previousKS.IsKeyDown(key);
        }

        bool EqualKeyboardStates(KeyboardState A, KeyboardState B)
        {
            if (A.GetPressedKeys().Length == B.GetPressedKeys().Length)
            {
                for (int i = 0; i < A.GetPressedKeys().Length; i++)
                {
                    if (A.GetPressedKeys()[i] == B.GetPressedKeys()[i])
                        return false;
                }
            }

            return true;
        }

        public SimpleGame()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            LibGlobals.SetParameters(_spriteBatch, _graphics, Content, 60);

            GameWorld = new World();


            //tt = new TajmerTemp(.350f);

            //var PropertiesInstance = Properties.Instance;
            //Window.Title = PropertiesInstance.WindowTitle;
            //IsFixedTimeStep = true;
            //TargetElapsedTime = TimeSpan.FromSeconds(1.0 / PropertiesInstance.Framerate);

            //tt.Start();

            TotalFrameCount = 0;
        }


        protected override void Initialize()
        {
            // TODO: Add your initialization logic here

            // setup WxH of window
            _graphics.PreferredBackBufferWidth = Properties.Instance.Width;
            _graphics.PreferredBackBufferHeight = Properties.Instance.Height;
            _graphics.ApplyChanges();

            Mouse.SetCursor(
                MouseCursor.FromTexture2D(Content.Load<Texture2D>(@"sprites\amiga_mouse_cursor"),
                0, 0)
                );


            

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);


            // TODO: use this.Content to load your game content here
            GameWorld.GenerateWorld();
        }

        protected override void Update(GameTime gameTime)
        {
            var PressedKeys = newKS.GetPressedKeys();

            updateKeyboardAndMouseState();
            GameWorld.Update();




            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || newKS.IsKeyDown(Keys.Escape)
                || GameWorld.GAME_STATE == GameStates.EXIT)
            {
                Exit();
            }

            base.Update(gameTime);

            
        }

        protected override void Draw(GameTime gameTime)
        {
            //Console.Write(String.Format("{0}\r", tt.GetCurrentState()));
            GraphicsDevice.Clear(Color.CornflowerBlue);

            GameWorld.Draw();

            // TODO: Add your drawing code here

            //_spriteBatch.Begin();
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            //_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);


            TotalFrameCount++;
            if (TotalFrameCount % 30 == 0)
            {
                var instance = Properties.Instance;
                var framesPerSecond = (int)(1.0f / gameTime.ElapsedGameTime.TotalSeconds);
                Window.Title = $"Crimson game - {instance.Version} ({framesPerSecond} fps)";
                TotalFrameCount = 0;
            }


            base.Draw(gameTime);
            _spriteBatch.End();
            //Console.Write($"Elapsed time:\t{gameTime.ElapsedGameTime}\r");
        }
    }
}
