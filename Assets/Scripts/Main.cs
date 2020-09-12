using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    private AudioSource m_audiosource;
    public AudioClip audioclip;
    public float[] samples;
    public LineRenderer linerender;

    private readonly int LINERENDER_POINT_CNT = 32;


    void Start()
    {
        m_audiosource = gameObject.GetComponent<AudioSource>();
        m_audiosource.clip = audioclip;
        m_audiosource.Play();
        samples = new float[1024];
        linerender.positionCount = LINERENDER_POINT_CNT;
        linerender.startWidth = 0.02f;
        linerender.endWidth = 0.02f;

    }

    // Update is called once per frame
    void Update()
    {
        m_audiosource.GetSpectrumData(samples, 0, FFTWindow.BlackmanHarris);
        for (int i = 0, cnt = LINERENDER_POINT_CNT; i < cnt; ++i)
        {
            var v = samples[i];
            linerender.SetPosition(i, new Vector3((i - LINERENDER_POINT_CNT / 2) * 0.2f, v * 20, -5));

        }
    }
}
