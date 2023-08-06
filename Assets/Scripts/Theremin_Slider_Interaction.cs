using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Theremin_Slider_Interaction : MonoBehaviour
{
    public Slider frequencySlider;
    public Slider volumeSlider;

    private float maxLogFreq = Mathf.Log(18000.0f);
    private float minLogFreq = Mathf.Log(50.0f);

    Theremin_Player theremin;

    void Start()
    {
        theremin = gameObject.GetComponent<Theremin_Player>();

        theremin.setFrequency(frequencySlider.value);
        theremin.setAmplitude(volumeSlider.value);

        frequencySlider.onValueChanged.AddListener(setLogFrequency);
        volumeSlider.onValueChanged.AddListener(theremin.setAmplitude);
    }

    void setLogFrequency(float sliderVal)
    {
        float logFreq = Mathf.Lerp(minLogFreq, maxLogFreq, sliderVal);

        float freq = Mathf.Exp(logFreq);

        theremin.setFrequency(freq);
    }
}
