using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GamePlayEight : MonoBehaviour {
	public int time;
	public Text timer;
	public Text texto;
	public Button button;
	public Image agua;

	private float tempPulsos;
	public enum stateGameMini8{Inicio,Pulsando,Gano,Perdio};
	stateGameMini8 mysate;

	public GameObject MenuWinLose;

	// Use this for initialization
	void Start () {
		mysate = stateGameMini8.Inicio;
		StartCoroutine (countdown());
		//tempPulsos = (recTransformAgua.localScale.y *100)/2;
		//texto.text = tempPulsos.ToString();
	}

	void FixedUpdate(){
		if (agua.fillAmount == 0 && mysate != stateGameMini8.Perdio) {
			mysate = stateGameMini8.Gano;
			button.interactable = false; 
			//texto.text = "Ganaste";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		} else if (time <= 0 && mysate != stateGameMini8.Gano) {
			mysate = stateGameMini8.Perdio;
			//texto.text = "Perdiste";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}

	public void CuentaPulsadas(){

		if (agua.fillAmount > 0 && (mysate != stateGameMini8.Perdio || mysate != stateGameMini8.Gano)) {
			mysate = stateGameMini8.Pulsando;
			//recTransformAgua.localScale = new Vector3(1,recTransformAgua.localScale.y-0.05f,1);
			//tempPulsos = (recTransformAgua.localScale.y *100)/2;
			agua.fillAmount -= 0.1f;
			texto.text = tempPulsos.ToString ();
		} 
	}


	IEnumerator countdown()
	{
		while (time >=0 && mysate!= stateGameMini8.Gano)
		{
			time -= 1;
			timer.text = time.ToString();
			yield return new WaitForSeconds(1);
		}
	}
}
