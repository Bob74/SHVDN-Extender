# SHVDN-Extender

ScriptHookVDotNet Extender is a work in progress developper library adding functionalities to SHVDN.

---

[Camera](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Camera.md)
---
```C#
Camera.Fade(System.Int32,System.Int32)
Camera.StartScreenEffect(SE.ScreenEffect)
Camera.StopScreenEffect(SE.ScreenEffect)
Camera.StopAllScreenEffect
```

[ScreenEffect](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/ScreenEffect.md)
---
Enum containing all screen effects.

[Control](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Control.md)
---
```C#
```

[InputGroups](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/InputGroups.md)
---
Enum containing control's input groups.

[Phone](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Phone.md)
---
```C#
Phone.DestroyPhone(System.Int32)
Phone.GetPhoneSoundSet
```

[Player](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Player.md)
---
```C#
Player.GetCurrentCharacterID
Player.GetCurrentCharacterName(System.Boolean)
Player.AddCashToPlayer(System.Int32)
```

[Script](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Script.md)
---
```C#
Script.StartScript(System.String,System.Int32)
Script.TerminateScript(System.String)
```

[UI](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/UI.md)
---
```C#
UI.WaitAndhideUI(System.Int32)
UI.DisplayHelpTextThisFrame(System.String)
UI.DrawNotification(System.String,System.Boolean)
UI.DrawNotification(System.String,System.String,System.String,System.String,System.Boolean)
UI.DrawText(System.String,System.Int32,System.Boolean,System.Single,System.Single,System.Single,System.Int32,System.Int32,System.Int32,System.Int32)
UI.DrawTexture(System.String,System.Int32,System.Single,System.Single,System.Boolean,System.Int32,System.Int32)
UI.DrawTexture(System.String,System.Int32,System.Single,System.Single,System.Drawing.Color,System.Boolean,System.Int32,System.Int32)
UI.GetSpriteCoordinatesFromFloat(System.Drawing.Image,System.Single,System.Single,System.Boolean)
```

[Wheel](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Wheel.md)
---
Enum containing all vehicles wheels.

[Vehicle](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/Vehicle.md)
---
```C#
Vehicle.WheelsBones
Vehicle.GetRandomNumberPlate
Vehicle.GetModelName(GTA.Vehicle)
Vehicle.GetModelName(GTA.Native.VehicleHash)
Vehicle.GetVehicleFriendlyName(GTA.Vehicle,System.Boolean)
Vehicle.IsPlayerOfficialVehicle(GTA.Vehicle)
Vehicle.SpawnCopyVehicle(GTA.Math.Vector3,System.Single,GTA.Vehicle)
Vehicle.GetVehicleLivery2Count(GTA.Vehicle)
Vehicle.GetVehicleLivery2(GTA.Vehicle)
Vehicle.SetVehicleLivery2(GTA.Vehicle,System.Int32)
```

[World](https://github.com/Bob74/SHVDN-Extender/blob/master/Docs/World.md)
---
```C#
World.RequestIpl(System.String)
World.DrawMarker(GTA.Math.Vector3)
World.DrawMarker(GTA.Math.Vector3,System.Drawing.Color)
World.DrawMarker(GTA.MarkerType,GTA.Math.Vector3,GTA.Math.Vector3)
World.DrawMarker(GTA.MarkerType,GTA.Math.Vector3,GTA.Math.Vector3,System.Drawing.Color)
```
