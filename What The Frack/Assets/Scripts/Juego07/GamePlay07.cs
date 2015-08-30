using UnityEngine;
using System.Collections;

public class GamePlay07 : MonoBehaviour {
	public GameObject PerforacionVertical;
	public GameObject PerforacionDiagonal;
	public GameObject[] PuntosObjetivos;
	public GameObject MenuWinLose;


	public enum stateGame07{Begin,AnimVertical,AnimDiagonal,Win,Lose,End};

	public bool _isTouchScreen=false;
	public bool Gane=false;
	public int temp;
	public int nivel;

	private StopPerforacion _stopPerforacion;
	public stateGame07 myState;
	private float _tempy;

	private float[] vertical = {0.0f,25.0f,15.0f,8.0f};

	// Use this for initialization
	void Start () {
		temp = Random.Range (0, 3);
		showPuntoObjetivo (temp);
		myState = stateGame07.Begin;
		myState = stateGame07.AnimVertical;
		_stopPerforacion = PerforacionDiagonal.GetComponent<StopPerforacion> ();
	}
	
	// Update is called once per frame
	void Update () {
		if(myState != stateGame07.Lose && myState != stateGame07.Win)
		{
			if (_stopPerforacion.isTouchPoint) {
				myState = stateGame07.Win;
			}
			else if (myState == stateGame07.AnimVertical) {
				animacionVertical ();
				touchDetecting();
			} 
			else if(myState == stateGame07.AnimDiagonal) {
				animacionDiagonal ();
			}
		}
		if (myState == stateGame07.Win) {
			//myState = stateGame07.Win;
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		}
		if (myState == stateGame07.Lose) {
			//myState = stateGame07.Win;
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}

	void showPuntoObjetivo(int i){
		PuntosObjetivos[i].SetActive(true);
	}

	void touchDetecting(){
		foreach (var T in Input.touches) {
			if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
			{
				//_isTouchScreen=true;
				myState = stateGame07.AnimDiagonal;
			}
		}
	}
	
	void animacionVertical(){
		if (PerforacionVertical.transform.position.y > 0.5f) {
			PerforacionVertical.transform.Translate (Vector3.down /vertical[nivel]);
		}
		else {
			myState = stateGame07.Lose;
		}
	}

	void animacionDiagonal(){
		if(PerforacionDiagonal.transform.localScale.y<1.40){
			_tempy= PerforacionDiagonal.transform.localScale.y +0.005f;
			PerforacionDiagonal.transform.localScale = new Vector3 (1, _tempy, 1);
		}
		else {
			myState = stateGame07.Lose;
		}
	}
}
