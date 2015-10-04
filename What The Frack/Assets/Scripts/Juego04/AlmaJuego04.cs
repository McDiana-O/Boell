using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class AlmaJuego04 : MonoBehaviour {
	public float time=2;
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
	public AudioSource audioClipMain;
	public AudioSource audioWin;
	public AudioSource audioLose;
	stateGameMini04 mysate;
	private timedown _timeDown;
	public GameObject MenuWinLose;
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public int level;

	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text =_playerPrefs.PuntosTotales.ToString()+" pts";
		//nivel = PlayerPrefs.GetInt ("Nivel");
		//nivel =_playerPrefs.NivelActual;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		level = _playerPrefs.NivelActual;
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
		if (mysate != stateGameMini04.Gano && mysate != stateGameMini04.Perdio) {
			#if UNITY_ANDROID
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Began && mysate == stateGameMini04.Inicio) {
				Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				if (worldPos.y > 160.0f && worldPos.y < 252.0f && worldPos.x > -28.0f && worldPos.x < 28.0f) {
					coordenadasAnt = worldPos;
					mysate = stateGameMini04.Pulsando;
					Perforacion.transform.position = Vector3.up * (worldPos.y + 204.0f);
					audioPerforacion.Play();
				}
			}
			if (Input.touchCount > 0 && Input.GetTouch (0).phase == TouchPhase.Moved && mysate == stateGameMini04.Pulsando) {
				Vector3 worldPos = Camera.main.ScreenToWorldPoint (Input.GetTouch (0).position);
				if (worldPos.x < -28.0f || worldPos.x > 28.0f) {
					textoPruebas.text = "Se sale x="+worldPos.x;
					mysate = stateGameMini04.Perdio;
					audioPerforacion.Stop();
				} else if(coordenadasAnt.y > worldPos.y) {
					Perforacion.transform.position = Vector3.up * (worldPos.y + 194.0f);
					coordenadasAnt = worldPos;
					if (worldPos.y < -200.0f) {
						mysate = stateGameMini04.Gano;
						audioPerforacion.Stop();
						audioClipWin.Play();
						_playerPrefs.SetNewLevel();
						_txtPuntos.text =_playerPrefs.PuntosTotales.ToString()+" pts";
					}
				}
			}
			if (Input.touchCount > 0 && (Input.GetTouch (0).phase == TouchPhase.Canceled || Input.GetTouch (0).phase == TouchPhase.Ended) && mysate == stateGameMini04.Pulsando) {
				textoPruebas.text = Input.GetTouch (0).phase.ToString();
				mysate = stateGameMini04.Perdio;
				audioPerforacion.Stop();
			}
			#endif
			if (_timeDown.isTimeOver && mysate != stateGameMini04.Gano && mysate != stateGameMini04.Perdio) {
				//textoPruebas.text = "Pierde por Tiempo";
				mysate = stateGameMini04.Perdio;;
				audioPerforacion.Stop();
			}
		}
	}

	IEnumerator countdown()
	{
		//timer.text = time.ToString();
		while (time >0 && mysate!= stateGameMini04.Gano)
		{
			yield return new WaitForSeconds(1);
			time -= 1;
			//timer.text = time.ToString();
		}
	}
	IEnumerator SetWinLose()
	{
		while (mysate!= stateGameMini04.Perdio && mysate!= stateGameMini04.Gano) {
			yield return new WaitForSeconds(0.7f);
		}
		_timeDown.ActivateClock = false;
		audioClipMain.Stop();
		if(mysate == stateGameMini04.Gano)
			audioWin.Play ();
		else
			audioLose.Play ();
		yield return new WaitForSeconds(1);
		MenuWinLose.SetActive (true);
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mysate== stateGameMini04.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
	}
	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		_timeDown.waitTime = time;
		_timeDown.ActivateClock = true;
		mysate = stateGameMini04.Inicio;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			_timeDown.waitTime = time;
			_timeDown.ActivateClock = true;
			mysate = stateGameMini04.Inicio;
		}
	}
}
