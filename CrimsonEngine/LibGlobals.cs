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
        #region Static public fields
        public static SpriteBatch LibSpriteBatch { get; set; }
        public static GraphicsDeviceManager LibGraphicsDeviceManager { get; set; }
        public static ContentManager LibContentManager { get; set; }
        public static int LibTotalFrameCount { get; set; }
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
    }
}
