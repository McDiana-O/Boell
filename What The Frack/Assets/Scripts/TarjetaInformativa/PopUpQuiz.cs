﻿using UnityEngine;
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
	//Idiomas Botones
	//Bonton Falso
	//public Button btnFalso;
	private Image imgFalso;
	private SpriteState spriteStateFalso;
	public Sprite[] spritesFalso;
	//Boton Verdadero
	//public Button btnVerdad;
	private Image imgVerdad;
	private SpriteState spriteStateVerdad;
	public Sprite[] spritesVerdad;
	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		SetActivatePopMensaje (false);
		timeStartLife = 0;
		IsActivateMensaje=false;
		IsActivateQuizBad = false;


		imgFalso = btnFalse.GetComponent<Image>();
		imgVerdad = btnTrue.GetComponent<Image>();

		ChangeBotonesIdiomas(PlayerPrefs.GetString("Language"));

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
			_MenuTarjetaCanvas.CountCardsActivadas();
			SoundBotones.SFXPlayShot(1);
			SetActivatePopMensaje(false);
			tarjetaCanvas.SetActive (true);
			tarjetaCanvas.GetComponent<TarjetaInformativa> ().InicializaTarjeta (idCartaActiva);
			_MenuTarjetaCanvas.ActivateButton (idCartaActiva-1);
			_MenuTarjetaCanvas.CountCardsActivadas(1);

		}
		else{
			//Debug.Log("Loser");
			_MenuTarjetaCanvas.CountCardsActivadas(1);
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
		Mensaje.text =System.Text.RegularExpressions.Regex.Unescape(_playerPrefs.Lgui.getString(value));

    }
	 
	public void ShowQuiz(int idCard){
		popUpQuiz.gameObject.SetActive(true);
		ImgGris.gameObject.SetActive(true);
		btnTrue.gameObject.SetActive(true);
		btnFalse.gameObject.SetActive(true);
		Quiz.gameObject.SetActive(true);
		FondoNaranja.gameObject.SetActive(true);
        //Quiz.text =System.Text.RegularExpressions.Regex.Unescape(TextQuiz[idCard-17]);
        Quiz.text = System.Text.RegularExpressions.Regex.Unescape(_playerPrefs.LTarjetas.getString("card_" + idCard+ "_question"));
        //Debug.Log("Numero de tarjeta: " + idCard);
        idCartaActiva = idCard;
	}


	void SetActivatePopMensaje(bool value){ 
		popUpQuiz.gameObject.SetActive(value);

		ImgGris.gameObject.SetActive(value);
		btnTrue.gameObject.SetActive(value);
		btnFalse.gameObject.SetActive(value);
		Mensaje.gameObject.SetActive(value);
		Quiz.gameObject.SetActive(value);
		if(FondoNaranja)
			FondoNaranja.gameObject.SetActive(value);
		if (AnimRed)
			AnimRed.gameObject.SetActive(value);
	}
	//Idiomas
	public void ChangeBotonesIdiomas(string Value)
	{
		
		if (Value == "English")
		{
			imgFalso.sprite = spritesFalso[0];
			imgFalso.SetNativeSize();
			spriteStateFalso.highlightedSprite = spritesFalso[0];
			spriteStateFalso.pressedSprite = spritesFalso[1];
			spriteStateFalso.disabledSprite = spritesFalso[1];

			imgVerdad.sprite = spritesVerdad[0];
			imgVerdad.SetNativeSize();
			spriteStateVerdad.highlightedSprite = spritesVerdad[0];
			spriteStateVerdad.pressedSprite = spritesVerdad[1];
			spriteStateVerdad.disabledSprite = spritesVerdad[1];
		}
		else if (Value == "Spanish")
		{
			imgFalso.sprite = spritesFalso[2];
			imgFalso.SetNativeSize();
			spriteStateFalso.highlightedSprite = spritesFalso[2];
			spriteStateFalso.pressedSprite = spritesFalso[3];
			spriteStateFalso.disabledSprite = spritesFalso[3];

			imgVerdad.sprite = spritesVerdad[2];
			imgVerdad.SetNativeSize();
			spriteStateVerdad.highlightedSprite = spritesVerdad[2];
			spriteStateVerdad.pressedSprite = spritesVerdad[3];
			spriteStateVerdad.disabledSprite = spritesVerdad[3];

		}
		else if (Value == "German")
		{	
			imgFalso.sprite = spritesFalso[4];
			imgFalso.SetNativeSize();
			spriteStateFalso.highlightedSprite = spritesFalso[4];
			spriteStateFalso.pressedSprite = spritesFalso[5];
			spriteStateFalso.disabledSprite = spritesFalso[5];
				                                                  
			imgVerdad.sprite = spritesVerdad[4];
			imgVerdad.SetNativeSize();
          	spriteStateVerdad.highlightedSprite = spritesVerdad[4];
          	spriteStateVerdad.pressedSprite = spritesVerdad[5];
          	spriteStateVerdad.disabledSprite = spritesVerdad[5];
		}
		btnFalse.spriteState = spriteStateFalso;
		btnTrue.spriteState= spriteStateVerdad;
	}
}
