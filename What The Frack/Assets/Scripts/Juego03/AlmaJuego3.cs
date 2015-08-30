using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego3 : MonoBehaviour {

	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	private timedown _timeDown;

	public int time;
	//public Text timer;
	public GameObject[] piletones;
	public bool win;
	private bool BeginGame=false;
	public GameObject MenuWinLose;
	// Use this for initialization
	void Start () {
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		win=false;
	}
	
	// Update is called once per frame
	void Update () {
		if (BeginGame) {
			if(piletones[0].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop
			   && piletones[1].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop &&
			   piletones[2].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop){
				win=true;
				//timer.text = "you win!!!";
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
			}
			else if (time <= 0) {
				//MyStateGame = stateGame.Perdio;
				//timer.text = "you lost!!!";
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
			}
		}

	}


	IEnumerator countdown()
	{
		while (time > 0 && !win)
		{
			//timer.text = time.ToString();
			time -= 1;
			yield return new WaitForSeconds(1);
		}

	}

	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		_timeDown.ActivateClock = true;
		StartCoroutine (countdown());
		BeginGame = true;

	}
}
