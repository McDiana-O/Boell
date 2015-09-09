using UnityEngine;
using System.Collections;

public class SFX_Sounds : MonoBehaviour {

	public AudioClip[] efectos;
	private AudioSource _audioSuorce;
	public bool mute;
	
	// Use this for initialization
	void Awake() {
		_audioSuorce = this.GetComponent<AudioSource> ();
		if (mute) {
			_audioSuorce.mute=true;
			
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void ChangeAudio(int index)
	{
		Debug.Log(index);
		_audioSuorce.clip=efectos[index];
	}
	public void ChangeAudio(string name)
	{
		for (int i=0; i<efectos.Length; i++) {
			if(efectos[i].name==name)
			{
				_audioSuorce.clip=efectos[i];


			}
		}
		
		
	}
	
	public void SFXLoop(bool tempBool){
		_audioSuorce.loop = tempBool;
	}
	
	public void SFXMute(bool tempBool){
		_audioSuorce.mute = tempBool;
	}

	public void SFXPlay(){
		_audioSuorce.Play ();
	}
	public void SFXStop(){
		_audioSuorce.Stop ();
	}
}
