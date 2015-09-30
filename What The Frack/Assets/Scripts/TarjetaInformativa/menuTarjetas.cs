using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuTarjetas : MonoBehaviour {

	public GameObject tarjetaCanvas;
	private GamePlayerPrefs _playerPrefs;
	public GameObject[] Cards;
	public GameObject[] CardsBuy;
	public Text Txtpuntos;
	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		checkCardsActivadas ();
		Txtpuntos.text = _playerPrefs.PuntosTotales.ToString()+" pts";
	}
	
	// Update is called once per frame
	void Update () {

	}

	void checkCardsActivadas(){
		for (int index=0; index<14; index++) {
			if(_playerPrefs.Tutos[index]>=1 && index<13)
			{
				Cards[index+1].GetComponent<Button>().interactable=true;
			}
			else if (_playerPrefs.Tutos[index]>=1 && index>=13){
				Cards[index+1].GetComponent<Button>().interactable=true;
				Cards[index+2].GetComponent<Button>().interactable=true;
			}
		}	

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
		}
	}
	public void activaTarjeta(int numeroTarjeta){
		tarjetasCanvasHide (true);
		tarjetaCanvas.SendMessage ("InicializaTarjeta",numeroTarjeta);

	}
	public void tarjetasCanvasHide(bool isHide){
		tarjetaCanvas.SetActive (isHide);

	}

	public void goToMenu(){
		Application.LoadLevel ("MenuPrincipal");
	}
}
