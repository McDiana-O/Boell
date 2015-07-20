using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GamePlayEight : MonoBehaviour {
	public int time;
	public Text timer;
	public Text texto;
	public Button button;
	public Image agua;
	private RectTransform recTransformAgua;
	private float tempPulsos;
	public enum stateGameMini8{Inicio,Pulsando,Gano,Perdio};
	stateGameMini8 mysate;
	// Use this for initialization
	void Start () {
		mysate = stateGameMini8.Inicio;
		StartCoroutine (countdown());
		recTransformAgua =  agua.GetComponent<RectTransform> ();
		tempPulsos = (recTransformAgua.localScale.y *100)/2;
		texto.text = tempPulsos.ToString();
	}
	public void CuentaPulsadas(){

		if(recTransformAgua.localScale.y > 0 && (mysate != stateGameMini8.Perdio || mysate != stateGameMini8.Gano))
		{
			mysate = stateGameMini8.Pulsando;
			recTransformAgua.localScale = new Vector3(1,recTransformAgua.localScale.y-0.05f,1);
			tempPulsos = (recTransformAgua.localScale.y *100)/2;
			texto.text = tempPulsos.ToString();
		}
		else if (recTransformAgua.localScale.y <= 0) {
			mysate = stateGameMini8.Gano;
			button.interactable= false; 
		}
	}
	void FixedUpdate(){
		if (recTransformAgua.localScale.y <= 0 && mysate == stateGameMini8.Gano) {
			texto.text = "Ganaste";
		}
		else if (mysate == stateGameMini8.Perdio) {
			texto.text = "Perdiste";
		}
	}
	IEnumerator countdown()
	{
		while (time >0 && mysate !=stateGameMini8.Gano)
		{
			time -= 1;
			timer.text = time.ToString();
			yield return new WaitForSeconds(1);
		}
		if (time <= 0) {
			mysate = stateGameMini8.Perdio;
			button.interactable= false;
		}
	}
}
