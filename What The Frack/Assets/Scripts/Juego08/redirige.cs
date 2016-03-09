using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class redirige : MonoBehaviour {
	public Text textCargando;
	private GamePlayerPrefs _playerPrefs;
	// Use this for initialization
	void Start () {
		textCargando.text = _playerPrefs.Lgui.getString("loadingscreen_text");
		Time.timeScale=1;
		Application.LoadLevel ("Juego08");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
