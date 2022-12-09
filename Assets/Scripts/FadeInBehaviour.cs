using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeInBehaviour : MonoBehaviour {

    private SpriteRenderer spr;

    public AudioSource meditationAudioSource;

    private void Start()
    {
        spr = GetComponent<SpriteRenderer>();
        if(spr.enabled == false)
        {
            spr.material.color = Color.clear;
            spr.enabled = true;
        }
        
    }

    private void Update()
    {
        spr.material.color = Color.Lerp(spr.material.color,
                                        Color.white, Time.deltaTime * 4.0f);
        if (spr.material.color.a >= 0.9f)
        {
            spr.material.color = Color.white;
        }
    }
    private void OnEnable()
    {
        meditationAudioSource.Pause();
    }
}
