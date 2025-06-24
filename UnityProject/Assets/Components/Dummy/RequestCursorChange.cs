#if (UNITY_EDITOR || UNITY_STANDALONE)
using Nvizzio.Game.Input;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Nvizzio.Game.UI
{
    public class RequestCursorChange : MonoBehaviour, IPointerEnterHandler, IEventSystemHandler, IPointerExitHandler
    {
        [SerializeField] private CursorType cursorType;

        private bool isPointerOver;

        public void SetCursor(CursorType cursorType)
        {
        }

        public void OnPointerEnter(PointerEventData eventData)
        {
        }

        public void OnPointerExit(PointerEventData eventData)
        {
        }
    }
}
#endif