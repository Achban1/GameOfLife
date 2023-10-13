using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SpawnRateSliderScript : MonoBehaviour
{
    public TextMeshProUGUI sliderText;
    public Slider SpawnRateSlider;

    private void Start()
    {
        if (SliderValueManager.instance != null)
        {
            SpawnRateSlider.value = SliderValueManager.instance.spawnRateValue;
        }

        UpdateValueDisplay(SpawnRateSlider.value);

        SpawnRateSlider.onValueChanged.AddListener(UpdateValueInManager);

    }

    private void UpdateValueInManager(float value)
    {
        if (SliderValueManager.instance != null)
        {
            SliderValueManager.instance.spawnRateValue = value;
        }

        UpdateValueDisplay(value);
    }

    private void UpdateValueDisplay(float value)
    {
        sliderText.text = value.ToString("F2");
    }
}
