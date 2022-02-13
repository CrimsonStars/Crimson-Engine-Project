using System;
using System.Collections.Generic;
using System.Text;
using MonoGame.Extended.Input;

namespace CrimsonEngine.Globals.Inputs
{
    public class KeyboardInput : IBasicUpdate
    {
        // add fixes for types (make them proper)
        #region Fields
        public KeyboardStateExtended CurrentKeyboardState { get; private set; }
        public KeyboardStateExtended PreviousKeyboardState { get; private set; }
        private List<string> KeysPressed { get; set; }
        #endregion

        public KeyboardInput()
        {
            KeysPressed = new List<string>();
            CurrentKeyboardState = KeyboardExtended.GetState();
            PreviousKeyboardState = KeyboardExtended.GetState();
        }

        public void Update()
        {
            // change to proper input logic
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = KeyboardExtended.GetState();

            // might remove it later
            TempMethod();
        }

        private void TempMethod()
        {
            /* I don't know what to do here
             * This is my sandbox for code + inputs
             * 
             * IF anyKeyWasPressed IN CURRENT_KEYBOARD state
             */
            if(CurrentKeyboardState.WasAnyKeyJustDown())
            {
                var tempObject =
                    new {
                        Temp0 = PreviousKeyboardState.WasKeyJustUp(Microsoft.Xna.Framework.Input.Keys.Space),
                        Temp1 = CurrentKeyboardState.WasKeyJustUp(Microsoft.Xna.Framework.Input.Keys.Space),
                        Temp2 = PreviousKeyboardState.WasKeyJustDown(Microsoft.Xna.Framework.Input.Keys.Space),
                        Temp3 = CurrentKeyboardState.WasKeyJustDown(Microsoft.Xna.Framework.Input.Keys.Space),
                        NumLock_prev = PreviousKeyboardState.NumLock,
                        NumLock_curr = CurrentKeyboardState.NumLock,
                        PressedKeys_prev = PreviousKeyboardState.GetPressedKeys(),
                        PressedKeys_curr = CurrentKeyboardState.GetPressedKeys()
                    };

                //Console.WriteLine("TEMP TEST! - A random key was pressed.");
            }

            //Console.Write("PREVIOUS: ");
            //foreach (var item in PreviousKeyboardState.GetPressedKeys())
            //{
            //    Console.Write("{0} ", item);
            //}

            Console.Write("\rCURRENT:  ");
            foreach (var item in CurrentKeyboardState.GetPressedKeys())
            {
                Console.Write("{0} ", item);
            }

        }

        /// <summary>
        /// Was the key pressed and released? If the key was pressed
        /// and is still pressed than it won't register it as pressed
        /// anymore (return <c>TRUE</c> for a single press of keyboard
        /// key).
        /// </summary>
        public bool WasKeyPressed(Microsoft.Xna.Framework.Input.Keys Key)
        {
            bool result = CurrentKeyboardState.WasKeyJustDown(Key);
            bool[] temp = 
                {
                PreviousKeyboardState.WasKeyJustDown(Key),
                PreviousKeyboardState.WasKeyJustUp(Key),
                CurrentKeyboardState.WasKeyJustDown(Key),
                CurrentKeyboardState.WasKeyJustUp(Key)
            };

            return result;
        }

        /// <summary>
        /// To be precise this method checks if given key
        /// was pressed and is STILL pressed. If so the <c>TRUE</c> value
        /// is returned.
        /// </summary>
        public bool IsKeyPressed(Microsoft.Xna.Framework.Input.Keys Key)
        {
            bool result = 
                PreviousKeyboardState.IsKeyDown(Key) &&
                CurrentKeyboardState.IsKeyDown(Key)
                ;
            
            return result;
        }
    }
}
