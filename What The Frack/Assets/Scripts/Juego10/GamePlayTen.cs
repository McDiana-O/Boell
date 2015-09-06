using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GamePlayTen : MonoBehaviour {
	public int time;
	public Text timer;
	public Text texto;
	public Button button;
	public Image agua;

	private float tempPulsos;
	public enum stateGameMini10{Inicio,Pulsando,Gano,Perdio};
	stateGameMini10 mysate;

	public GameObject MenuWinLose;

	// Use this for initialization
	void Start () {
		mysate = stateGameMini10.Inicio;
		StartCoroutine (countdown());
		//tempPulsos = (recTransformAgua.localScale.y *100)/2;
		//texto.text = tempPulsos.ToString();
	}

	void FixedUpdate(){
		if (agua.fillAmount == 0 && mysate != stateGameMini10.Perdio) {
			mysate = stateGameMini10.Gano;
			button.interactable = false; 
			//texto.text = "Ganaste";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		} else if (time <= 0 && mysate != stateGameMini10.Gano) {
			mysate = stateGameMini10.Perdio;
			//texto.text = "Perdiste";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}

	public void CuentaPulsadas(){

		if (agua.fillAmount > 0 && (mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano)) {
			mysate = stateGameMini10.Pulsando;
			//recTransformAgua.localScale = new Vector3(1,recTransformAgua.localScale.y-0.05f,1);
			//tempPulsos = (recTransformAgua.localScale.y *100)/2;
			agua.fillAmount -= 0.05f;
			texto.text = tempPulsos.ToString ();
		} 
	}


	IEnumerator countdown()
	{
		while (time >=0 && mysate!= stateGameMini10.Gano)
		{
			time -= 1;
			timer.text = time.ToString();
			yield return new WaitForSeconds(1);
		}
	}
}
