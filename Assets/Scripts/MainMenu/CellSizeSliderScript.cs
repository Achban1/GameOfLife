using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CellSizeSliderScript : MonoBehaviour
{
    public TextMeshProUGUI sliderText;
    public Slider cellSizeSlider;

    private void Start()
    {
        if (SliderValueManager.instance != null)
        {
            cellSizeSlider.value = SliderValueManager.instance.cellSizeValue;
        }

        UpdateValueDisplay(cellSizeSlider.value);

        cellSizeSlider.onValueChanged.AddListener(UpdateValueInManager);
    }

    private void UpdateValueInManager(float value)
    {
        if (SliderValueManager.instance != null)
        {
            SliderValueManager.instance.cellSizeValue = value;
        }

        UpdateValueDisplay(value);
    }

    private void UpdateValueDisplay(float value)
    {
        sliderText.text = value.ToString("F2");
    }
}
