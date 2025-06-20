#if (UNITY_EDITOR || UNITY_STANDALONE)
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.CompilerServices;
using UnityEngine;

public class ScaleFeedback : SelectableFeedback
{
    public RectTransform[] targetTransforms;

    [SerializeField]
    private float _highlightedScale;

    [SerializeField]
    private float _pressedScale;

    [SerializeField]
    private float _selectedScale;

    [SerializeField]
    private float _disabledScale;

    [SerializeField]
    private float _isOnScale;

    private readonly List<Vector3> _initialScales;

    private WaitForEndOfFrame _waitForEndOfFrame;

    private Coroutine _coroutine;

    private bool _isRunning;

    private void Awake() { }

    protected override void OnStateTransition(StyledSelectableState newState) { }

    private void ScaleToNormal() { }

    private void ScaleTo(float amount) { }

    private IEnumerator PlayScale(List<Vector3> endValues) => null;

    protected override void ResetState() { }
}
#endif