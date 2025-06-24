#if (UNITY_EDITOR || UNITY_STANDALONE)
using System;
using UnityEngine.UI;

public interface IStyledSelectable
{
    static readonly Navigation MutedNavigation;

    Action OnStateUpdate { get; set; }

    bool IsPointerInside { get; set; }

    bool IsPointerDown { get; set; }

    bool IsSelected { get; set; }

    bool IsSubmitted { get; set; }

    bool IsDisabled { get; set; }

    void SetNavigation(IStyledSelectable up, IStyledSelectable down, IStyledSelectable right, IStyledSelectable left);

    static IStyledSelectable()
    {
    }
}
#endif