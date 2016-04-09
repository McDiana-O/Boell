using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego3 : MonoBehaviour {

	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	private timedown _timeDown;
	
	//public Text timer;
	public GameObject[] piletones;
	public GameObject[] points;
	public bool win;
	private bool BeginGame=false;
	public GameObject MenuWinLose;
	private int[] numPiletones;
	private int Piletonestotales;
	public int nivel;
	public int[] pointID;

	//esperando un segundo
	private float time=1;
	//Audios
	public AudioSource _audioTema;
	//public AudioClip[] winloseAudio;
	public AudioSource audioWin;
	public AudioSource audioLose;
	public bool isPausing=false;
	// Use this for initialization
	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
		//nivel = PlayerPrefs.GetInt ("Nivel");
		_playerPrefs.CamaraIpadResolution();
		IsIpad();
		nivel =_playerPrefs.NivelActual;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();

		win=false;
		if(nivel==1){
			Piletonestotales=2;
		}
		else if(nivel==2){
			Piletonestotales=3;
		}
		else if(nivel==3){
			Piletonestotales=4;
		}
		pointID = NumerosRandom.randomArray (6);
		for (int i=0;i<Piletonestotales;i++)
		{
			piletones[pointID[i]].SetActive(true);
			points[pointID[i]].SetActive(true);
			points[pointID[i]] .GetComponent<AlphaAnimacion>().activateAnimacion=true;
		}
		// numPiletones = new int[2, 3, 4];
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPausing) {
			if (BeginGame) {
				/*if(piletones[0].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop
			   && piletones[1].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop &&
			   piletones[2].GetComponent<ScripPileton>().mystate== ScripPileton.statePileton.drop)*/
				if(Piletonestotales==0)
				{
					win=true;
					_playerPrefs.SetNewLevel();
					_txtPuntos.text = _playerPrefs.getPointsTxt ();

					_timeDown.ActivateClock=false;
					_audioTema.Stop();
					audioWin.Play();
					StartCoroutine (countdown());
					BeginGame = false;
					//timer.text = "you win!!!";
					//MenuWinLose.SetActive(true);
					//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
				}
				else if (_timeDown.isTimeOver) {
					
					_timeDown.ActivateClock=false;
					_audioTema.Stop();
					audioLose.Play();
					StartCoroutine (countdown());
					BeginGame = false;
					//MyStateGame = stateGame.Perdio;
					//timer.text = "you lost!!!";
					//MenuWinLose.SetActive(true);
					//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
				}
			}
		}

		if (time<=0){
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(win == true ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}
	

	IEnumerator countdown()
	{

		while (time >0)
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
		}
	}

	//Funciones para  botones de la UI
	public void InPause(){
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);

	}
	public void OutPause(){
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;
	}

	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		_timeDown.ActivateClock = true;
		//StartCoroutine (countdown());
		BeginGame = true;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		/*if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			_timeDown.ActivateClock = true;
			//StartCoroutine (countdown());
			BeginGame = true;
		}*/
	}

	public void lessPiletones(){
		Piletonestotales -= 1;
	}
	void IsIpad(){
		if(_playerPrefs.isIpad){
			GameObject cam = GameObject.FindGameObjectWithTag("MainCamera");
			CameraFit camfit= cam.GetComponent<CameraFit>();
			camfit.UnitsForWidth=16.36f;
			cam.transform.position= new Vector3(0.0f,-0.5f,-10.0f);

		}
	}
}
