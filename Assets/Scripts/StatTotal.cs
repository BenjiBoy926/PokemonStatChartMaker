using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class StatTotal : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _label;
    [SerializeField]
    private Slider[] _sliders = Array.Empty<Slider>();

    private void OnEnable()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].onValueChanged.AddListener(OnSliderValueChanged);
        }
        RefreshLabel();
    }
    private void OnDisable()
    {
        for (int i = 0; i < _sliders.Length; i++)
        {
            _sliders[i].onValueChanged.RemoveListener(OnSliderValueChanged);
        }
    }

    private void OnSliderValueChanged(float value)
    {
        RefreshLabel();
    }

    private void RefreshLabel()
    {
        if (!_label) return;

        float total = 0;
        for (int i = 0; i < _sliders.Length; i++)
        {
            total += _sliders[i].value;
        }
        _label.text = total.ToString();
    }

    private void Reset()
    {
        _sliders = GetComponentsInChildren<Slider>();
    }
}
