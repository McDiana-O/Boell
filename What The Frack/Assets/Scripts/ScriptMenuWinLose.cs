using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScriptMenuWinLose : MonoBehaviour {
	public Text textoWinLose;
	public Image imgRetro;
	public GameObject btn_salir;
	public GameObject btn_repetir;
	public GameObject btn_siguiente;
	public GameObject btn_Continuar;
	public GameObject _BGNaranja;
	public enum tipoMensaje{Gano,Perdio,PerdioFrackit,Pause};
	public int idMiniGame;
	public Sprite[] SpriteRetroWin;
	public Sprite[] SpriteRetroLose;

	private GamePlayerPrefs _playerPrefs;
	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		idMiniGame = _playerPrefs.MiniGameActual - 1;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void Nextlevel(){
		_playerPrefs.MiniGameActual=_playerPrefs.MiniGameActual+1;
		Application.LoadLevel(Application.loadedLevel+1);
	}

	public void RepetirLevel(){
		if (idMiniGame < 9) {
			Time.timeScale=1;
			Application.LoadLevel ("Juego0"+(idMiniGame+1));
		}
		else {
			Time.timeScale=1;
			Application.LoadLevel ("Juego"+(idMiniGame+1));
		}
	}

	public void GoToMenu(){
		Time.timeScale=1;
		Application.LoadLevel("MenuPrincipal");

	}

	void PauseHide(bool activate){
		btn_Continuar.SetActive (activate);
		_BGNaranja.SetActive (activate);
		btn_siguiente.SetActive(false);
	}
	public void SetMenssageWinorLose(tipoMensaje typeMenssage){
		if(typeMenssage == tipoMensaje.Gano){
			textoWinLose.text="FRACK IT!";
			PauseHide(false);
			btn_siguiente.SetActive(true);
			imgRetro.GetComponent<Image>().sprite=SpriteRetroWin[idMiniGame];
		}

		else if(typeMenssage == tipoMensaje.Perdio){
			textoWinLose.text="NO FRACK";
			btn_siguiente.SetActive(false);
			PauseHide(false);
			imgRetro.GetComponent<Image>().sprite=SpriteRetroLose[idMiniGame];
		}

		else if(typeMenssage == tipoMensaje.PerdioFrackit){
			textoWinLose.text="FRACK IT!";
			btn_siguiente.SetActive(false);
			PauseHide(false);
			imgRetro.GetComponent<Image>().sprite=SpriteRetroLose[idMiniGame];
		}
		else if(typeMenssage == tipoMensaje.Pause){
			textoWinLose.text="PAUSA";
			PauseHide(true);
		}

	}
}
