using UnityEngine;
using System.Collections;

public class FPS : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		float FPS = (1/Time.smoothDeltaTime);
		GetComponent<GUIText>().text=FPS.ToString();
	}
}
