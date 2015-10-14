using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpQuiz : MonoBehaviour {

	public GameObject[] tarjetaDisabled;
	public GameObject[] tarjetaActive;
	public int[] correctAnswer;
	//public int[] cardCost;  //ESTE ES EL ARREGLO CON EL COSTO DE LAS TARJETAS 
	public GameObject popUpQuiz;
	public GameObject btnTrue;
	public GameObject btnFalse;
	public GameObject tarjetaCanvas;
	public string[] contenidos;
	public Text txt_contenido;
	public Text txt_countTarjetas;  //CUENTA EL NUMERO DE TARJETAS QUE TIENE EL USUARIO
	public AudioSource _soundWin;
	public AudioSource _soundClick;
	public Button cards;
	public bool isInteractable;
	public int interactableCards;
	public int idCartaActiva;
	//private GamePlayerPrefs _playerPrefs;

	public Text txtPuntos;
	public menuTarjetas _menutarjetas;
	// Use this for initialization
	void Start () {
	//	_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
	}
	public void minigameCardOn (int gameCardNum) {
		//_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		//cards.IsActive (true);
		//txt_countTarjetas.text = Text
	}


	public void TarjetaHide (int numeroTarjeta){
		/*
		if (_playerPrefs.PuntosTotales >= 700) {
			restarPuntos (numeroTarjeta);
			_playerPrefs.setOpenCard (numeroTarjeta);
			_menutarjetas.checkCardsActivadas ();
			idCartaActiva = numeroTarjeta;
			tarjetaDisabled [numeroTarjeta].SetActive (false);
			popUpQuiz.SetActive (true);
			InicializaQuiz (numeroTarjeta);
		} 
		else if (_playerPrefs.PuntosTotales >= 400) {
			restarPuntos (numeroTarjeta);
			_playerPrefs.setOpenCard (numeroTarjeta);
			_menutarjetas.checkCardsActivadas ();
			idCartaActiva = numeroTarjeta;
			tarjetaDisabled [numeroTarjeta].SetActive (false);
			popUpQuiz.SetActive (true);
			InicializaQuiz (numeroTarjeta);
		} 
		else {
			Debug.Log("No Tienes puntos Suficientes");
		}*/
		/*if (_playerPrefs.PuntosTotales > 400) {
			restarPuntos (numeroTarjeta);
			_playerPrefs.setOpenCard (numeroTarjeta);
			_menutarjetas.checkCardsActivadas ();
			idCartaActiva = numeroTarjeta;
			tarjetaDisabled [numeroTarjeta].SetActive (false);
			popUpQuiz.SetActive (true);
			InicializaQuiz (numeroTarjeta);
		}*/
	}

	public void InicializaQuiz(int numeroTarjeta){
		txt_contenido.text= contenidos[numeroTarjeta];
		tarjetaActive[idCartaActiva].SetActive(true);
		//txt_titulo.text = System.Text.RegularExpressions.Regex.Unescape(titulos [numeroTarjeta - 1]);
		//imgCard.sprite = ImgCards [numeroTarjeta - 1]
	}
	

	public void compareAnswer(int btnAnswer){
		//string[] temp = btnAnswer.Split (',');
		//Debug.Log (temp [0].ToString () + " otro valor: " + temp [1].ToString ());
		//int id = int.Parse (temp [1]);

		if(btnAnswer==correctAnswer[idCartaActiva]){
			Debug.Log("Correcto");
		}
		else{
			Debug.Log("Loser");
		}
		;
		popUpQuiz.SetActive (false);
		tarjetaCanvas.SetActive (true);
		tarjetaCanvas.GetComponent<TarjetaInformativa> ().InicializaTarjeta (idCartaActiva + 17);
		//tarjetaCanvas.GetComponent<TarjetaInformativa>().idCard=idCardaActiva+16;
		//tarjetaCanvas.GetComponent<TarjetaInformativa>().PlayNow=true;


	}

	/*public void  restarPuntos(int Index){
		Debug.Log (Index);
		if (Index <= 5) {
			_playerPrefs.UpdatePuntos (-400);
		} 
		else {
			_playerPrefs.UpdatePuntos (-700);
		}
		txtPuntos.text = _playerPrefs.getPointsTxt();

	}*/
	/*
	public void ActivaTarjeta(int numeroTarjeta){
		switch (numeroTarjeta) {
		case 0:
			//destruyeTarjeta(numeroTarjeta+1);
			InicializaQuiz(numeroTarjeta+1);
			if (btnTrue == true ){
				_soundClick.Play ();
				tarjetaCanvas.SetActive(true);
				tarjetaCanvas.SendMessage ("InicializaTarjeta",numeroTarjeta+1);
				tarjetaActive [numeroTarjeta].SetActive (true);

			}else{
				if (btnFalse == true){
					_soundWin.Play ();
					tarjetaCanvas.SetActive(true);
					tarjetaCanvas.SendMessage ("InicializaTarjeta",numeroTarjeta);
					tarjetaActive [numeroTarjeta].SetActive (true);
					this.gameObject.SetActive(false);
				}
		    }
		    break;
		}
		//tarjetaActive [numeroTarjeta - 1].SetActive (true);
	}*/








}
