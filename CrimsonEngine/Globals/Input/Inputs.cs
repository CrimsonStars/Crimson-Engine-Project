using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Input;
using MonoGame.Extended.Input.InputListeners;
using Microsoft.Xna.Framework.Input;

namespace CrimsonEngine.Globals.Inputs
{
    public sealed class Inputs : IBasicUpdate
    {
        #region Fields
        private static KeyboardInput Keyboard { get; set; }
        private static MouseInput Mouse { get; set; }
        private static Inputs Instance = null;
        private static readonly object padlock = new object();
        #endregion

        public static Inputs GetInstance()
        {
            lock (padlock)
            {
                if (Instance == null)
                {
                    Instance = new Inputs();
                }

                return Instance;
            }
        }

        private Inputs()
        {
            Keyboard = new KeyboardInput();
            Mouse = new MouseInput();
        }

        #region Public methods
        public void Update()
        {
            Mouse.Update();
            Keyboard.Update();
        }

        public bool IsKeyboardKeyPressed(Keys KEY)
        {
            return Keyboard.IsKeyHeldDown(KEY);
        }
        
        public bool IsMouseButtonPressed(MouseButton BUTTON)
        {
            return Mouse.IsButtonPressed(BUTTON);
        }

        public bool WasKeyboardKeyPressed(Keys KEY)
        {
            return Keyboard.WasButtonSinglePressed(KEY);
        }

        public bool WasMouseButtonPressed(MouseButton BUTTON)
        {
            return Mouse.WasButtonPressed(BUTTON);
        }
        #endregion
    }
}
