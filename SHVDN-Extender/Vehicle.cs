using System;
using System.Collections.Generic;

using GTA;
using GTA.Native;
using GTA.Math;

namespace SE
{
    /// <summary>
    /// Contains the different vehicle's wheels.
    /// </summary>
    public enum Wheel
    {
        None = -1,
        FrontLeft,              // bike, plane or jet front left
        FrontRight,             //
        MiddleLeft,             // 4/6 wheels trailers, plane or jet is first one on left
        MiddleRight,            // 4/6 wheels trailers, plane or jet is first one on right
        RearLeft,               // bike rear / 4/6 wheels trailer, plane or jet is last one on left
        RearRight,              // 4/6 wheels trailer, plane or jet is last one on right
        MiddleLeft6_2 = 45,     // 6 wheels trailer mid wheel left (according to Native DB)
        MiddleRight6_2 = 47,    // 6 wheels trailer mid wheel right (according to Native DB)
        MiddleLeft6 = 252,      // 6 wheels trailer mid wheel left (tested in 1290)
        MiddleRight6 = 256      // 6 wheels trailer mid wheel right (tested in 1290)
    }

    /// <summary>
    /// Vehicles informations and functions.
    /// </summary>
    public static class Vehicle
    {
        /// <summary>
        /// Get the bone's name from the wheel.
        /// </summary>
        public static readonly Dictionary<Wheel, string> WheelsBones = new Dictionary<Wheel, string>
        {
            { Wheel.FrontLeft, "wheel_lf" },
            { Wheel.FrontRight, "wheel_rf" },
            { Wheel.MiddleLeft, "wheel_lm1" },
            { Wheel.MiddleRight, "wheel_rm1" },
            { Wheel.MiddleLeft6_2, "wheel_lm2" },
            { Wheel.MiddleRight6_2, "wheel_rm2" },
            { Wheel.MiddleLeft6, "wheel_lm3" },
            { Wheel.MiddleRight6, "wheel_rm3" },
            { Wheel.RearLeft, "wheel_lr" },
            { Wheel.RearRight, "wheel_rr" },
        };

        /// <summary>
        /// Generate a random number plate.
        /// GTA V number plate format: 00AAA000
        /// </summary>
        /// <returns>Random plate number</returns>
        public static string GetRandomNumberPlate()
        {
            int num = 0;
            string final = "";

            Random rnd = new Random();

            num = rnd.Next(0, 99);
            final += num.ToString("00");
            rnd = new Random(Game.GameTime);

            final += (char)rnd.Next(65, 90);
            final += (char)rnd.Next(65, 90);
            final += (char)rnd.Next(65, 90);

            num = rnd.Next(0, 999);
            final += num.ToString("000");

            return final;
        }

