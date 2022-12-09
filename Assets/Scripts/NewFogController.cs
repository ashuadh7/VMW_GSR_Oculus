using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewFogController : MonoBehaviour 
{
	private float fogDensity = 200;
	public float speed = .1f;

	// Use this for initialization
	void Start () 
	{
		RenderSettings.fog = true;
		RenderSettings.fogMode = FogMode.Linear;
		RenderSettings.fogDensity = fogDensity;
	}
	
	// Update is called once per frame
	void Update () 
	{
		fogDensity = 200 + 400 * Mathf.Sin(speed * Time.timeSinceLevelLoad);
		RenderSettings.fogDensity = fogDensity;
		Debug.Log(fogDensity);
	}
}
