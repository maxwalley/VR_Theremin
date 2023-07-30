using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Theremin_Player : MonoBehaviour
{
    AudioSource source;

    int sampleRate = 48000;
    double frequency = 1000;
    double phase = 0.0;
    double phaseIncrement = 0.0;

    void Start()
    {
        phaseIncrement = Mathf.PI * 2.0 * 442.0 / sampleRate;

        source = gameObject.AddComponent<AudioSource>();
        source.spatialBlend = 0.0f;

        source.clip = AudioClip.Create("Theremin", sampleRate, 1, sampleRate, false, true, GenerateAudio);

        source.loop = true;
        source.Play();
    }

    void GenerateAudio(float[] data)
    {
        for(int sampleIndex = 0; sampleIndex < data.Length; ++sampleIndex)
        {
            data[sampleIndex] = Mathf.Sin((float)phase);

            phase += phaseIncrement;

            if(phase > Mathf.PI * 2.0)
            {
                phase -= Mathf.PI * 2.0;
            }
        }
    }
}
