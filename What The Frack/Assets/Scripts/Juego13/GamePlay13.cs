using UnityEngine;
using System.Collections;

public class GamePlay13 : MonoBehaviour {
	// variables de  ley para poder usar   eso XD
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	private timedown _timeDown;
	//esperando un segundo para  mandar  el mensaje de  WINLOSE
	private float time=1;


	// Variables para  el juego
	private ChangeSprite _changeQuake;
	/// <summary>
	/// The type state of the myGame13.
	/// </summary>
	public enum stateGame13{Begin,Earthquake,Pause,Win,Lose};
	/// <summary>
	/// The state of this game.
	/// </summary>
	public stateGame13 myState;
	/// <summary>
	/// The previous identifier button.0 is  nothing, 1 is Right and 2 is Left
	/// </summary>
	private int prevIDButton;


	public int totaltaps;
	// Use this for initialization
	void Start () {
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		myState = stateGame13.Begin;

		_changeQuake = GameObject.Find ("mj13_01").GetComponent<ChangeSprite>();
		prevIDButton = 0;
		totaltaps = 0;
	}
	
	// Update is called once per frame
	void Update () {

		if(myState==stateGame13.Earthquake && myState!=stateGame13.Pause){
			if(totaltaps==5){
				_changeQuake.ChangeImg(1);
			}
			else if(totaltaps==10){
				_changeQuake.ChangeImg(2);
			}
			else if(totaltaps==20){
				_changeQuake.ChangeImg(3);
			}

		}
	}


	public void CountButton(int IDButtonPress){
		if (myState == stateGame13.Earthquake) {
			if (prevIDButton != 0) {
				if(prevIDButton!=IDButtonPress){
					totaltaps++;
				}
			} 
			else {
				prevIDButton=IDButtonPress;
			}
		}
	}

	IEnumerator countdown()
	{
		while (time >0 && (myState != stateGame13.Lose || myState != stateGame13.Win))
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
		}
	}

	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		myState = stateGame13.Earthquake;
		_timeDown.ActivateClock = true;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		
	}


}
