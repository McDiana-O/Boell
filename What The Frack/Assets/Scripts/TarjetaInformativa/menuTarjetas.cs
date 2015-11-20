using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuTarjetas : MonoBehaviour {

	public GameObject tarjetaCanvas;
	public GameObject tarjetaMensajeQuiz;
	public Sprite[] ButonsSpritesTarjetas;
	private GamePlayerPrefs _playerPrefs;
	public GameObject[] Cards;
	public GameObject[] TextCardsBuy;
	public SFX_Sounds SoundBotones;
	public Text Txtpuntos;
	public Text TxtContCards;
	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		checkCardsActivadas ();
		CountCardsActivadas ();
		Txtpuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
	}
	
	// Update is called once per frame
	void Update () {

	}

	public void checkCardsActivadas(){

		changeButtonActivate (Cards[0].GetComponent<Button>(),true); 
		for (int index=1; index<25; index++) {

			if(_playerPrefs.OpenedCards[index]>=1)
			{
				changeButtonActivate (Cards[index].GetComponent<Button>(),true);
				if(index>=16){
					TextCardsBuy[index-16].SetActive(false);
				}
				//Cards[index+1].GetComponent<Button>().interactable=true;
			}

		}	

	}

	public void CountCardsActivadas(){
		int count=0;
		string tempString = "";
		for (int index=0; index<_playerPrefs.OpenedCards.Length; index++) {
			
			if(_playerPrefs.OpenedCards[index]>=1)
			{
				count++;
			}
		}	
		//Debug.Log (count);
		tempString = count.ToString(); 
		if (count < 10) {
			tempString = "0"+tempString;
		}
		TxtContCards.text = tempString + "/25";
	}

	public void changeButtonActivate(Button ButtonTarjeta,bool valueCompare){
		SpriteState SpriteStateButton = new SpriteState ();
		//SpriteStateButton.pressedSprite= ButonsSpritesTarjetas[2];
		if (valueCompare) {
			SpriteStateButton.highlightedSprite= ButonsSpritesTarjetas[1];
			SpriteStateButton.pressedSprite= ButonsSpritesTarjetas[2];
			ButtonTarjeta.image.sprite = ButonsSpritesTarjetas[1];
			//ButtonTarjeta.spriteState.pressedSprite =SpriteStateButton.pressedSprite;
		} 
		else {
			SpriteStateButton.highlightedSprite= ButonsSpritesTarjetas[0];
			SpriteStateButton.pressedSprite= ButonsSpritesTarjetas[0];
			ButtonTarjeta.image.sprite = ButonsSpritesTarjetas[0];
			//ButtonTarjeta.spriteState.pressedSprite = ButonsSpritesTarjetas[0];
		}
		ButtonTarjeta.spriteState = SpriteStateButton;
	}

	public void ActivateButton(int idcardInfo){
		CountCardsActivadas ();
		changeButtonActivate (Cards[idcardInfo].GetComponent<Button>(),true); 
		TextCardsBuy[idcardInfo-16].SetActive(false);
	}

	public void activaTarjeta(int numeroTarjeta){
		if (_playerPrefs.OpenedCards [numeroTarjeta-1] == 0) {
			SoundBotones.SFXPlayShot(2);
			tarjetaMensajeQuiz.SendMessage ("ShowMensaje","Incrementa tu puntaje para \n desbloquear esta tarjeta.");
			//tarjetaMensajeQuiz.GetComponent<PopUpQuiz>().ShowMensaje("Incrementa tu puntaje para <br> desbloquear esta tarjeta.");
			//Debug.Log("Entro a este If de Menu de tarjetas");
		}
		else if (_playerPrefs.OpenedCards [numeroTarjeta-1] == 1) {
			SoundBotones.SFXPlayShot(3);
			tarjetasCanvasHide (true);
			tarjetaCanvas.SendMessage ("InicializaTarjeta",numeroTarjeta);
		}


	}



	public void CompraTarjeta(int numeroTarjeta){

		if (_playerPrefs.OpenedCards [numeroTarjeta-1] == 0) 
		{
			if ((numeroTarjeta >= 23 && numeroTarjeta <= 25) && _playerPrefs.PuntosTotales >= 700) {
				//Debug.Log ("Tarjeta del rango Oro:" + numeroTarjeta);
				SoundBotones.SFXPlayShot(3);
				tarjetaMensajeQuiz.SendMessage("ShowQuiz",numeroTarjeta);
				_playerPrefs.UpdatePuntos (-700);
				CountCardsActivadas ();
			}
			else if ((numeroTarjeta >= 17 && numeroTarjeta <= 22) && _playerPrefs.PuntosTotales >= 400) 
			{
				SoundBotones.SFXPlayShot(3);
				//Debug.Log ("Tarjeta del rango plata:" + numeroTarjeta);
				tarjetaMensajeQuiz.SendMessage("ShowQuiz",numeroTarjeta);
				_playerPrefs.UpdatePuntos (-400);
				CountCardsActivadas ();
			}
			else 
			{
				SoundBotones.SFXPlayShot(2);
				tarjetaMensajeQuiz.SendMessage ("ShowMensaje","Incrementa tu puntaje para \n desbloquear esta tarjeta.");
			}
			Txtpuntos.text = _playerPrefs.getPointsTxt();
		}
		else if (_playerPrefs.OpenedCards [numeroTarjeta-1] == 1) {
			SoundBotones.SFXPlayShot(3);
			tarjetasCanvasHide (true);
			tarjetaCanvas.SendMessage ("InicializaTarjeta",numeroTarjeta);
		}
	}

	public void tarjetasCanvasHide(bool isHide){
		tarjetaCanvas.SetActive (isHide);

	}

	public void goToMenu(){
		Application.LoadLevel ("MenuPrincipal");
	}
}
