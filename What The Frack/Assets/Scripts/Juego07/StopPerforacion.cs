using UnityEngine;
using System.Collections;

public class StopPerforacion : MonoBehaviour {
	public bool isTouchPoint=false;
	public AudioSource _Sfxaudio;
	public AudioClip sfxClip;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "PuntoObjetivo") {
			_Sfxaudio.Stop();
			_Sfxaudio.loop=false;
			isTouchPoint=true;
			Destroy(coll.gameObject);
		}
	}
}
