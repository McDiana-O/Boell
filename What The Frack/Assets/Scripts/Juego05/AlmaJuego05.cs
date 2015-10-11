using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AlmaJuego05 : MonoBehaviour {
	public float time=2;
	public Text timer;
	public Text textoPruebas;
	public RawImage agua;
	public Vector2 coordenadas;
	public Vector3 coordenadasAnt;
	public Vector3 coordScreen;
	private float tempPulsos;
	public enum stateGameMini05{Pausa,Inicio,Pulsando,Gano,Perdio};
	public GameObject Perforacion;
	//public AudioSource audioPerforacion;
	public AudioSource audioClipWin;
	public AudioSource audioClipMain;
	public AudioSource audioWin;
	public AudioSource audioLose;
	stateGameMini05 mysate;
	private timedown _timeDown;
	public GameObject MenuWinLose;
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public int level;

	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text =_playerPrefs.getPointsTxt();
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		level = _playerPrefs.NivelActual;
		mysate = stateGameMini05.Pausa;
		switch (level) {
		case 1:
			time = 8.0f;
			break;
		case 2:
			time= 7.0f;
			break;
		case 3:
			time = 5.0f;
			break;
		}
		//StartCoroutine (countdown());
		StartCoroutine (SetWinLose ());
	}

	void FixedUpdate(){
		if (mysate != stateGameMini05.Pausa) {
			if (mysate != stateGameMini05.Gano && mysate != stateGameMini05.Perdio) {
				#if UNITY_STANDALONE || UNITY_EDITOR
				/*coordenadas = Camera.main.ScreenToWorldPoint (Input.mousePosition);
			//textoPruebas.text = "x=" + coordenadas.x.ToString () + " y=" + coordenadas.y.ToString ();
			if (Input.GetMouseButtonDown (0)) {
				Perforacion.transform.position = Vector3.up * (coordenadas.y + 205.0f);
				audioPerforacion.Play();
			}*/
				#endif
		
				#if UNITY_ANDROID

				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && mysate == stateGameMini05.Inicio) {
					Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
					if (worldPos.y > 140.0f && worldPos.y < 222.0f && worldPos.x > -48.0f && worldPos.x < 48.0f) {
						coordenadasAnt = worldPos;
						mysate = stateGameMini05.Pulsando;
						Perforacion.transform.position = Vector3.up * (worldPos.y);
						//audioPerforacion.Play();
					}
				}
				if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved && mysate == stateGameMini05.Pulsando) {
					Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
					if (worldPos.x < -13.0f || worldPos.x > 13.0f || coordenadasAnt.y < worldPos.y) {
						//Debug.Log ("Pierde por Salirse");
						//Debug.Log ("x="+worldPos.x+" y="+worldPos.y);
						mysate = stateGameMini05.Perdio;
						//audioPerforacion.Stop();
					} else {
						Perforacion.transform.position = new Vector3 (worldPos.x, worldPos.y, 1.0f);
						coordenadasAnt = worldPos;
						if (worldPos.y < -220.0f) {
							mysate = stateGameMini05.Gano;
							_playerPrefs.SetNewLevel ();
							_txtPuntos.text = _playerPrefs.PuntosTotales.ToString () + " pts";
							//audioPerforacion.Stop();
							audioClipWin.Play ();
						}
					}
				}
				if (Input.touchCount > 0 && (Input.GetTouch (0).phase == TouchPhase.Canceled || Input.GetTouch (0).phase == TouchPhase.Ended) && mysate == stateGameMini05.Pulsando) {
					//textoPruebas.text = "Pierde por Soltar";
					//Debug.Log ("Pierde por Soltar");
					mysate = stateGameMini05.Perdio;
					//audioPerforacion.Stop();
				}
				#endif
				if (_timeDown.isTimeOver && mysate != stateGameMini05.Gano && mysate != stateGameMini05.Perdio) {
					//textoPruebas.text = "Pierde por Tiempo";
					//Debug.Log ("Pierde por Tiempo");
					mysate = stateGameMini05.Perdio;
					;
					//audioPerforacion.Stop();
				}
			}
		}
	}

	IEnumerator countdown()
	{
		//timer.text = time.ToString();
		while (time >0 && mysate!= stateGameMini05.Gano)
		{
			yield return new WaitForSeconds(1);
			time -= 1;
			//timer.text = time.ToString();
		}
	}
	IEnumerator SetWinLose()
	{
		while (mysate!= stateGameMini05.Perdio && mysate!= stateGameMini05.Gano) {
			yield return new WaitForSeconds(0.7f);
		}
		_timeDown.ActivateClock = false;
		audioClipMain.Stop();
		if(mysate == stateGameMini05.Gano)
			audioWin.Play ();
		else
			audioLose.Play ();
		yield return new WaitForSeconds(1);
		MenuWinLose.SetActive (true);
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mysate== stateGameMini05.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
	}
	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		_timeDown.waitTime = time;
		_timeDown.ActivateClock = true;
		mysate = stateGameMini05.Inicio;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			_timeDown.waitTime = time;
			_timeDown.ActivateClock = true;
			mysate = stateGameMini05.Inicio;
		}
	}
}
