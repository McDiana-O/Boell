﻿using UnityEngine;
using System.Collections;

public class mueveLineaPunteada : MonoBehaviour {
	private GamePlay08 _gamePlay;
	public float xPos=500.0f;
	// Use this for initialization
	void Start () {
		_gamePlay = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<GamePlay08> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!_gamePlay.isPausing) {
			if (!_gamePlay.isPausing && _gamePlay.mystate == GamePlay08.stateGameMini08.Jugando) {
				this.gameObject.transform.Translate (Vector3.left / _gamePlay.divisorVelLinea);
			}
			else{
				this.gameObject.transform.position = new Vector3(xPos,0.0f, 0.0f);
			}
		}
	}
}