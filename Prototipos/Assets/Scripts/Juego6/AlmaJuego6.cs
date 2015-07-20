﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego6 : MonoBehaviour {
	public int time;
	public Text timer;
	public  int totalCrack= 3;
	public enum stateGame{InGame,Gano,Perdio};
	public stateGame  MyStateGame= stateGame.InGame;

	public GameObject MenuWinLose;
	// Use this for initialization
	void Start () {
		MyStateGame = stateGame.InGame;
		StartCoroutine (countdown());
	}
	
	// Update is called once per frame
	void Update () {
		if(MyStateGame==stateGame.InGame && totalCrack<=0){
			MyStateGame= stateGame.Gano;
			timer.text= "You Win!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		}
		else if(MyStateGame.Equals (stateGame.Perdio)){
			timer.text = "You Lost!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	
	}

	public void sellando(){
		totalCrack=totalCrack-1;
	}

	IEnumerator countdown()
	{
		while (time > 0 && MyStateGame!=stateGame.Gano)
		{
			timer.text = time.ToString();
			time -= 1;
			yield return new WaitForSeconds(1);
		}
		if (time <= 0) {
			MyStateGame = stateGame.Perdio;
		}
	}
}
