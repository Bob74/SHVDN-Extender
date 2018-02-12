# Vehicle #

Vehicles informations and functions. 

---

#### Field SE.Vehicle.WheelsBones

 Get the bone's name from the wheel. 



---
#### Method SE.Vehicle.GetRandomNumberPlate

 Generate a random number plate. GTA V number plate format: 00AAA000 

**Returns**: Random plate number



---
#### Method SE.Vehicle.GetModelName(GTA.Vehicle)

 Translate the model hash into its real name. 

|Name | Description |
|-----|------|
|veh |Vehicle|
**Returns**: Vehicle model name



---
#### Method SE.Vehicle.GetModelName(GTA.Native.VehicleHash)

 Translate the model hash into its real name. 

|Name | Description |
|-----|------|
|hash |Hash of the vehicle|
**Returns**: Vehicle model name



---
#### Method SE.Vehicle.GetVehicleFriendlyName(GTA.Vehicle,System.Boolean)

 Returns a comprehensive name for the vehicle. 

|Name | Description |
|-----|------|
|veh |Vehicle|
|showClassName |Set to true to show the class name|
**Returns**: [Model of the vehicle] - [Plate's number] ([Class name of the vehicle])



---
#### Method SE.Vehicle.IsPlayerOfficialVehicle(GTA.Vehicle)

 Check if the vehicle is the player "official" vehicle (the one with the colored blip). 

|Name | Description |
|-----|------|
|veh |Vehicle to check|
**Returns**: True if the vehicle is an official player vehicle



---
#### Method SE.Vehicle.SpawnCopyVehicle(GTA.Math.Vector3,System.Single,GTA.Vehicle)

 Spawns a copy of a vehicle. 

|Name | Description |
|-----|------|
|coordinates |Position of the new vehicle|
|heading |Heading of the new vehicle|
|oldVeh |Vehicle to copy|
**Returns**: New vehicle handle



---
#### Method SE.Vehicle.GetVehicleLivery2Count(GTA.Vehicle)

 Number of livery2 available for the vehicle. Livery2 know usage is the roof of the TORNADO5 (Benny's custom) 

|Name | Description |
|-----|------|
|veh |Vehicle|
**Returns**: Number of livery



---
#### Method SE.Vehicle.GetVehicleLivery2(GTA.Vehicle)

 Get the current index of livery2 for the vehicle. Livery2 know usage is the roof of the TORNADO5 (Benny's custom) 

|Name | Description |
|-----|------|
|veh |Vehicle|
**Returns**: Current livery



---
#### Method SE.Vehicle.SetVehicleLivery2(GTA.Vehicle,System.Int32)

 Set the current index of livery2 for the vehicle. Livery2 known usage is the roof of the TORNADO5 (Benny's custom) 

|Name | Description |
|-----|------|
|veh |Vehicle|
|liveryNumber |Livery ID to set to the vehicle|
