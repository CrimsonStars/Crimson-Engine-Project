using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Input;

namespace CrimsonEngine.Globals.Inputs
{
    // make it into singleton
    // make it global or something
    public class Inputs : IBasicUpdate
    {
        #region Fields
        private readonly KeyboardInput Keyboard;
        private readonly MouseInput Mouse;
        // public GamepadInput Gamepad; -- comming soon

        // check Apos.Input library


        private Inputs Instance = null;

        public Inputs GetInstance()
        {
            if(Instance == null)
            {
                Instance = new Inputs();
            }

            return Instance;
        }

        #endregion

        private Inputs()
        {
            Keyboard = new KeyboardInput();
            Mouse = new MouseInput();
        }

        public void Update()
        {
            Mouse.Update();
            Keyboard.Update();
        }

        #region Testing methods
        public bool IsKeyPressedDown(Microsoft.Xna.Framework.Input.Keys Key)
        {
            bool result = Keyboard.IsKeyPressed(Key);

            return result;
        }

        public bool WasKeySinglePressed(Microsoft.Xna.Framework.Input.Keys Key)
        {
            bool result = Keyboard.WasKeyPressed(Key);

            return result;
        }

        public void ListPressedKeys()
        {

        }

        #endregion
    }
}
