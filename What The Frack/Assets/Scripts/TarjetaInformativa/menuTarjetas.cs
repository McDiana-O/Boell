using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuTarjetas : MonoBehaviour {

	public GameObject tarjetaCanvas;
	public Sprite[] ButonsSpritesTarjetas;
	private GamePlayerPrefs _playerPrefs;
	public GameObject[] Cards;
	public GameObject[] CardsBuy;

	public Text Txtpuntos;
	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		checkCardsActivadas ();
		Txtpuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Time: " + Time.time);
	}

	public void checkCardsActivadas(){
//		changeButtonActivate (Cards[0].GetComponent<Button>(),false); 
		changeButtonActivate (Cards[0].GetComponent<Button>(),true); 
		for (int index=0; index<14; index++) {

			if(_playerPrefs.Tutos[index]>=1 && index<13)
			{
				changeButtonActivate (Cards[index+1].GetComponent<Button>(),true); 
				//Cards[index+1].GetComponent<Button>().interactable=true;
			}
			else if (_playerPrefs.Tutos[index]>=1 && index>=13){
				//Cards[index+1].GetComponent<Button>().interactable=true;
				//Cards[index+2].GetComponent<Button>().interactable=true;
				changeButtonActivate (Cards[index+1].GetComponent<Button>(),true); 
				changeButtonActivate (Cards[index+2].GetComponent<Button>(),true); 
			}
		}	
		/*
		if (_playerPrefs.PuntosTotales >= 400) {
			Cards[16].GetComponent<Button>().interactable=true;
			Cards[17].GetComponent<Button>().interactable=true;
			Cards[18].GetComponent<Button>().interactable=true;
			Cards[19].GetComponent<Button>().interactable=true;
			Cards[20].GetComponent<Button>().interactable=true;
			Cards[21].GetComponent<Button>().interactable=true;
		}

		if (_playerPrefs.PuntosTotales >= 700) {
			Cards[22].GetComponent<Button>().interactable=true;
			Cards[23].GetComponent<Button>().interactable=true;
			Cards[24].GetComponent<Button>().interactable=true;
		}

		for (int index=0; index<_playerPrefs.OpenedCards.Length; index++) {
			if(_playerPrefs.OpenedCards[index]==1)
			{
				Cards[index+16].SetActive(false);
				CardsBuy[index].SetActive(true);
			}
		}*/
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
	public void activaTarjeta(int numeroTarjeta){
		if (_playerPrefs.OpenedCards [numeroTarjeta-1] == 0) {
			Debug.Log("Puntos insuficientes");
		}
		else if (_playerPrefs.OpenedCards [numeroTarjeta-1] == 1) {
			tarjetasCanvasHide (true);
			tarjetaCanvas.SendMessage ("InicializaTarjeta",numeroTarjeta);
		}


	}

	public void CompraTarjeta(int numeroTarjeta){
		if ((numeroTarjeta>=23||numeroTarjeta<=25) && _playerPrefs.PuntosTotales >= 700) {
		}
		
		
	}

	public void tarjetasCanvasHide(bool isHide){
		tarjetaCanvas.SetActive (isHide);

	}

	public void goToMenu(){
		Application.LoadLevel ("MenuPrincipal");
	}
}
