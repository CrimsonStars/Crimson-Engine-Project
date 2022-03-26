using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Input;
using MonoGame.Extended.Input;
using System.Linq;

namespace CrimsonEngine.Globals.Inputs
{
    public class KeyboardInput : IBasicUpdate
    {
        #region Fields
        private KeyboardStateExtended CurrentKeyboardState { get; set; }
        private KeyboardStateExtended PreviousKeyboardState { get; set; }
        private int DelayInitialFrames { get; set; }
        private int DelayWaitDecrementValue { get; set; }
        private Dictionary<Keys, int> kesIgno { get; set; }
        #endregion

        public KeyboardInput()
        {
            DelayInitialFrames = 4;
            DelayWaitDecrementValue = 1;

            kesIgno = new Dictionary<Keys, int>();
            CurrentKeyboardState = KeyboardExtended.GetState();
            PreviousKeyboardState = KeyboardExtended.GetState();
        }

        public void Update()
        {
            PreviousKeyboardState = CurrentKeyboardState;
            CurrentKeyboardState = KeyboardExtended.GetState();

            //foreach (var item in kesIgno.Keys.ToList())
            //{
            //    if (kesIgno[item] > 0)
            //    {
            //        kesIgno[item] -= DelayWaitDecrementValue;
            //    }
            //    else
            //    {
            //        kesIgno.Remove(item);
            //    }
            //}
        }

        #region Tests
        public bool IsKeyHeldDown(Keys KEY)
        {
            bool result = CurrentKeyboardState.IsKeyDown(KEY);
            return result;
        }
        
        private void AddNewKey(Keys KEY)
        {
            kesIgno.Add(KEY, DelayInitialFrames);
        }

        public bool WasKeyPressedOnce(Keys KEY)
        {
            bool result = false;

            if (CurrentKeyboardState.IsKeyDown(KEY) && !kesIgno.ContainsKey(KEY))
            {
                AddNewKey(KEY);
                result = true;
            }
            else if (kesIgno.ContainsKey(KEY))
            {
                if (kesIgno[KEY] <= 0 && CurrentKeyboardState.IsKeyDown(KEY))
                {
                    kesIgno[KEY] = DelayInitialFrames;
                }
            }

            return result;
        }

        public bool WasButtonSinglePressed(Keys KEY)
        {
            return CurrentKeyboardState.IsKeyDown(KEY) && !PreviousKeyboardState.IsKeyDown(KEY);
        }

        public bool ButtonIsPressed(Keys KEY)
        {
            return CurrentKeyboardState.IsKeyDown(KEY);
        }
        #endregion
    }
}
