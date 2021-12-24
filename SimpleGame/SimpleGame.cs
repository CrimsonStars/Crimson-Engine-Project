using CrimsonEngine.SimpleGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MLEM.Misc;
using MLEM.Ui;
using MLEM.Ui.Elements;
using MLEM.Ui.Style;
using MonoGame.Extended.Input;
using SimpleGame.Game_objects.GUI;
using System.Collections.Generic;
using System.Linq;

namespace CrimsonEngine.GL
{
    public class SimpleGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World GameWorld;
        private int TotalFrameCount;
        public UiSystem UiSystem;
        public GuiComposition GuiElements;


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

            _graphics.PreferredBackBufferWidth = Properties.Instance.Width;
            _graphics.PreferredBackBufferHeight = Properties.Instance.Height;
            _graphics.ApplyChanges();
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            LibGlobals.LibGraphicsDeviceManager = _graphics;

            

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

            base.Initialize();
        }

        protected override void LoadContent()
        {
            _spriteBatch = new SpriteBatch(GraphicsDevice);
            LibGlobals.LibSpriteBatch = _spriteBatch;
            LibGlobals.LibContentManager = Content;

            Mouse.SetCursor(
                MouseCursor.FromTexture2D(Content.Load<Texture2D>(@"sprites\amiga_mouse_cursor"),
                0, 0)
                );


            // TODO: use this.Content to load your game content here

            GameWorld = new World();
            GameWorld.GenerateWorld();

            GuiElements = new GuiComposition();
            GuiElements.AddButton(new Button2D("Not now", @"pixel", new Vector2(100, 100), new Vector2(100, 65)));
            GuiElements.Buttons.Last().ClickAction = 
                () => { GameWorld.GAME_STATE = GameStates.EXIT; };

            SpriteFont sf = Content.Load<SpriteFont>("PressStart2P");

            UiSystem = new UiSystem(this, new UntexturedStyle(_spriteBatch));
            var panel = new Panel(Anchor.Center, new Vector2(100, 200), Vector2.Zero);
            var butt = new Button(Anchor.Center, new Vector2(50, 20), "Siemka");
            UiSystem.Add("Test",panel);
            UiSystem.Add("Test button",butt);
        }

        protected override void Update(GameTime gameTime)
        {
            var PressedKeys = newKS.GetPressedKeys();

            updateKeyboardAndMouseState();
            GameWorld.Update();

            GuiElements.Update();

            UiSystem.Update(gameTime);

            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || newKS.IsKeyDown(Keys.Escape)
                || GameWorld.GAME_STATE == GameStates.EXIT)
            {
                Exit();
            }



            base.Update(gameTime);

            
        }

        protected override void Draw(GameTime gameTime)
        {
            this.UiSystem.DrawEarly(gameTime, this._spriteBatch);
            //Console.Write(String.Format("{0}\r", tt.GetCurrentState()));
            GraphicsDevice.Clear(Color.CornflowerBlue);


            // TODO: Add your drawing code here

            //_spriteBatch.Begin();
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            //_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

            GameWorld.Draw();
            GuiElements.Draw();

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
            this.UiSystem.Draw(gameTime, _spriteBatch);
            //Console.Write($"Elapsed time:\t{gameTime.ElapsedGameTime}\r");
        }
    }
}
