#if (UNITY_EDITOR || UNITY_STANDALONE)
using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RectTransform), typeof(Graphic))]
[DisallowMultipleComponent]
[AddComponentMenu("UI/Effects/ShearRect")]
public class ShearRect : BaseMeshEffect
{
    [SerializeField] private float _horizontalShear;

    [SerializeField] private float _verticalShear;

    private RectTransform _rectTransform;

    public RectTransform rectTransform => null;

    public override void ModifyMesh(VertexHelper vh)
    {
    }
}
#endif