using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PopUpQuiz : MonoBehaviour {

	public GameObject[] tarjetaDisabled;
	public GameObject[] tarjetaActive;
	public GameObject popUpQuiz;
	public GameObject cerrarPopUp;
	private bool PlayNow;
	public int idCard;
	public string[] contenidos;
	public Text txt_contenido;
	//public enum tipoMensaje{Gano,Perdio};

	// Use this for initialization
	void Start () {
		if (PlayNow) {
			InicializaQuiz (idCard);
		}
	}
	// Update is called once per frame
	//void Update () {
	//}

	public void popUpActivado (int numeroTarjeta){
		Destroy(tarjetaDisabled[numeroTarjeta-1]);
		tarjetaActive [numeroTarjeta - 1].SetActive (true);
	}

	public void InicializaQuiz(int numeroTarjeta){

		txt_contenido.text= contenidos[numeroTarjeta-1];
		//txt_titulo.text = System.Text.RegularExpressions.Regex.Unescape(titulos [numeroTarjeta - 1]);
		//imgCard.sprite = ImgCards [numeroTarjeta - 1]

	}




}
