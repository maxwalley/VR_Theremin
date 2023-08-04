using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Theremin_Slider_Interaction : MonoBehaviour
{
    public Slider frequencySlider;
    public Slider volumeSlider;

    Theremin_Player theremin;

    void Start()
    {
        theremin = gameObject.GetComponent<Theremin_Player>();

        theremin.setFrequency(frequencySlider.value);
        theremin.setAmplitude(volumeSlider.value);

        frequencySlider.onValueChanged.AddListener(theremin.setFrequency);
        volumeSlider.onValueChanged.AddListener(theremin.setAmplitude);
    }

    void Update()
    {
        
    }
}
