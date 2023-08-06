using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Theremin_Player : MonoBehaviour
{
    AudioSource source;

    int sampleRate = 48000;
    double phase = 0.0;
    double phaseIncrement = 0.0;
    float amplitude = 0.0f; 

    void Start()
    {
        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 0.0f;

        source.clip = AudioClip.Create("Theremin", sampleRate, 1, sampleRate, false, true, GenerateAudio);

        source.loop = true;
        source.Play();
    }

    public void setFrequency(float newFrequency)
    {
        //Constrain frequency to audible range
        newFrequency = Math.Min(newFrequency, 20000.0f);
        newFrequency = Math.Max(newFrequency, 20.0f);

        double newPhaseIncrement = Mathf.PI * 2.0 * newFrequency / sampleRate;

        Interlocked.Exchange(ref phaseIncrement, newPhaseIncrement);
    }

    public void setAmplitude(float newAmplitude)
    {
        //Constrain amplitude to acceptable range
        newAmplitude = Math.Min(newAmplitude, 1.0f);
        newAmplitude = Math.Max(newAmplitude, 0.0f);

        Interlocked.Exchange(ref amplitude, newAmplitude);
    }

    void GenerateAudio(float[] data)
    {
        for(int sampleIndex = 0; sampleIndex < data.Length; ++sampleIndex)
        {
            data[sampleIndex] = Mathf.Sin((float)phase) * amplitude;

            phase += phaseIncrement;

            if(phase > Mathf.PI * 2.0)
            {
                phase -= Mathf.PI * 2.0;
            }
        }
    }
}
