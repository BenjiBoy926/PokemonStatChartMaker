using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class SnapShotMode : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Slider[] _sliders;
    private bool _isActive = false;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void Update()
    {
        if (AnyTouchOrMouseClickDetected() && _isActive)
        {
            SetActive(false);
        }
    }

    private bool AnyTouchOrMouseClickDetected()
    {
        return Input.GetMouseButtonDown(0) || TouchBegan();
    }

    private bool TouchBegan()
    {
        return Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began;
    }

    private void OnButtonClicked()
    {
        SetActive(true);
    }

    private void SetActive(bool isActive)
    {
        _isActive = isActive;
        ReflectIsActive();
    }

    private void ReflectIsActive()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].targetGraphic.enabled = !_isActive;
        }
        _button.gameObject.SetActive(!_isActive);
    }

    private void Reset()
    {
        _sliders = FindObjectsOfType<Slider>();
    }
}