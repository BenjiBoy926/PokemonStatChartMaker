using TMPro;
using UnityEngine;
using UnityEngine.UI;

[ExecuteAlways]
public class Stat : MonoBehaviour
{
    [SerializeField]
    private Slider _slider;
    [SerializeField]
    private TMP_InputField _inputField;
    [SerializeField]
    private Image _sliderFill;
    [SerializeField]
    private Color _lowColor;
    [SerializeField]
    private Color _mediumColor;
    [SerializeField] 
    private Color _highColor;
    [SerializeField]
    private Color _veryHighColor;
    [SerializeField]
    private Color _maxColor;

    private void OnEnable()
    {
        if (!_slider)
        {
            _slider = GetComponentInChildren<Slider>();
        }
        if (!_inputField)
        {
            _inputField = GetComponentInChildren<TMP_InputField>();
        }
        _slider.onValueChanged.AddListener(OnSliderValueChanged);
        _inputField.onDeselect.AddListener(OnTextInputChanged);
        _inputField.onSubmit.AddListener(OnTextInputChanged);
        ReflectSliderValue();
    }

    private void OnDisable()
    {
        _slider.onValueChanged.RemoveListener(OnSliderValueChanged);
        _inputField.onDeselect.RemoveListener(OnTextInputChanged);
        _inputField.onSubmit.RemoveListener(OnTextInputChanged);
    }

    private void OnSliderValueChanged(float value)
    {
        ReflectSliderValue();
    }

    private void OnTextInputChanged(string text)
    {
        if (IsValidStat(text, out int stat))
        {
            _slider.value = ClampStat(stat);
        }
        else
        {
            ReflectSliderValue();
        }
    }

    private bool IsValidStat(string text, out int stat)
    {
        return int.TryParse(text, out stat);
    }

    private int ClampStat(int value)
    {
        return (int)Mathf.Clamp(value, _slider.minValue, _slider.maxValue);
    }

    private void ReflectSliderValue()
    {
        _inputField.text = _slider.value.ToString();
        RefreshSliderFillColor();
    }

    private void RefreshSliderFillColor()
    {
        if (!_sliderFill) return;

        if (_slider.value < 60)
        {
            _sliderFill.color = _lowColor;
        }
        else if (_slider.value < 90)
        {
            _sliderFill.color = _mediumColor;
        }
        else if (_slider.value < 120)
        {
            _sliderFill.color = _highColor;
        }
        else if (_slider.value < 150)
        {
            _sliderFill.color = _veryHighColor;
        }
        else
        {
            _sliderFill.color = _maxColor;
        }
    }
}
