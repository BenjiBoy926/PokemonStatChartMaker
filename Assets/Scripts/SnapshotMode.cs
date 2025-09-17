using UnityEngine;
using UnityEngine.UI;

public class SnapShotMode : MonoBehaviour
{
    [SerializeField]
    private Button _button;
    [SerializeField]
    private Slider[] _sliders;

    private void Awake()
    {
        _button.onClick.AddListener(OnButtonClicked);
    }

    private void OnDestroy()
    {
        _button.onClick.RemoveListener(OnButtonClicked);
    }

    private void OnButtonClicked()
    {
        SetActive(true);
    }

    private void SetActive(bool active)
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].targetGraphic.enabled = !active;
        }
        _button.gameObject.SetActive(!active);
    }

    private void Reset()
    {
        _sliders = FindObjectsOfType<Slider>();
    }
}