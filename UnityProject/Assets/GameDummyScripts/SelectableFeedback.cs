#if (UNITY_EDITOR || UNITY_STANDALONE)
using UnityEngine;

public class SelectableFeedback : MonoBehaviour
{
    private IStyledSelectable _styledSelectable;

    public StyledSelectableState currentState;

    [SerializeField] protected bool _onHighlighted;

    [SerializeField] protected bool _onPress;

    [SerializeField] protected bool _onSelected;

    [SerializeField] protected bool _onDisabled;

    [SerializeField] protected bool _onIsOn;

    [SerializeField] protected float _fadeDuration;

    protected bool _disabled;

    public bool IsInteractable => false;

    public bool IsToggle => false;

    public bool IsOn => false;

    public bool IsToggleAndOn => false;

    public bool IsPointerInside => false;

    public bool IsPointerDown => false;

    public bool IsSelected => false;

    public bool IsSubmitted => false;

    public bool IsDisabled => false;

    public StyledSelectableState SelectableState => default;

    public IStyledSelectable StyledSelectable => null;

    private void OnEnable()
    {
    }

    private void OnDisable()
    {
    }

    private void OnStateUpdate()
    {
    }

    protected virtual void OnStateTransition(StyledSelectableState newState)
    {
    }

    protected virtual void ResetState()
    {
    }
}
#endif