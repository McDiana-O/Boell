using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AlmaJuego04 : MonoBehaviour {
	public int time;
	public Text timer;
	public RawImage agua;
	public Vector2 coordenadas;
	public Vector3 coordScreen;
	private float tempPulsos;
	public enum stateGameMini10{Inicio,Pulsando,Gano,Perdio};
	stateGameMini10 mysate;

	public GameObject MenuWinLose;

	// Use this for initialization
	void Start () {
		mysate = stateGameMini10.Inicio;
		StartCoroutine (countdown());
		//tempPulsos = (recTransformAgua.localScale.y *100)/2;
		//texto.text = tempPulsos.ToString();
		/*RectTransform rt = agua.GetComponent (typeof (RectTransform)) as RectTransform;
		rt.sizeDelta = new Vector2 (20, 20);*/

	}

	void FixedUpdate(){

		#if UNITY_STANDALONE || UNITY_EDITOR
		coordenadas= Camera.main.ScreenToWorldPoint( Input.mousePosition);
		
		Debug.Log(coordenadas);
		agua.uvRect = new Rect (new Vector2(0.0f,(float)((1)*(coordenadas.y/-2.6))),new Vector2(1.0f,1.0f));
		if (Input.GetMouseButtonDown (0)) {
			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
		}
		#endif
		
		#if UNITY_ANDROID
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
			//sierra.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
			Debug.Log("X="+worldPos.x+" Y="+worldPos.y);
			agua.uvRect = new Rect (new Vector2(0.0f,(float)((1)*(worldPos.y+1/-2.6))),new Vector2(1.0f,1.0f));
		}
		#endif
		//if (agua.fillAmount == 0 && mysate != stateGameMini10.Perdio) {
		if (false) {
			mysate = stateGameMini10.Gano;
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		} else if (time <= 0 && mysate != stateGameMini10.Gano) {
			mysate = stateGameMini10.Perdio;
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}

	public void CuentaPulsadas(){
		//if (agua.fillAmount > 0 && (mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano)) {
		if ((mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano)) {
			mysate = stateGameMini10.Pulsando;
		} 
	}


	IEnumerator countdown()
	{
		while (time >=0 && mysate!= stateGameMini10.Gano)
		{
			time -= 1;
			timer.text = time.ToString();
			yield return new WaitForSeconds(1);
		}
	}
}
