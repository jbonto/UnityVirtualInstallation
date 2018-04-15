using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaySoundClipOnEnter : MonoBehaviour {
	public AudioClip Soundeffect;
	private AudioSource Audio;
	public float soundCutOffTime;
	// Use this for initialization
	void Start () {
		Audio = GetComponent<AudioSource> ();
	}
	
	void OnTriggerEnter(Collider other){
		Audio.PlayOneShot(Soundeffect);
		if (soundCutOffTime > 0f)
			StartCoroutine (stopSound ());

	}
	IEnumerator stopSound(){
		yield return new WaitForSeconds (soundCutOffTime);
		Audio.Stop ();
	}
}
