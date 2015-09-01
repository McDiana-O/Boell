using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay02 : MonoBehaviour {

	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;

	public int[] pointID;
	public GameObject[] roads;
	public GameObject[] points;
	public int[] machines;
	public int totalMachines=0;
	public GameObject MenuWinLose;

	enum stateGame02{Begin,CreateRoads,TouchPoints,Win,Lose};
	stateGame02 myState;

	int total;
	private timedown _timeDown;
	//esta variable va ser  global
	public int nivel=1,numroads=2,numpoint=2;

	public int[] roadFull= new int[4];
	public bool[] IsRoadFull = new bool[4];

	public bool isTouchPoint= false;
	// Use this for initialization
	void Start () {
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		myState = stateGame02.Begin;
		switch (nivel) {
		
		case 1:
			numroads=2;
			numpoint=2;
			break;
		case 2:
			numroads=3;
			numpoint=3;
			break;
		case 3:
			numroads=4;
			numpoint=5;
			break;
		}



		pointID = NumerosRandom.randomArray (4);
		for (int i=0;i<numroads;i++)
		{
			roads[pointID[i]].SetActive(true);
		}

		//


	}
	
	// Update is called once per frame
	void Update () {
		if (myState != stateGame02.Lose && myState == stateGame02.CreateRoads && !_timeDown.isTimeOver) {
			for (int i=0,k=0; i<4; i++) {
				if (IsRoadFull [i]) {
					k++;
				}
				total = k;
			}
			if (total == numroads && myState == stateGame02.CreateRoads) {
				pointID = NumerosRandom.randomArray (9);
				for (int i=0; i<numpoint; i++) {
					points [pointID [i]].SetActive (true);
					points [pointID [i]] .GetComponent<AlphaAnimacion> ().activateAnimacion = true;
				}
				myState = stateGame02.TouchPoints;
				isTouchPoint = true;
				machines = NumerosRandom.randomArray (6);
			}

			//continuos
		} 
		else if (myState == stateGame02.TouchPoints && !_timeDown.isTimeOver) 
		{
		
			if (totalMachines == numpoint) {
				myState = stateGame02.Win;
				MenuWinLose.SetActive (true);
				MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (ScriptMenuWinLose.tipoMensaje.Gano);
			}
		} 
		else if (_timeDown.isTimeOver) 
		{
			myState = stateGame02.Lose;
		}
		if (myState == stateGame02.Lose) {
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}

	}

	public void checkFullRoad(int idFather)
	{
		if (idFather == 0 || idFather == 1) {
			if (roadFull [idFather] == 8) {
				IsRoadFull [idFather] = true;
			}
			else if(roadFull[idFather]<8)
			{
				myState = stateGame02.Lose;
			}
		} 

		if (idFather == 2 || idFather == 3){
			if (roadFull [idFather] == 9) {
				IsRoadFull [idFather] = true;
			}
			else if(roadFull[idFather]<9)
			{
				myState = stateGame02.Lose;
			}
		}

	}


	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		myState = stateGame02.CreateRoads;
		_timeDown.ActivateClock = true;
	}

	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);

	}
}
