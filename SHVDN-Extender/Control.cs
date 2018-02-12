using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SE
{
    /// <summary>
    /// 
    /// </summary>
    public static class Control
    {
    }

    /// <summary>
    /// Contains the different control's input groups.
    /// </summary>
    public enum InputGroups
    {
        Move,
        Look,
        Wheel,
        CellphoneNavigate,
        CellphoneNavigateUd,
        CellphoneNavigateLr,
        FrontendDpadAll,
        FrontendDpadUd,
        FrontendDpadLr,
        FrontendLstickAll,
        FrontendRstickAll,
        FrontendGenericUd,
        FrontendGenericLr,
        FrontendGenericAll,
        FrontendBumpers,
        FrontendTriggers,
        FrontendSticks,
        ScriptDpadAll,
        ScriptDpadUd,
        ScriptDpadLr,
        ScriptLstickAll,
        ScriptRstickAll,
        ScriptBumpers,
        ScriptTriggers,
        WeaponWheelCycle,
        Fly,
        Sub,
        VehMoveAll,
        Cursor,
        CursorScroll,
        SniperZoomSecondary,
        VehHydraulicsControl,
    }
}
