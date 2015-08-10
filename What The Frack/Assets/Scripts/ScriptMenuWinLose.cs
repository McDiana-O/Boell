using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptMenuWinLose : MonoBehaviour {
	public Text textoWinLose;
	public GameObject btn_salir;
	public GameObject btn_repetir;
	public GameObject btn_siguiente;
	public enum tipoMensaje{Gano,Perdio};
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Nextlevel(){
		Application.LoadLevel(Application.loadedLevel+1);
	}

	public void RepetirLevel(){
		Application.LoadLevel(Application.loadedLevel);
	}

	public void GoToMenu(){
		Application.LoadLevel("MenuPrincipal");
	}

	public void SetMenssageWinorLose(tipoMensaje typeMenssage){
		if(typeMenssage == tipoMensaje.Gano){
			textoWinLose.text="GANASTE!!";
			btn_siguiente.SetActive(true);
			
		}

		else if(typeMenssage == tipoMensaje.Perdio){
			textoWinLose.text="PERDISTE!!";
			btn_siguiente.SetActive(false);
		}

	}
}
