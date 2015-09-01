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
	public GameObject[] points;
	public bool win;
	private bool BeginGame=false;
	public GameObject MenuWinLose;
	private int[] numPiletones;
	private int Piletonestotales;
	public int nivel;
	public int[] pointID;
	// Use this for initialization
	void Start () {
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		win=false;
		if(nivel==1){
			Piletonestotales=2;
		}
		else if(nivel==2){
			Piletonestotales=3;
		}
		else if(nivel==3){
			Piletonestotales=4;
		}
		pointID = NumerosRandom.randomArray (6);
		for (int i=0;i<Piletonestotales;i++)
		{
			piletones[pointID[i]].SetActive(true);
			points[pointID[i]].SetActive(true);
			points[pointID[i]] .GetComponent<AlphaAnimacion>().activateAnimacion=true;
		}
		// numPiletones = new int[2, 3, 4];
	}
	
	// Update is called once per frame
	void Update () {
		if (BeginGame) {
			/*if(piletones[0].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop
			   && piletones[1].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop &&
			   piletones[2].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop)*/
			if(Piletonestotales==0)
			{
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

		_timeDown.ActivateClock = true;
		StartCoroutine (countdown());
		BeginGame = true;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
	}

	public void lessPiletones(){
		Piletonestotales -= 1;
	}

}
