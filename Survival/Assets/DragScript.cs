using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragScript : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
{

    public void OnBeginDrag(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }
    public void OnDrag(PointerEventData eventData) {
        transform.position = eventData.position;
    }

    public void OnEndDrag(PointerEventData eventData) {
        throw new System.NotImplementedException();
    }
}
