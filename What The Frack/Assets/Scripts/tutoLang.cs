using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class tutoLang : MonoBehaviour {
	public Text texto;
	private GamePlayerPrefs _playerPrefs;
	public int idMiniGame;

	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		idMiniGame = _playerPrefs.MiniGameActual;
		texto.text= _playerPrefs.LTutoriales.getString("tutorial_minigame_"+formatNumberString(idMiniGame,2));
	}
	
	// Update is called once per frame
	void Update () {

	}
	string formatNumberString(int idMiniGame, int length){
		string str = idMiniGame.ToString();
		if (str.Length == length)
			return str;
		for (int i=0; i<length-str.Length; i++)
			str = "0" + str;
		return str;
	}
}
