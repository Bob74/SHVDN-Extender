using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using GTA;
using GTA.Native;
using GTA.Math;
using System.Net;
using System.Reflection;

/*
    - Permettre de bloquer les contrôles pendant un temps donné ou de manière permanente

*/
namespace SE
{
    class Extender : GTA.Script
    {
        public Extender()
        {
            Tick += Initialize;
            //Tick += OnTick;
        }

        // OnTick Event
        void OnTick(object sender, EventArgs e)
        {

        }

        // Dispose Event
        protected override void Dispose(bool A_0)
        {
            if (A_0)
            {

            }
        }

        private void Initialize(object sender, EventArgs e)
        {
            while (Game.IsLoading)
                Yield();

            if (IsUpdateAvailable()) NotifyNewUpdate();

            Tick -= Initialize;
        }



        private bool IsUpdateAvailable()
        {
            string downloadedString = "";
            Version onlineVersion;

            try
            {
                WebClient client = new WebClient();
                downloadedString = client.DownloadString("https://raw.githubusercontent.com/Bob74/SHVDN-Extender/master/version");

                downloadedString = downloadedString.Replace("\r", "");
                downloadedString = downloadedString.Replace("\n", "");

                onlineVersion = new Version(downloadedString);

                client.Dispose();

                if (onlineVersion.CompareTo(Assembly.GetExecutingAssembly().GetName().Version) > 0)
                    return true;
                else
                    return false;
            }
            catch (Exception e)
            {
                Logger.Log("Error: IsUpdateAvailable - " + e.Message);
            }

            return false;
        }

        private void NotifyNewUpdate()
        {
            GTA.UI.Notify("SHVDN-Extender: A new update is available!", true);
        }

    }
}
