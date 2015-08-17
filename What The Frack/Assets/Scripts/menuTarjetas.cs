using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class menuTarjetas : MonoBehaviour {
	
	public GameObject tarjetaCanvas;
	public Text txt_contenido,txt_titulo,txt_numTerjeta;
	public string[] contenidos;
	public string[] titulos;
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
	}
	public void tarjetasCanvasHide(bool isHide){
		tarjetaCanvas.SetActive (isHide);

	}

	public void goToMenu(){
		Application.LoadLevel ("MenuPrincipal");
	}
}
