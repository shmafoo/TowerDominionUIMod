#if (UNITY_EDITOR || UNITY_STANDALONE)
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Events;
using UnityEngine.UI;

public class StyledButton : Button, IStyledSelectable
{
    public UnityEvent onHoverEnter;
    public UnityEvent onHoverExit;
    public UnityEvent onSelect;
    public UnityEvent onDeselect;

    [SerializeField] private Selectable _upSelectable;
    [SerializeField] private Selectable _downSelectable;
    [SerializeField] private Selectable _leftSelectable;
    [SerializeField] private Selectable _rightSelectable;

    [SerializeField] private bool _autoUp;
    [SerializeField] private bool _autoDown;
    [SerializeField] private bool _autoLeft;
    [SerializeField] private bool _autoRight;

    private Navigation _navigation;

    public Action OnStateUpdate { get; set; }
    public bool IsPointerInside { get; set; }
    public bool IsPointerDown { get; set; }
    public bool IsSelected { get; set; }
    public bool IsSubmitted { get; set; }
    public bool IsDisabled { get; set; }

    protected override void OnDisable()
    {
    }

    protected override void DoStateTransition(SelectionState state, bool instant)
    {
    }

    private void NotifyStateUpdateToListeners()
    {
    }

    public override void OnPointerEnter(PointerEventData eventData)
    {
    }

    public override void OnPointerExit(PointerEventData eventData)
    {
    }

    public override void OnPointerDown(PointerEventData eventData)
    {
    }

    public override void OnPointerUp(PointerEventData eventData)
    {
    }

    public override void OnSelect(BaseEventData eventData)
    {
    }

    public override void OnDeselect(BaseEventData eventData)
    {
    }

    public override void OnSubmit(BaseEventData eventData)
    {
    }

    private IEnumerator OnFinishSubmit()
    {
        return null;
    }

    public void OnValueChanged(bool isOn)
    {
    }

    public override Selectable FindSelectableOnUp()
    {
        return null;
    }

    public override Selectable FindSelectableOnDown()
    {
        return null;
    }

    public override Selectable FindSelectableOnRight()
    {
        return null;
    }

    public override Selectable FindSelectableOnLeft()
    {
        return null;
    }

    public void SetNavigation(IStyledSelectable up, IStyledSelectable down, IStyledSelectable right,
        IStyledSelectable left)
    {
    }
}
#endif