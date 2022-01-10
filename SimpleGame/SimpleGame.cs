using CrimsonEngine.SimpleGame;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using SimpleGame.Game_objects.GUI;
using System.Collections.Generic;
using System.Linq;
using MonoGame.ImGui;
using ImGuiNET;
using MonoGame.Extended;
using MonoGame.Extended.Gui;
using MonoGame.Extended.Gui.Controls;
using CrimsonEngine.Graphics.GUI;

namespace CrimsonEngine.GL
{
    public class SimpleGame : Game
    {
        private GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private World GameWorld;
        private int TotalFrameCount;
        private ImGuiDebug DebugGui;

        private GuiContainer2D guiCont=new GuiContainer2D();


        SpriteFont sf;
        TajmerTemp tt;
        KeyboardState previousKS, newKS;
        MouseStateExtended LastMS, CurrentMS;
        KeyboardStateExtended newKSE, oldKSE;
        private bool WasMouseClicked = false;


        void updateKeyboardAndMouseState()
        {
            previousKS = newKS;
            newKS = Keyboard.GetState();
            oldKSE = newKSE;
            newKSE = KeyboardExtended.GetState();

            WasMouseClicked = 
                CurrentMS.IsButtonDown(MouseButton.Left) && !LastMS.IsButtonDown(MouseButton.Left);
            
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
            DebugGui = new ImGuiDebug(this);

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

            GameWorld = new World();
            GameWorld.GenerateWorld();

            guiCont.AddLabel(Vector2.Zero, "Nope");
            guiCont.AddLabel(new Vector2(10,80), "Siemka, co tam?",Color.Red, GuiContainer2D.Layer.SECOND);
        }

        protected override void Update(GameTime gameTime)
        {
            var PressedKeys = newKS.GetPressedKeys();

            GameWorld.Update();
            guiCont.Update();

            #region Manage inputs (keyboard or mouse)
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || newKS.IsKeyDown(Keys.Escape)
                || GameWorld.GAME_STATE == GameStates.EXIT)
            {
                Exit();
            }

            if(WasMouseClicked)
            {
                System.Console.WriteLine("Siema . . .");
            }
            

            updateKeyboardAndMouseState();
            #endregion

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            //Console.Write(String.Format("{0}\r", tt.GetCurrentState()));
            GraphicsDevice.Clear(Color.CornflowerBlue);
            _spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend);
            //_spriteBatch.Begin(SpriteSortMode.Deferred, BlendState.AlphaBlend, SamplerState.PointClamp);

            GameWorld.Draw();
            guiCont.Draw();

            TotalFrameCount++;
            if (TotalFrameCount % 30 == 0)
            {
                var instance = Properties.Instance;
                var framesPerSecond = (int)(1.0f / gameTime.ElapsedGameTime.TotalSeconds);
                Window.Title = $"Crimson game - {instance.Version} ({framesPerSecond} fps)";
                TotalFrameCount = 0;
            }

            DebugGui.Draw(gameTime);

            guiCont.Draw();

            base.Draw(gameTime);
            _spriteBatch.End();

            
            //SimpleMlemGui.Draw(gameTime, _spriteBatch);
            //Console.Write($"Elapsed time:\t{gameTime.ElapsedGameTime}\r");
        }
    }
}
