using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego6 : MonoBehaviour {
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	private timedown _timeDown;


	public int time;
	public Text timer;
	public  int totalCrack= 3;
	public enum stateGame{Begin,InGame,Gano,Perdio};
	public stateGame  MyStateGame= stateGame.InGame;

	public GameObject MenuWinLose;
	public int[] pointID;
	public GameObject[] cracks;

	private int TotalRepeat=2;
	public int nivel = 0;
	private int indexCracks=0;
	private int countCrack=0;
	public AudioSource[] rocasQuebrandose;
	// Use this for initialization
	void Start () {
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		time= (int) _timeDown.waitTime;
		MyStateGame = stateGame.Begin;
		pointID = NumerosRandom.randomArray (12);
		nivel = PlayerPrefs.GetInt ("Nivel");
		switch (nivel) {
		case 1:
			//TotalRepeat=2;
			totalCrack= 4;
			break;
		case 2:
			//TotalRepeat=3;
			totalCrack= 6;
			break;
		case 3:
			//TotalRepeat=4;
			totalCrack= 8;
			break;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (_timeDown.isTimeOver && MyStateGame!= stateGame.Gano) {
			MyStateGame = stateGame.Perdio;
		}
		if (countCrack==2){
			if(totalCrack!=0){
				InitializeCracks();
			}
			else if(MyStateGame==stateGame.InGame && totalCrack<=0){
				MyStateGame= stateGame.Gano;
				_timeDown.ActivateClock = false;
				
				///timer.text= "You Win!!!";
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
			}
		}

		if(MyStateGame.Equals (stateGame.Perdio)){
			//timer.text = "You Lost!!!";
			_timeDown.ActivateClock = false;
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	
	}

	private void InitializeCracks(){
		cracks [pointID [indexCracks]].SetActive (true);
		rocasQuebrandose [0].Play ();
		cracks [pointID [indexCracks+1]].SetActive (true);
		rocasQuebrandose [1].Play ();
		indexCracks += 2;
		countCrack = 0;
	}

	public void sellando(){
		totalCrack=totalCrack-1;
		countCrack++;
	}

	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		MyStateGame = stateGame.InGame;
		_timeDown.ActivateClock = true;
		InitializeCracks();
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
	}
}
