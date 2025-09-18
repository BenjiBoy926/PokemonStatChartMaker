using UnityEngine;
using UnityEngine.EventSystems;

public class SliderHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public void OnPointerDown(PointerEventData eventData)
    {
        transform.localScale = new(4, 4, 4);
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        transform.localScale = Vector3.one;
    }
}
