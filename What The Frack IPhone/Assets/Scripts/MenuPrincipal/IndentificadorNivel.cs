using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class IndentificadorNivel : MonoBehaviour {
	public GameObject[] IdentiNivel;
	public int idMinigame;
	private int idNivel;
	GamePlayerPrefs _gameplayer;
	// Use this for initialization
	void Start () {
		_gameplayer = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		idNivel = _gameplayer.Minigame [idMinigame];
		changeIdentiNivel ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	void changeIdentiNivel(){
		if (idNivel == 2) {
			IdentiNivel[0].SetActive(true);
			IdentiNivel[1].SetActive(false);
			IdentiNivel[2].SetActive(false);
		} 
		else if (idNivel == 3) {
			IdentiNivel[0].SetActive(false);
			IdentiNivel[1].SetActive(true);
			IdentiNivel[2].SetActive(false);
		} 
		else if (idNivel == 4) {
			IdentiNivel[0].SetActive(false);
			IdentiNivel[1].SetActive(false);
			IdentiNivel[2].SetActive(true);
		} 
		else {
			IdentiNivel[0].SetActive(false);
			IdentiNivel[1].SetActive(false);
			IdentiNivel[2].SetActive(false);
		}
	}
}
