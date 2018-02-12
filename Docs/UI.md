# UI #

Displaying things on screen (text, textures, etc.). 

---

#### Method SE.UI.WaitAndhideUI(System.Int32)

 Wait the duration time and hide the ui. 

|Name | Description |
|-----|------|
|duration ||


---
#### Method SE.UI.DisplayHelpTextThisFrame(System.String)

 Display help text (Top left corner, can contain Keypress icons). ! Needs to be called every frame ! 

|Name | Description |
|-----|------|
|text ||


---
#### Method SE.UI.DrawNotification(System.String,System.Boolean)

 Display a simple notification. 

|Name | Description |
|-----|------|
|text ||
|sound |Emit notification sound (disable by default)|


---
#### Method SE.UI.DrawNotification(System.String,System.String,System.String,System.String,System.Boolean)

 Display a notification with a picture. 

|Name | Description |
|-----|------|
|picture ||
|title ||
|subtitle ||
|message ||
|sound |Emit notification sound (enable by default)|


---
#### Method SE.UI.DrawText(System.String,System.Int32,System.Boolean,System.Single,System.Single,System.Single,System.Int32,System.Int32,System.Int32,System.Int32)

 Display a text on the screen. ! Needs to be called every frame ! 

|Name | Description |
|-----|------|
|text ||
|font ||
|centre ||
|x ||
|y ||
|scale ||
|r ||
|g ||
|b ||
|a ||


---
#### Method SE.UI.DrawTexture(System.String,System.Int32,System.Single,System.Single,System.Boolean,System.Int32,System.Int32)

 Draw a texture file on the screen. 

|Name | Description |
|-----|------|
|fileName ||
|time ||
|x ||
|y ||
|centre ||
|index ||
|level ||


---
#### Method SE.UI.DrawTexture(System.String,System.Int32,System.Single,System.Single,System.Drawing.Color,System.Boolean,System.Int32,System.Int32)

 Draw a texture file on the screen and apply a color to it. 

|Name | Description |
|-----|------|
|fileName ||
|time ||
|x ||
|y ||
|color ||
|centre ||
|index ||
|level ||


---
#### Method SE.UI.GetSpriteCoordinatesFromFloat(System.Drawing.Image,System.Single,System.Single,System.Boolean)

 Return pixels coordinates from float coordinates while dealing with the picture size. 

|Name | Description |
|-----|------|
|sprite ||
|x ||
|y ||
|centre ||
**Returns**: 
