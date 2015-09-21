using UnityEngine;
using System.Collections;

public class GamePlay014 : MonoBehaviour {
	//Objetos para tutorial y Tarjeta informativa
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public GameObject MenuWinLose;
	//Estados del juego 
	enum StateGame{Begin,Introduccion,InGame,Win,Lose,Pause};
	private StateGame myState; 

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		myState = StateGame.Introduccion;
		//_timeDown.ActivateClock = true;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		
	}
}
