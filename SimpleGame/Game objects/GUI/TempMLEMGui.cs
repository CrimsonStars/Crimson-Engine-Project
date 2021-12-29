using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using MLEM.Textures;
using MLEM.Ui;
using MLEM.Ui.Elements;
using MLEM.Ui.Style;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleGame.Game_objects.GUI
{
    public class TempMLEMGui
    {
        public UiSystem MlemUiSystem { get; set; }


        public TempMLEMGui(Game GAME, ContentManager CONTENT) //, SpriteBatch SPRITE_BATCH)
        {
            UiStyle uiStyle = new UiStyle();
            uiStyle.Font = new MLEM.Font.GenericSpriteFont(CONTENT.Load<SpriteFont>("PressStart2P"));
            uiStyle.TextScale = 1.0f;
            uiStyle.PanelTexture = new NinePatch(
                new TextureRegion(CONTENT.Load<Texture2D>(@"sprites\amiga_mouse_cursor"), 0, 0, 8, 8),
                0);

            //MlemUiSystem = new UiSystem(GAME, new UntexturedStyle(SPRITE_BATCH));
            MlemUiSystem = new UiSystem(GAME, uiStyle);
            var panel = new Panel(Anchor.Center, new Vector2(100, 200), Vector2.Zero);
            var butt = new Button(Anchor.Center, new Vector2(50, 20), "Lorem ipsum");
            MlemUiSystem.Add("Test", panel);
        }

        public void DrawEarly(GameTime GAME_TIME, SpriteBatch SPRITE_BATCH)
        {
            MlemUiSystem.DrawEarly(GAME_TIME, SPRITE_BATCH);
        }

        public void Draw(GameTime GAME_TIME, SpriteBatch SPRITE_BATCH)
        {
            MlemUiSystem.Draw(GAME_TIME, SPRITE_BATCH);
        }

        public void Update(GameTime GAME_TIME)
        {
            MlemUiSystem.Update(GAME_TIME);
        }
    }
}
