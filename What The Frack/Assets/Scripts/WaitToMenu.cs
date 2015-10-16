using UnityEngine;
using System.Collections;

public class WaitToMenu : MonoBehaviour {
	private GamePlayerPrefs _playerPrefs;
	void Awake(){
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_playerPrefs.SoundMuteApply ();
	}

	public void nextoTarjeta(){
		Application.LoadLevel ("tarjetainformativa");
	}

	///funciones para Creditos

	public void GoToScene(string value){
		Application.LoadLevel (value);
	}

	public void OpenSitiosOPorUrl(string value)
	{
		Application.OpenURL (value);
	}
}
