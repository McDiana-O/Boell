using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay08 : MonoBehaviour {
	public enum stateGameMini08{Inicio,Iniciando,Jugando,Gano,Perdio};
	public stateGameMini08 mystate;
	public int level;
	public WaterAnimacion _fondo;
	public float divisorVelPerfo=60f;
	public float divisorVelLinea=19f;
	private timedown _timeDown;
	public float time=2,velocidadFondo;
	public GameObject MenuWinLose;
	public GameObject LineaPunteada;
	public GameObject TarjetasInformativas; 
	public GameObject CanvasTutorial;
	public AudioSource audioPerforacion;
	public AudioSource audioClipMain;
	public AudioSource audioWin;
	public AudioSource audioLose;
	// Use this for initialization
	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	public bool isPausing=false;
	void Awake(){
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
	}
	void Start () {
		//_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		//_txtPuntos.text =_playerPrefs.getPointsTxt();
		_fondo = GameObject.FindGameObjectWithTag ("Fondo").GetComponent<WaterAnimacion> ();
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		_timeDown.ActivateClock = false;
		mystate = stateGameMini08.Inicio;
		level =_playerPrefs.NivelActual;
		//level = 3;
		_fondo.scrollSpeed=0.0f;
		switch (level) {
		case 1:
			//_fondo.scrollSpeed=0.1f;
			velocidadFondo=0.2f;
			divisorVelPerfo=30f;
			divisorVelLinea=8.5f;
			time = 12.0f;
			break;
		case 2:
			//_fondo.scrollSpeed=0.15f;
			velocidadFondo=0.15f;
			divisorVelPerfo=45f;
			divisorVelLinea=13.75f;
			time = 9.0f;
			break;
		case 3:
			//_fondo.scrollSpeed=0.2f;
			velocidadFondo=0.1f;
			divisorVelPerfo=60f;
			divisorVelLinea=19f;
			time = 6.0f;
			break;
		}
		for(int i=0;i<24;i++)
			Instantiate (LineaPunteada, new Vector3 (5.5f+i*1.5f, 0.0f, 0.0f), Quaternion.identity);
		StartCoroutine (SetWinLose ());
		//_timeDown.waitTime = time;
		//_timeDown.ActivateClock = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	public void InPause(){
		_playerPrefs.SoundPauseApply (true);
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);
	}
	public void OutPause(){
		_playerPrefs.SoundPauseApply (false);
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;
	}
	IEnumerator SetWinLose()
	{
		while (mystate!= stateGameMini08.Perdio && mystate!= stateGameMini08.Gano) {
			yield return new WaitForSeconds(0.7f);
		}
		//_timeDown.ActivateClock = false;
		audioClipMain.Stop();
		audioPerforacion.Stop();
		_fondo.scrollSpeed = 0.0f;
		if (mystate == stateGameMini08.Gano) {
			_playerPrefs.SetNewLevel();
			_txtPuntos.text = _playerPrefs.getPointsTxt ();
			audioWin.Play ();
		}
		else
			audioLose.Play ();
		yield return new WaitForSeconds(1);
		MenuWinLose.SetActive (true);
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mystate== stateGameMini08.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
	}
	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		//_timeDown.waitTime = time;
		//_timeDown.ActivateClock = true;
		_fondo.scrollSpeed = velocidadFondo;
		audioPerforacion.Play();
		mystate = stateGameMini08.Iniciando;
	}
	
	public void HideTarjetaInformativa(){
		TarjetasInformativas.SetActive (false);
	}
}
