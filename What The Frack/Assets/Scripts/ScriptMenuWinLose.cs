using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptMenuWinLose : MonoBehaviour {
	public Text textoWinLose;
	public Image imgRetro;
	public GameObject btn_salir;
	public GameObject btn_repetir;
	public GameObject btn_siguiente;
	public enum tipoMensaje{Gano,Perdio};
	public int idMiniGame;
	public Sprite[] SpriteRetroWin;
	public Sprite[] SpriteRetroLose;

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
		if (idMiniGame < 11) {
			Application.LoadLevel ("Juego0"+(idMiniGame+1));
		}
		else {
			Application.LoadLevel ("Juego"+(idMiniGame+1));
		}
	}

	public void GoToMenu(){
		Application.LoadLevel("MenuPrincipal");
	}

	public void SetMenssageWinorLose(tipoMensaje typeMenssage){
		if(typeMenssage == tipoMensaje.Gano){
			textoWinLose.text="FRACK IT!";
			btn_siguiente.SetActive(true);
			imgRetro.GetComponent<Image>().sprite=SpriteRetroWin[idMiniGame];
			
		}

		else if(typeMenssage == tipoMensaje.Perdio){
			textoWinLose.text="NO FRACK";
			btn_siguiente.SetActive(false);
			imgRetro.GetComponent<Image>().sprite=SpriteRetroLose[idMiniGame];
		}

	}
}
