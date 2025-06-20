#if (UNITY_EDITOR || UNITY_STANDALONE)
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.UI;

public class ColorFeedback : SelectableFeedback
{
    public Graphic[] targetGraphics;

    [SerializeField]
    private Color _normalColor;

    [SerializeField]
    private Color _highlightedColor;

    [SerializeField]
    private Color _pressedColor;

    [SerializeField]
    private Color _selectedColor;

    [SerializeField]
    private Color _disabledColor;

    [SerializeField]
    private Color _isOnColor;

    private WaitForEndOfFrame _waitForEndOfFrame;

    private Coroutine _coroutine;

    private bool _isRunning;

    private void Awake() { }

    protected override void OnStateTransition(StyledSelectableState newState) { }

    private void FadeColorTo(Color color) { }

    private IEnumerator PlayFadeColor(Color endValue) => null;

    protected override void ResetState() { }
}
#endif