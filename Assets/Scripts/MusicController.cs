using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MusicController : MonoBehaviour
{
    public List<AudioSource> musicSequences;
    private int currentDay;
    private int currentTrack = 1;
	private void Start ()
    {
        musicSequences[currentTrack - 1].Play();
	}
	
	private void Update ()
    {
        if (Input.GetKeyDown("space"))
        {
            updateAudio();
        }
    }

    private void updateAudio()
    {
        foreach (var audioClip in musicSequences)
        {
            audioClip.Stop();
        }
        currentTrack += 1;
        if (currentTrack > musicSequences.Count)
        {
            currentTrack = 1;
        }

        musicSequences[currentTrack - 1].Play();
        musicSequences[currentTrack - 1].loop = true;
    }
}
