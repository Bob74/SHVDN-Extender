
using GTA;
using GTA.Native;

namespace SE
{
    /// <summary>
    /// Dealing with the current player.
    /// </summary>
    public static class Player
    {
        /// <summary>
        /// Return the current Ped type.
        /// 0 = Michael
        /// 1 = Franklin
        /// 2 = Trevor
        /// </summary>
        /// <returns>Character's ID.</returns>
        public static int GetCurrentCharacterID()
        {
            switch ((uint)Game.Player.Character.Model.Hash)
            {
                case (uint)PedHash.Michael:
                    return 0;
                case (uint)PedHash.Franklin:
                    return 1;
                case (uint)PedHash.Trevor:
                    return 2;
                default: return 0;
            }
        }
        /// <summary>
        /// Return the character's name.
        /// </summary>
        /// <param name="full">Return first name and last name.</param>
        /// <returns>Character's name</returns>
        public static string GetCurrentCharacterName(bool full = false)
        {
            string lastname = "";

            switch (GetCurrentCharacterID())
            {
                case 0:
                    if (full)
                        lastname = " De Santa";
                    return "Michael" + lastname;
                case 1:
                    if (full)
                        lastname = " Clinton";
                    return "Franklin" + lastname;
                case 2:
                    if (full)
                        lastname = " Philips";
                    return "Trevor" + lastname;
                default:
                    return "???";
            }
        }
        /// <summary>
        /// Add cash to the current player. Use negative value to remove cash.
        /// </summary>
        /// <param name="value"></param>
        /// <returns>Return false if the player doesn't have enought money.</returns>
        public static bool AddCashToPlayer(int value)
        {
            if (value == 0) return true;

            int newValue = Game.Player.Money + value;

            if (newValue >= 0)
            {
                Game.Player.Money += value;
                return true;
            }
            return false;
        }
    }
}
