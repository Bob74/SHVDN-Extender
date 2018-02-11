using System.Drawing;

using GTA;
using GTA.Native;

namespace SE
{
    class UI
    {
        /// <summary>
        /// Wait the duration time and hide the ui.
        /// </summary>
        /// <param name="duration"></param>
        public static void WaitAndhideUI(int duration)
        {
            int timer = Game.GameTime + duration;
            do
            {
                Function.Call(Hash.HIDE_HUD_AND_RADAR_THIS_FRAME);
                GTA.Script.Yield();
            } while (timer >= Game.GameTime);
        }

        /// <summary>
        /// Display help text (Top left corner, can contain Keypress icons).
        /// ! Needs to be called every frame !
        /// </summary>
        /// <param name="text"></param>
        public static void DisplayHelpTextThisFrame(string text)
        {
            Function.Call(Hash._SET_TEXT_COMPONENT_FORMAT, "STRING");                   //  BEGIN_TEXT_COMMAND_DISPLAY_HELP
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, text);                       //  ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME
            Function.Call(Hash._DISPLAY_HELP_TEXT_FROM_STRING_LABEL, 0, 0, 1, -1);      //  END_TEXT_COMMAND_DISPLAY_HELP
        }

        /// <summary>
        /// Display a simple notification.
        /// </summary>
        /// <param name="text"></param>
        /// <param name="sound">Emit notification sound (disable by default)</param>
        public static void DrawNotification(string text, bool sound = false)
        {
            Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "CELL_EMAIL_BCON");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, "CELL_EMAIL_BCON");          //  ADD_TEXT_COMPONENT_SUBSTRING_PLAYER_NAME
            Function.Call(Hash._DRAW_NOTIFICATION, false, true);

            if (sound)
                Audio.PlaySoundFrontend("Text_Arrive_Tone", Phone.GetPhoneSoundSet());
        }

        /// <summary>
        /// Display a notification with a picture.
        /// </summary>
        /// <param name="picture"></param>
        /// <param name="title"></param>
        /// <param name="subtitle"></param>
        /// <param name="message"></param>
        /// <param name="sound">Emit notification sound (enable by default)</param>
        public static void DrawNotification(string picture, string title, string subtitle, string message, bool sound = true)
        {
            Function.Call(Hash.REQUEST_STREAMED_TEXTURE_DICT, picture, false);
            while (!Function.Call<bool>(Hash.HAS_STREAMED_TEXTURE_DICT_LOADED, picture))
                GTA.Script.Yield();

            Function.Call(Hash._SET_NOTIFICATION_TEXT_ENTRY, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, message);
            Function.Call(Hash._SET_NOTIFICATION_MESSAGE, picture, picture, false, 4, title, subtitle);
            Function.Call(Hash._DRAW_NOTIFICATION, false, true);

            if (sound)
                Audio.PlaySoundFrontend("Text_Arrive_Tone", Phone.GetPhoneSoundSet());
        }

        /// <summary>
        /// Display a text on the screen.
        /// ! Needs to be called every frame !
        /// </summary>
        /// <param name="text"></param>
        /// <param name="font"></param>
        /// <param name="centre"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="scale"></param>
        /// <param name="r"></param>
        /// <param name="g"></param>
        /// <param name="b"></param>
        /// <param name="a"></param>
        public static void DrawText(string text, int font, bool centre, float x, float y, float scale, int r, int g, int b, int a)
        {
            Function.Call(Hash.SET_TEXT_FONT, font);
            Function.Call(Hash.SET_TEXT_PROPORTIONAL, 0);
            Function.Call(Hash.SET_TEXT_SCALE, scale, scale);
            Function.Call(Hash.SET_TEXT_COLOUR, r, g, b, a);
            Function.Call(Hash.SET_TEXT_DROPSHADOW, 0, 0, 0, 0, 255);
            Function.Call(Hash.SET_TEXT_EDGE, 1, 0, 0, 0, 255);
            Function.Call(Hash.SET_TEXT_DROP_SHADOW);
            Function.Call(Hash.SET_TEXT_OUTLINE);
            Function.Call(Hash.SET_TEXT_CENTRE, centre);
            Function.Call(Hash._SET_TEXT_ENTRY, "STRING");
            Function.Call(Hash._ADD_TEXT_COMPONENT_STRING, text);
            Function.Call(Hash._DRAW_TEXT, x, y);
        }

        /// <summary>
        /// Draw a texture file on the screen.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="time"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="centre"></param>
        /// <param name="index"></param>
        /// <param name="level"></param>
        public static void DrawTexture(string fileName, int time, float x, float y, bool centre = false, int index = 0, int level = 1)
        {
            // Get the texture properties
            Image sprite = Image.FromFile(fileName);

            // Adapt to floating point localisation
            Point position = GetSpriteCoordinatesFromFloat(sprite, x, y, centre);

            // Draw
            GTA.UI.DrawTexture(fileName, index, level, time, position, new Size(sprite.Width, sprite.Height));
        }

        /// <summary>
        /// Draw a texture file on the screen and apply a color to it.
        /// </summary>
        /// <param name="fileName"></param>
        /// <param name="time"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="color"></param>
        /// <param name="centre"></param>
        /// <param name="index"></param>
        /// <param name="level"></param>
        public static void DrawTexture(string fileName, int time, float x, float y, Color color, bool centre = false, int index = 0, int level = 1)
        {
            // Get the texture properties
            Image sprite = Image.FromFile(fileName);

            // Adapt to floating point localisation
            Point position = GetSpriteCoordinatesFromFloat(sprite, x, y, centre);

            // Draw
            GTA.UI.DrawTexture(fileName, index, level, time, position, new Size(sprite.Width, sprite.Height), 0.0f, color);
        }

        /// <summary>
        /// Return pixels coordinates from float coordinates while dealing with the picture size.
        /// </summary>
        /// <param name="sprite"></param>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="centre"></param>
        /// <returns></returns>
        public static Point GetSpriteCoordinatesFromFloat(Image sprite, float x, float y, bool centre = false)
        {
            // Get screen resolution
            OutputArgument outW = new OutputArgument(), outH = new OutputArgument();
            Function.Call(Hash.GET_SCREEN_RESOLUTION, outW, outH);

            int w = outW.GetResult<int>(), h = outH.GetResult<int>();
            if (centre)
            {
                w = w - (int)(sprite.Width / 2);
                h = h - (int)(sprite.Height / 2);
            }

            // Adapt to floating point localisation
            Point position = new Point((int)(x * w), (int)(y * h));
            return position;
        }

    }
}
