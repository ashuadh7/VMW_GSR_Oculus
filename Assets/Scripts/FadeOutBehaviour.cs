using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeOutBehaviour : MonoBehaviour {

    private SpriteRenderer spr;
    public AudioSource meditationAudioSource;
    private void Start ()
    {
        spr = GetComponent<SpriteRenderer>();
        meditationAudioSource.Play();
	}
	
	private void Update ()
    {
        spr.material.color = Color.Lerp(spr.material.color,
                                        Color.clear, Time.deltaTime * 4.0f);

        if (spr.material.color.a <= 0.1f)
        {
            spr.material.color = Color.clear;    
        }
	}

    private void OnEnable()
    {
        meditationAudioSource.Play();
    }
}