        /// <summary>
        /// Translate the model hash into its real name.
        /// </summary>
        /// <param name="veh">Vehicle</param>
        /// <returns>Vehicle model name</returns>
        public static string GetModelName(GTA.Vehicle veh)
        {
            string model = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, veh.Model.Hash);
            return Game.GetGXTEntry(model);
        }
        /// <summary>
        /// Translate the model hash into its real name.
        /// </summary>
        /// <param name="hash">Hash of the vehicle</param>
        /// <returns>Vehicle model name</returns>
        public static string GetModelName(VehicleHash hash)
        {
            string model = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, (int)hash);
            return Game.GetGXTEntry(model);
        }

        /// <summary>
        /// Returns a comprehensive name for the vehicle.
        /// </summary>
        /// <param name="veh">Vehicle</param>
        /// <param name="showClassName">Set to true to show the class name</param>
        /// <returns>[Model of the vehicle] - [Plate's number] ([Class name of the vehicle])</returns>
        public static string GetVehicleFriendlyName(GTA.Vehicle veh, bool showClassName = true)
        {
            string friendlyname = "";

            int modelClass = Function.Call<int>(Hash.GET_VEHICLE_CLASS_FROM_NAME, veh.Model.Hash);
            string modelClassName = Game.GetGXTEntry("VEH_CLASS_" + modelClass.ToString());

            string model = Function.Call<string>(Hash.GET_DISPLAY_NAME_FROM_VEHICLE_MODEL, veh.Model.Hash);
            string modelName = Game.GetGXTEntry(model);

            if (showClassName)
                friendlyname = modelName + " - " + veh.NumberPlate + " (" + modelClassName + ")";
            else
                friendlyname = modelName + " - " + veh.NumberPlate;

            return friendlyname;
        }

        /// <summary>
        /// Check if the vehicle is the player "official" vehicle (the one with the colored blip).
        /// </summary>
        /// <param name="veh">Vehicle to check</param>
        /// <returns>True if the vehicle is an official player vehicle</returns>
        public static bool IsPlayerOfficialVehicle(GTA.Vehicle veh)
        {
            // Michael
            if (((uint)veh.Model.Hash == (uint)VehicleHash.Tailgater && veh.NumberPlate == "5MDS003 ") ||
                ((uint)veh.Model.Hash == (uint)VehicleHash.Premier && veh.NumberPlate == "880HS955"))
                return true;

            // Franklin
            if (((uint)veh.Model.Hash == (uint)VehicleHash.Buffalo2 && veh.NumberPlate == " FC1988 ") ||
                ((uint)veh.Model.Hash == (uint)VehicleHash.Bagger && veh.NumberPlate == "  FC88  "))
                return true;

            // Trevor
            if ((uint)veh.Model.Hash == (uint)VehicleHash.Bodhi2 && veh.NumberPlate == "BETTY 32")
                return true;

            return false;
        }


        /// <summary>
        /// Spawns a copy of a vehicle.
        /// </summary>
        /// <param name="coordinates">Position of the new vehicle</param>
        /// <param name="heading">Heading of the new vehicle</param>
        /// <param name="oldVeh">Vehicle to copy</param>
        /// <returns>New vehicle handle</returns>
        public static GTA.Vehicle SpawnCopyVehicle(Vector3 coordinates, float heading, GTA.Vehicle oldVeh)
        {
            GTA.Vehicle veh = GTA.World.CreateVehicle(oldVeh.Model, coordinates, heading);

            try
            {
                // Plate
                veh.NumberPlate = oldVeh.NumberPlate;
                veh.NumberPlateType = oldVeh.NumberPlateType;

                // Wheels
                veh.WheelType = oldVeh.WheelType;

                // Mods
                bool customTire1 = Function.Call<bool>(Hash.GET_VEHICLE_MOD_VARIATION, oldVeh, 23);
                bool customTire2 = Function.Call<bool>(Hash.GET_VEHICLE_MOD_VARIATION, oldVeh, 24);  // Bike only

                if (Function.Call<int>(Hash.GET_NUM_MOD_KITS, oldVeh) != 0)
                {
                    veh.InstallModKit();

                    foreach (VehicleMod mod in Enum.GetValues(typeof(VehicleMod)))
                    {
                        if (mod == VehicleMod.FrontWheels)
                            veh.SetMod(VehicleMod.FrontWheels, oldVeh.GetMod(VehicleMod.FrontWheels), Function.Call<bool>(Hash.GET_VEHICLE_MOD_VARIATION, oldVeh, 23));
                        else if (mod == VehicleMod.BackWheels)
                            veh.SetMod(VehicleMod.FrontWheels, oldVeh.GetMod(VehicleMod.FrontWheels), Function.Call<bool>(Hash.GET_VEHICLE_MOD_VARIATION, oldVeh, 24));
                        else
                            veh.SetMod(mod, oldVeh.GetMod(mod), false);
                    }
                    foreach (VehicleToggleMod mod in Enum.GetValues(typeof(VehicleToggleMod)))
                        veh.ToggleMod(mod, oldVeh.IsToggleModOn(mod));
                    
                }
                veh.WindowTint = oldVeh.WindowTint;

                // Tire's smoke color
                veh.TireSmokeColor = oldVeh.TireSmokeColor;
                veh.CanTiresBurst = oldVeh.CanTiresBurst;

                // Neons
                foreach (VehicleNeonLight neon in Enum.GetValues(typeof(VehicleNeonLight)))
                    veh.SetNeonLightsOn(neon, oldVeh.IsNeonLightsOn(neon));

                // Color
                veh.ClearCustomPrimaryColor();
                veh.ClearCustomSecondaryColor();

                if (oldVeh.IsPrimaryColorCustom)
                    veh.CustomPrimaryColor = oldVeh.CustomPrimaryColor;
                if (oldVeh.IsSecondaryColorCustom)
                    veh.CustomSecondaryColor = oldVeh.CustomSecondaryColor;

                veh.PrimaryColor = oldVeh.PrimaryColor;
                veh.SecondaryColor = oldVeh.SecondaryColor;
                veh.PearlescentColor = oldVeh.PearlescentColor;
                veh.RimColor = oldVeh.RimColor;
                veh.DashboardColor = oldVeh.DashboardColor;
                veh.TrimColor = oldVeh.TrimColor;

                // Convertible
                // 0 -> up ; 1->lowering down ; 2->down ; 3->raising up
                if (oldVeh.IsConvertible)
                    veh.RoofState = oldVeh.RoofState;

                // Extra
                for (int i = 1; i < 15; i++)
                    veh.ToggleExtra(i, oldVeh.IsExtraOn(i));
                
                // Liveries
                veh.Livery = oldVeh.Livery;
                SetVehicleLivery2(veh, GetVehicleLivery2(oldVeh));

                // Misc
                veh.NeedsToBeHotwired = false;
                veh.IsStolen = false;
            }
            catch (Exception e)
            {
                Console.Write("Error: SpawnCopyVehicle - " + e.Message);
            }

            return veh;
        }
        

        /// <summary>
        /// Number of livery2 available for the vehicle.
        /// Livery2 know usage is the roof of the TORNADO5 (Benny's custom)
        /// </summary>
        /// <param name="veh">Vehicle</param>
        /// <returns>Number of livery</returns>
        public static int GetVehicleLivery2Count(GTA.Vehicle veh)
        {
            return Function.Call<int>((Hash)0x5ECB40269053C0D4, veh);
        }

        /// <summary>
        /// Get the current index of livery2 for the vehicle.
        /// Livery2 know usage is the roof of the TORNADO5 (Benny's custom)
        /// </summary>
        /// <param name="veh">Vehicle</param>
        /// <returns>Current livery</returns>
        public static int GetVehicleLivery2(GTA.Vehicle veh)
        {
            return Function.Call<int>((Hash)0x60190048C0764A26, veh);
        }

        /// <summary>
        /// Set the current index of livery2 for the vehicle.
        /// Livery2 known usage is the roof of the TORNADO5 (Benny's custom)
        /// </summary>
        /// <param name="veh">Vehicle</param>
        /// <param name="liveryNumber">Livery ID to set to the vehicle</param>
        public static void SetVehicleLivery2(GTA.Vehicle veh, int liveryNumber)
        {
            Function.Call((Hash)0xA6D3A8750DC73270, veh, liveryNumber);
        }

    }
}
