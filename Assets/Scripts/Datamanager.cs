using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Datamanager : MonoBehaviour 
{
	private MyListener myListener;
	private GameObject moodMetricManager;
	public float currData;
	public float prevData;
	public float scale = 1;
	// Use this for initialization
	void Start () 
	{
		myListener = (MyListener)GameObject.FindObjectOfType(typeof(MyListener));
	}
	
	// Update is called once per frame
	void Update () 
	{
        //prevData = currData;
        currData = myListener.mmValue;
	}
}
