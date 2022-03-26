using CrimsonEngine.Simple_math;
using MonoGame.Extended.Input;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine.Globals.Inputs
{
    public class MouseInput : IBasicUpdate
    {
        #region Fields
        private MouseStateExtended PreviousMouseState { get; set; }
        private MouseStateExtended CurrentMouseState { get; set; }
        private List<MouseButton> MouseButtonsList { get; set; }

        // might be use in the future
        private Dictionary<MouseButton, bool> PreviousButtonPressed;
        private Dictionary<MouseButton,bool> CurrentButtonPressed;
        #endregion

        public MouseInput()
        {
            MouseButtonsList = new List<MouseButton>() 
            {
                MouseButton.Left,
                MouseButton.Middle,
                MouseButton.Right
            };

#if DEBUG
            Console.WriteLine("LOG: Mouse buttons for checking added, count = {0}.", MouseButtonsList.Count);
#endif

            PreviousButtonPressed = new Dictionary<MouseButton, bool>();
            CurrentButtonPressed = new Dictionary<MouseButton, bool>();

            // add required buttons for checks
            foreach(var item in MouseButtonsList)
            {
                PreviousButtonPressed.Add(item, false);
                CurrentButtonPressed.Add(item, false);
            }

#if DEBUG
            Console.WriteLine("LOG: Mouse buttons pressed list was generated.");
            Console.WriteLine();
#endif

            PreviousMouseState = MouseExtended.GetState();
            CurrentMouseState = MouseExtended.GetState();
        }

        public void Update()
        {
            PreviousMouseState = CurrentMouseState;
            CurrentMouseState = MouseExtended.GetState();
        }

        public bool IsButtonPressed(MouseButton BUTTON)
        {
            return CurrentMouseState.IsButtonDown(BUTTON);
        }

        public bool WasButtonPressed(MouseButton BUTTON)
        {
            return CurrentMouseState.IsButtonDown(BUTTON) && PreviousMouseState.IsButtonUp(BUTTON);
        }

        public Point2D GetCurrentMousePosition()
        {
            return CurrentMouseState.Position;
        }

        public Point2D GetCurrentMousePositionDelta()
        {
            return CurrentMouseState.DeltaPosition;
        }

        public bool IsMouseMoving(int TOLERANCE = 2)
        {
            return CurrentMouseState.DeltaX > TOLERANCE || CurrentMouseState.DeltaY > TOLERANCE;
        }

        public int MouseWheelDirectionUsed()
        {
            return CurrentMouseState.ScrollWheelValue;
        }
    }
}
