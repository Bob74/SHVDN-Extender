
using GTA;
using GTA.Native;

namespace SE
{
    /// <summary>
    /// Dealing with game's scripts.
    /// </summary>
    public static class Script
    {
        /// <summary>
        /// Start a script.
        /// </summary>
        /// <param name="scriptName">Script's name</param>
        /// <param name="buffer">Size of the script buffer</param>
        public static void StartScript(string scriptName, int buffer)
        {
            Function.Call(Hash.REQUEST_SCRIPT, scriptName);

            while (!Function.Call<bool>(Hash.HAS_SCRIPT_LOADED, scriptName))
            {
                Function.Call(Hash.REQUEST_SCRIPT, scriptName);
                GTA.Script.Yield();
            }

            Function.Call(Hash.START_NEW_SCRIPT, scriptName, buffer);
            Function.Call(Hash.SET_SCRIPT_AS_NO_LONGER_NEEDED, scriptName);
        }

        /// <summary>
        /// Kill a script.
        /// </summary>
        /// <param name="scriptName">Script's name</param>
        public static void TerminateScript(string scriptName)
        {
            Function.Call(Hash.TERMINATE_ALL_SCRIPTS_WITH_THIS_NAME, scriptName);
        }
    }
}
