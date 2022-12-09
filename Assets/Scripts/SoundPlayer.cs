using UnityEngine;
using System.Collections;

public class SoundPlayer : MonoBehaviour {
	public AudioSource nextForegroundSource;
	public AudioSource nextBackgroundSource;
		
	IEnumerator Start() {
		GetComponent<AudioSource>().Play();
		yield return new WaitForSeconds(GetComponent<AudioSource>().clip.length);

		nextBackgroundSource.GetComponent<AudioSource>().Play();
		nextForegroundSource.GetComponent<AudioSource>().Play();
	}
}
