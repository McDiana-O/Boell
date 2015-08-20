using UnityEngine;
using System.Collections;

public class GamePlay05 : MonoBehaviour {

	public Vector2 coordenadas;
	public GameObject Bar;
	RectTransform rt;

	// Use this for initialization
	void Start () {
		rt = Bar.GetComponent (typeof (RectTransform)) as RectTransform;
		//rt.sizeDelta = new Vector2 (320, 5500);

	}
	
	// Update is called once per frame
	void FixedUpdate () {
		coordenadas= Camera.main.ScreenToWorldPoint( Input.mousePosition);
		Debug.LogError (coordenadas.y);
		rt.offsetMin = new Vector2 (rt.offsetMin.x,608.0f+(coordenadas.y+3.6f)*800.0f);
	}

	//void
	//{
		//MenuWinLose.SetActive(true);
			//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
	//}
}
