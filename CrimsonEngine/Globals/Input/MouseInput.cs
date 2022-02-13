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
        private MouseStateExtended previousMouseState { get; set; }
        private MouseStateExtended currentMouseState { get; set; }
        private Point2D PreviousPosition { get; set; }
        private Point2D CurrentPosition { get; set; }
        #endregion

        public MouseInput()
        {
            previousMouseState = MouseExtended.GetState();
            currentMouseState = MouseExtended.GetState();

            PreviousPosition = new Point2D();
            CurrentPosition = new Point2D();
        }

        public void Update()
        {
            previousMouseState = currentMouseState;
            PreviousPosition = (Point2D)previousMouseState.Position;

            currentMouseState = MouseExtended.GetState();
            CurrentPosition = (Point2D)currentMouseState.Position;

        }
    }
}
