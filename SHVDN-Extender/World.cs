
using System.Drawing;

using GTA;
using GTA.Native;
using GTA.Math;

namespace SE
{
    /// <summary>
    /// Creating stuff in the game's world.
    /// </summary>
    public static class World
    {
        /// <summary>
        /// Loads an IPL file.
        /// </summary>
        /// <param name="ipl">IPL to load</param>
        public static void RequestIpl(string ipl)
        {
            if (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, ipl))
                Function.Call<bool>(Hash.REQUEST_IPL, ipl);
            while (!Function.Call<bool>(Hash.IS_IPL_ACTIVE, ipl))
                GTA.Script.Yield();
        }

        /// <summary>
        /// Draw a marker in the world.
        /// </summary>
        /// <param name="pos">Position of the marker</param>
        public static void DrawMarker(Vector3 pos) { GTA.World.DrawMarker(MarkerType.VerticalCylinder, pos, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(2.0f, 2.0f, 0.5f), Color.FromArgb(128, 255, 255, 0)); }
        /// <summary>
        /// Draw a marker in the world.
        /// </summary>
        /// <param name="pos">Position of the marker</param>
        /// <param name="color">Color of the marker</param>
        public static void DrawMarker(Vector3 pos, Color color) { GTA.World.DrawMarker(MarkerType.VerticalCylinder, pos, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), new Vector3(2.0f, 2.0f, 0.5f), color); }
        /// <summary>
        /// Draw a marker in the world.
        /// </summary>
        /// <param name="pos">Position of the marker</param>
        /// <param name="marker">Type of marker</param>
        /// <param name="scale">Scale of the marker</param>
        public static void DrawMarker(MarkerType marker, Vector3 pos, Vector3 scale) { GTA.World.DrawMarker(MarkerType.VerticalCylinder, pos, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), scale, Color.FromArgb(128, 255, 255, 0)); }
        /// <summary>
        /// Draw a marker in the world.
        /// </summary>
        /// <param name="pos">Position of the marker</param>
        /// <param name="marker">Type of marker</param>
        /// <param name="scale">Scale of the marker</param>
        /// <param name="color">Color of the marker</param>
        public static void DrawMarker(MarkerType marker, Vector3 pos, Vector3 scale, Color color) { GTA.World.DrawMarker(MarkerType.VerticalCylinder, pos, new Vector3(0f, 0f, 0f), new Vector3(0f, 0f, 0f), scale, color); }
    }
    
}
