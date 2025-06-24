#if (UNITY_EDITOR || UNITY_STANDALONE)
using System;

namespace Nvizzio.Game.UI.Views
{
    [Flags]
    public enum TooltipAlignment
    {
        None = 0,
        UpperLeft = 1,
        UpperCenter = 2,
        UpperRight = 4,
        MiddleLeft = 8,
        MiddleCenter = 0x10,
        MiddleRight = 0x20,
        LowerLeft = 0x40,
        LowerCenter = 0x80,
        LowerRight = 0x100
    }
}
#endif