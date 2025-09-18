using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SliderHandle : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    [SerializeField]
    private Transform _sizeTransform;

    public void OnPointerDown(PointerEventData eventData)
    {
        Grow();
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Shrink();
    }

    private void Grow()
    {
        _sizeTransform.localScale = new(4, 4, 4);
    }

    private void Shrink()
    {
        _sizeTransform.localScale = Vector3.one;
    }
}
