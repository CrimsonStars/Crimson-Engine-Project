using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Text;

namespace CrimsonEngine
{
    public static class LibGlobals
    {
        /* TO DO LIST:
         *  add inputs class which stores mouse, gamepad and keyboard states
         *  temporary previous and new mouseState
         *  move all those things to Game Globals clas (or something like that)
         */

        #region Static public fields
        public static SpriteBatch LibSpriteBatch { get; set; }
        public static GraphicsDeviceManager LibGraphicsDeviceManager { get; set; }
        public static ContentManager LibContentManager { get; set; }
        public static int LibTotalFrameCount { get; set; }
        public static Vector2 MousePosition { get; set; }
        public static bool MouseClicked { get; set; } = false;
        #endregion


        public static void SetParameters(
                SpriteBatch SPRITE_BATCH,
                GraphicsDeviceManager GRAPHICS_DEVICE_MANAGER,
                ContentManager CONTENT_MANAGER,
                int FRAMERATE = 30)
        {
            LibGraphicsDeviceManager = GRAPHICS_DEVICE_MANAGER;
            LibTotalFrameCount = FRAMERATE;
            LibSpriteBatch = SPRITE_BATCH;
            LibContentManager = CONTENT_MANAGER;
        }

        public static void UpdateMousePosition(Vector2 MOUSE_POSITION, bool MOUSE_CLICKED)
        {
            MousePosition = MOUSE_POSITION;
            MouseClicked = MOUSE_CLICKED;
        }
    }
}
