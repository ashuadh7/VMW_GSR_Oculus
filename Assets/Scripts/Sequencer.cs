using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Sequencer : MonoBehaviour
{
    public List<AudioSource> dailySequences;
    private int currentDay;
    private int currentTrack;
	private void Start ()
    {
        string[] args = System.Environment.GetCommandLineArgs();
        if(args == null || args.Length == 0)
        {
            currentDay = 0;
        }
        else
        {
            foreach(string s in args)
            {
                if (s.Contains("day"))
                {
                    int.TryParse(s.Split('=')[1], out currentDay);
                }
            }
        }
        dailySequences[currentDay].Play();
	}
	
	private void Update ()
    {
        if (Input.GetKeyDown("1") || Input.GetKeyDown(KeyCode.Keypad1))
        {
            foreach (var item in dailySequences)
            {
                if (item.isPlaying)
                {
                    item.Stop();
                }
            }
            dailySequences[0].Play();
            
        }
        if (Input.GetKeyDown("2") || Input.GetKeyDown(KeyCode.Keypad2))
        {
            foreach (var item in dailySequences)
            {
                if (item.isPlaying)
                {
                    item.Stop();
                }
            }
            dailySequences[1].Play();

        }
        if (Input.GetKeyDown("3") || Input.GetKeyDown(KeyCode.Keypad3))
        {
            foreach (var item in dailySequences)
            {
                if (item.isPlaying)
                {
                    item.Stop();
                }
            }
            dailySequences[2].Play();

        }
        if (Input.GetKeyDown("4") || Input.GetKeyDown(KeyCode.Keypad4))
        {
            foreach (var item in dailySequences)
            {
                if (item.isPlaying)
                {
                    item.Stop();
                }
            }
            dailySequences[4].Play();

        }
        //if(dailySequences[currentDay].isPlaying == false)
        //{
        //    dailySequences[currentDay].Play();
        //}

    }
}
