
using GTA;
using GTA.Native;

namespace SE
{
    static class Phone
    {
        /// <summary>
        /// Remove the phone content displayed on screen.
        /// </summary>
        /// <param name="handle">Phone's scaleform handle</param>
        public static void DestroyPhone(int handle)
        {
            Function.Call(Hash.DESTROY_MOBILE_PHONE, handle);
        }

        /// <summary>
        /// Return the name of the sound set of the current character's phone.
        /// </summary>
        /// <returns></returns>
        public static string GetPhoneSoundSet()
        {
            switch ((uint)Game.Player.Character.Model.Hash)
            {
                case (uint)PedHash.Michael:
                    return "Phone_SoundSet_Michael";
                case (uint)PedHash.Franklin:
                    return "Phone_SoundSet_Franklin";
                case (uint)PedHash.Trevor:
                    return "Phone_SoundSet_Trevor";
                default:
                    return "Phone_SoundSet_Default";
            }
        }
    }
}
