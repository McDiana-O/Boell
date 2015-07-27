using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego3 : MonoBehaviour {
	public int time;
	//public Text timer;
	public GameObject[] piletones;
	public bool win;

	public GameObject MenuWinLose;
	// Use this for initialization
	void Start () {
		StartCoroutine (countdown());
		win=false;
	}
	
	// Update is called once per frame
	void Update () {
		if(piletones[0].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop
		   && piletones[1].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop &&
		   piletones[2].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop){
			win=true;
			//timer.text = "you win!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
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
		if (time <= 0) {
			//MyStateGame = stateGame.Perdio;
			//timer.text = "you lost!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}
}
