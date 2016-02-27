using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TarjetaInformativa : MonoBehaviour {
	public bool PlayNow;
	/// <summary>
	/// The identifier card. Va deacuerdo al Numero real de la tarejta
	/// </summary>
	public int idCard;
	public Text txt_contenido,txt_titulo,txt_numTerjeta;
	public Image imgCard;
	public string[] contenidos;
	public string[] titulos;
	public Sprite[] ImgCards;
	public AudioSource _soundCard;
	private GamePlayerPrefs _playerPrefs;
	// Use this for initialization
	void Start () {

		if(PlayNow){
			InicializaTarjeta(idCard);
		}
	
	}
	// Update is called once per frame
	void Update () {
	
	}

	public void InicializaTarjeta(int numeroTarjeta){
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		if (_playerPrefs.OnMuteSFX == 0) {
			_soundCard.Play ();
		}

		if (numeroTarjeta < 10) {
			txt_numTerjeta.text = "0" + numeroTarjeta.ToString();
		} else {
			txt_numTerjeta.text = numeroTarjeta.ToString();
		}
		txt_contenido.text= contenidos[numeroTarjeta-1];
		txt_titulo.text = System.Text.RegularExpressions.Regex.Unescape(titulos [numeroTarjeta - 1]);
		imgCard.sprite = ImgCards [numeroTarjeta - 1];
        Debug.Log("Numero de tarjeta: "+numeroTarjeta);
    }
}
