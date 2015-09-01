using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AlmaJuego04 : MonoBehaviour {
	public int time;
	public Text timer;
	public Text textoPruebas;
	public RawImage agua;
	public Vector2 coordenadas;
	public Vector3 coordenadasAnt;
	public Vector3 coordScreen;
	private float tempPulsos;
	public enum stateGameMini04{Inicio,Pulsando,Gano,Perdio};
	public GameObject Perforacion;
	public AudioSource audioPerforacion;
	public AudioSource audioClipWin;
	stateGameMini04 mysate;

	public GameObject MenuWinLose;

	// Use this for initialization
	void Start () {
		mysate = stateGameMini04.Inicio;
		StartCoroutine (countdown());
		StartCoroutine (SetWinLose ());
	}

	void FixedUpdate(){
		if (mysate != stateGameMini04.Gano && mysate != stateGameMini04.Perdio) {
			#if UNITY_STANDALONE || UNITY_EDITOR
			coordenadas = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//textoPruebas.text = "x=" + coordenadas.x.ToString () + " y=" + coordenadas.y.ToString ();
			if (Input.GetMouseButtonDown (0)) {
				Perforacion.transform.position = Vector3.up * (coordenadas.y + 194.0f);
				audioPerforacion.Play();
			}
			#endif
		
			#if UNITY_ANDROID

			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && mysate == stateGameMini04.Inicio) {
				Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				if (worldPos.y > 160.0f && worldPos.y < 172.0f && worldPos.x > -20.0f && worldPos.x < 20.0f) {
					coordenadasAnt = worldPos;
					mysate = stateGameMini04.Pulsando;
					Perforacion.transform.position = Vector3.up * (worldPos.y + 194.0f);
					audioPerforacion.Play();
				}
			}
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved && mysate == stateGameMini04.Pulsando) {
				Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				if (worldPos.x < -25.0f || worldPos.x > 25.0f || coordenadasAnt.y <= worldPos.y) {
					//textoPruebas.text = "Pierde por Salirse";
					mysate = stateGameMini04.Perdio;
					audioPerforacion.Stop();
				} else {
					Perforacion.transform.position = Vector3.up * (worldPos.y + 194.0f);
					coordenadasAnt = worldPos;
					if (worldPos.y < -228.0f) {
						mysate = stateGameMini04.Gano;
						audioPerforacion.Stop();
						audioClipWin.Play();
					}
				}
			}
			if (Input.touchCount > 0 && (Input.GetTouch (0).phase == TouchPhase.Canceled || Input.GetTouch (0).phase == TouchPhase.Ended) && mysate == stateGameMini04.Pulsando) {
				//textoPruebas.text = "Pierde por Soltar";
				mysate = stateGameMini04.Perdio;
				audioPerforacion.Stop();
			}
			#endif
			if (time <= 0 && mysate != stateGameMini04.Gano && mysate != stateGameMini04.Perdio) {
				//textoPruebas.text = "Pierde por Tiempo";
				mysate = stateGameMini04.Perdio;;
				audioPerforacion.Stop();
			}
		}
	}

	IEnumerator countdown()
	{
		timer.text = time.ToString();
		while (time >0 && mysate!= stateGameMini04.Gano)
		{
			yield return new WaitForSeconds(1);
			time -= 1;
			timer.text = time.ToString();
		}
	}
	IEnumerator SetWinLose()
	{
		while (mysate!= stateGameMini04.Perdio && mysate!= stateGameMini04.Gano) {
			yield return new WaitForSeconds(0.7f);
		}
		yield return new WaitForSeconds(1);
		MenuWinLose.SetActive (true);
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mysate== stateGameMini04.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
	}
}
