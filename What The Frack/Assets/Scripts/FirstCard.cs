using UnityEngine;
using System.Collections;

public class FirstCard : MonoBehaviour {
	private GamePlayerPrefs _playerPrefs;
	// Use this for initialization
	void Start () {
		//_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
	}
	
	public void gotoLevel (string Level) {
		Application.LoadLevel (Level);
	
	}
}
