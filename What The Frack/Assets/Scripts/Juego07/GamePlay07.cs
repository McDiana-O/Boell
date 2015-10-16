using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay07 : MonoBehaviour {
	public GameObject PerforacionVertical;
	public GameObject PerforacionDiagonal;
	public GameObject[] PuntosObjetivos;
	public GameObject MenuWinLose;
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;

	public enum stateGame07{Begin,AnimVertical,AnimDiagonal,Win,Lose,End};

	public bool _isTouchScreen=false;
	public bool Gane=false;
	public int temp;
	public int nivel;

	private StopPerforacion _stopPerforacion;
	public stateGame07 myState;
	private float _tempy;

	public Button _btnGame;
	public int wait=3;

	private float[] vertical = {0.0f,25.0f,15.0f,8.0f};

	//esperando un segundo
	private float time=1;
	
	//Audios
	public AudioSource _audioTema;
	public AudioSource _Sfxaudio;
	public AudioClip[] winloseAudio;
	public AudioClip sfxClip;
	public bool isPausing=false;
	// Use this for initialization
	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
		//nivel = PlayerPrefs.GetInt ("Nivel");nivel = PlayerPrefs.GetInt ("Nivel");
		nivel =_playerPrefs.NivelActual;
		temp = Random.Range (0, 3);
		showPuntoObjetivo (temp);
		myState = stateGame07.Begin;

		_btnGame.enabled = false;

		_stopPerforacion = PerforacionDiagonal.GetComponent<StopPerforacion> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPausing) {
			if(wait<=0 && myState == stateGame07.Begin){
				_Sfxaudio.Play();
				_Sfxaudio.loop=true;
				myState = stateGame07.AnimVertical;
			}
			
			if(myState != stateGame07.Lose && myState != stateGame07.Win)
			{
				if (_stopPerforacion.isTouchPoint) {
					_playerPrefs.SetNewLevel();
					_txtPuntos.text = _playerPrefs.getPointsTxt ();

					_Sfxaudio.Stop();
					_Sfxaudio.PlayOneShot(sfxClip);
					myState = stateGame07.Win;
					_audioTema.Stop();
					_audioTema.PlayOneShot(winloseAudio[0],0.6f);
					StartCoroutine (countdown());
				}
				else if (myState == stateGame07.AnimVertical) {
					animacionVertical ();
					_btnGame.enabled = true;;
					//touchDetecting();
				} 
				else if(myState == stateGame07.AnimDiagonal) {
					animacionDiagonal ();
				}
			}
			/*if (myState == stateGame07.Win) {
			//myState = stateGame07.Win;
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		}
		if (myState == stateGame07.Lose) {
			//myState = stateGame07.Win;
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
		*/
			if ((myState == stateGame07.Lose || myState == stateGame07.Win) && time<=0) {
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(myState == stateGame07.Win ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
				
			}
		}

	}

	void showPuntoObjetivo(int i){
		PuntosObjetivos[i].SetActive(true);
	}

	public void touchDetecting(){
		/*foreach (var T in Input.touches) {
			if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
			{*/
				//_isTouchScreen=true;
				//Debug.Log("entroaqui ");
				myState = stateGame07.AnimDiagonal;
				//Debug.Log("entroaqui "+myState.ToString());
			//}
		//}
	}
	
	void animacionVertical(){
		if (PerforacionVertical.transform.position.y > 0.5f) {
			PerforacionVertical.transform.Translate (Vector3.down /vertical[nivel]);
		}
		else {
			myState = stateGame07.Lose;
			_Sfxaudio.Stop();
			_audioTema.Stop();
			_audioTema.PlayOneShot(winloseAudio[1],0.6f);
			StartCoroutine (countdown());
		}
	}

	void animacionDiagonal(){
		if(PerforacionDiagonal.transform.localScale.y<1.40){
			_tempy= PerforacionDiagonal.transform.localScale.y +0.005f;
			PerforacionDiagonal.transform.localScale = new Vector3 (1, _tempy, 1);
		}
		else {
			myState = stateGame07.Lose;
			_Sfxaudio.Stop();
			_audioTema.Stop();
			_audioTema.PlayOneShot(winloseAudio[1],0.6f);
			StartCoroutine (countdown());
		}
	}

	IEnumerator countdownBeginGame()
	{
		while (wait > 0)
		{
			//timer.text = time.ToString();
			wait -= 1;
			yield return new WaitForSeconds(1);
		}
	}

	IEnumerator countdown()
	{
		//timer.text = time.ToString();
		while (time >0 && (myState != stateGame07.Lose|| myState != stateGame07.Win))
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
			//timer.text = time.ToString();
		}
	}


	//Funciones para  botones de la UI
	public void InPause(){
		isPausing = true;
		_Sfxaudio.Pause();
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);
	}
	public void OutPause(){
		_Sfxaudio.UnPause();
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;

	}
	public void hideCards(){
		TarjestasInformativas.SetActive (false);
		/*if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			StartCoroutine (countdownBeginGame());
			CanvasTutorial.SetActive (false);
		}*/

	} 
	public void HideTutorial(){
		_playerPrefs.seveTutorial ();
		StartCoroutine (countdownBeginGame());
		CanvasTutorial.SetActive (false);

	}
}
