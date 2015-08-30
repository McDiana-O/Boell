using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuTarjetas : MonoBehaviour {
	
	public GameObject tarjetaCanvas;
	public Text txt_contenido,txt_titulo,txt_numTerjeta;
	public Image imgCard;
	public string[] contenidos;
	public string[] titulos;
	public Sprite[] ImgCards;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void activaTarjeta(int numeroTarjeta){
		tarjetasCanvasHide (true);
		txt_numTerjeta.text = "0" + numeroTarjeta;
		txt_contenido.text= contenidos[numeroTarjeta-1];

		if (numeroTarjeta < 16) {
			txt_titulo.text=titulos[numeroTarjeta-1];
		}
		if (numeroTarjeta < 5) {
			imgCard.sprite = ImgCards [numeroTarjeta - 1];
		}
		else {
			imgCard.sprite = ImgCards [0];
		}
	}
	public void tarjetasCanvasHide(bool isHide){
		tarjetaCanvas.SetActive (isHide);

	}

	public void goToMenu(){
		Application.LoadLevel ("MenuPrincipal");
	}
}
