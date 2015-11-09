using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpQuiz : MonoBehaviour {
	
	public int[] correctAnswer;

	public Image popUpQuiz;
	public Image ImgGris;
	public Image FondoNaranja;
	public Image AnimRed;
	public Button btnTrue;
	public Button btnFalse;
	public Text Mensaje;
	public Text Quiz;
	//Para  saber cuando inicio el mensaje;
	float timeStartLife;
	//Tiempo de Vida del mensaje
	private float timeEndLife =2.0f;
	bool IsActivateMensaje;
 	bool IsActivateQuizBad;
	public GameObject tarjetaCanvas;
	public menuTarjetas _MenuTarjetaCanvas;
	private GamePlayerPrefs _playerPrefs;
	/// <summary>
	/// Arreglo de las preguntas  verdadero y falso.
	/// </summary>
	public string[] TextQuiz;
	private int  idCartaActiva = 0;
	public SFX_Sounds SoundBotones;

	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		SetActivatePopMensaje (false);
		timeStartLife = 0;
		IsActivateMensaje=false;
		IsActivateQuizBad = false;

	}

	// Update is called once per frame
	void Update () {
		if (IsActivateMensaje) {
			if(Time.time-timeStartLife>timeEndLife){
				SetActivatePopMensaje(false);
				timeStartLife = 0;
				IsActivateMensaje = false;
			}
		}

		if (IsActivateQuizBad) {
			if(Time.time-timeStartLife>timeEndLife){
				SetActivatePopMensaje(false);
				timeStartLife = 0;
				IsActivateQuizBad = false;
		
				tarjetaCanvas.SetActive (true);
				_playerPrefs.OpenedCards [idCartaActiva - 1] = 1;
				tarjetaCanvas.GetComponent<TarjetaInformativa> ().InicializaTarjeta (idCartaActiva);
				_MenuTarjetaCanvas.ActivateButton (idCartaActiva-1);
			}
		}
	}
	
	public void compareAnswer(int btnAnswer){

		if(btnAnswer==correctAnswer[idCartaActiva-17]){
			//Debug.Log("Correcto");
			SoundBotones.SFXPlayShot(1);
			SetActivatePopMensaje(false);
			tarjetaCanvas.SetActive (true);
			tarjetaCanvas.GetComponent<TarjetaInformativa> ().InicializaTarjeta (idCartaActiva);
			_MenuTarjetaCanvas.ActivateButton (idCartaActiva-1);
		}
		else{
			//Debug.Log("Loser");
			AnimRed.gameObject.SetActive(true);
			SoundBotones.SFXPlayShot(0);
			timeStartLife = Time.time;
			IsActivateQuizBad = true;
		}
		_playerPrefs.setOpenCard(idCartaActiva - 1,1);

	}
	
	public void ShowMensaje(string value){
		timeStartLife = Time.time;
		popUpQuiz.gameObject.SetActive(true);
		Mensaje.gameObject.SetActive(true);
		IsActivateMensaje = true;
		Mensaje.text =System.Text.RegularExpressions.Regex.Unescape(value);
	}
	 
	public void ShowQuiz(int idCard){
		popUpQuiz.gameObject.SetActive(true);
		ImgGris.gameObject.SetActive(true);
		btnTrue.gameObject.SetActive(true);
		btnFalse.gameObject.SetActive(true);
		Quiz.gameObject.SetActive(true);
		FondoNaranja.gameObject.SetActive(true);
		Quiz.text =System.Text.RegularExpressions.Regex.Unescape(TextQuiz[idCard-17]+" "+idCard);
		idCartaActiva = idCard;
	}


	void SetActivatePopMensaje(bool value){ 
		popUpQuiz.gameObject.SetActive(value);

		ImgGris.gameObject.SetActive(value);
		btnTrue.gameObject.SetActive(value);
		btnFalse.gameObject.SetActive(value);
		Mensaje.gameObject.SetActive(value);
		Quiz.gameObject.SetActive(value);
		FondoNaranja.gameObject.SetActive(value);
		AnimRed.gameObject.SetActive(value);
	}

}
