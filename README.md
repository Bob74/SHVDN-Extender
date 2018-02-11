# SHVDN-Extender

ScriptHookVDotNet Extender is a work in progress developper library adding functionalities to SHVDN.

---

[Camera](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Camera.md)
---
```C#
enum ScreenEffect
Camera.Fade(int, int)
Camera.StartScreenEffect(SE.ScreenEffect)
Camera.StopScreenEffect(SE.ScreenEffect)
Camera.StopAllScreenEffect()
```

[Control](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Control.md)
---
```C#
enum InputGroups
```

[Phone](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Phone.md)
---
```C#
Phone.DestroyPhone(int)
Phone.GetPhoneSoundSet()
```

[Player](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Player.md)
---
```C#
Player.GetCurrentCharacterID()
Player.GetCurrentCharacterName(bool)
Player.AddCashToPlayer(int)
```

[Script](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Script.md)
---
```C#
Script.StartScript(string, int)
Script.TerminateScript(string)
```

[UI](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/UI.md)
---
```C#
UI.WaitAndhideUI(int)
UI.DisplayHelpTextThisFrame(string)
UI.DrawNotification(string, bool)
UI.DrawNotification(string, string, string, string, bool)
UI.DrawText(string, int, bool, float, float, float, int, int, int, int)
UI.DrawTexture(string, int, float, float, bool, int, int)
UI.DrawTexture(string, int, float, float, System.Drawing.Color, bool, int, int)
UI.GetSpriteCoordinatesFromFloat(System.Drawing.Image, float, float, bool)
```

[Vehicle](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Vehicle.md)
---
```C#
enum Wheel
Dictionary Vehicle.WheelsBones
Vehicle.GetRandomNumberPlate()
Vehicle.GetModelName(GTA.Vehicle)
Vehicle.GetModelName(GTA.Native.VehicleHash)
Vehicle.GetVehicleFriendlyName(GTA.Vehicle, bool)
Vehicle.IsPlayerOfficialVehicle(GTA.Vehicle)
Vehicle.SpawnCopyVehicle(Vector3, float, GTA.Vehicle)
Vehicle._GET_VEHICLE_LIVERY2_COUNT(GTA.Vehicle)
Vehicle._GET_VEHICLE_LIVERY2(GTA.Vehicle)
Vehicle._SET_VEHICLE_LIVERY2(GTA.Vehicle, int)
```

[World](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/World.md)
---
```C#
RequestIpl(string)
DrawMarker(Vector3)
DrawMarker(Vector3, System.Drawing.Color)
DrawMarker(GTA.MarkerType, Vector3, Vector3)
DrawMarker(GTA.MarkerType, Vector3, Vector3, System.Drawing.Color)
```
