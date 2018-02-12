## Wheel

Enum containing the different vehicle's wheels.

 ---
 ```C#
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
 ```
