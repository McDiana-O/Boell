using UnityEngine;
using System.Collections;

public class WaitToMenu : MonoBehaviour {
	public void nextoTarjeta(){
		Application.LoadLevel ("tarjetainformativa");
	}

	///funciones para Creditos

	public void GoToScene(string value){
		Application.LoadLevel (value);
	}

	public void OpenSitiosOPorUrl(string value)
	{
		Application.OpenURL (value);
	}
}
