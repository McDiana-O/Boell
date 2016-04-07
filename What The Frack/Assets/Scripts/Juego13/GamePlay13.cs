using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay13 : MonoBehaviour {
	// variables de  ley para poder usar   eso XD
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public GameObject MenuWinLose;
	private timedown _timeDown;
	//esperando un segundo para  mandar  el mensaje de  WINLOSE
	private float time=1;

	public GameObject _ParpadeoRojo;
	// Variables para  el juego
	public Button _btnleft;
	public Button _btnRight;
	private ChangeSprite _changeQuake;
	private Animator _animatorQuake;
	/// <summary>
	/// The type state of the myGame13.
	/// </summary>
	private enum stateGame13{Begin,Earthquake,Pause,Win,Lose};
	/// <summary>
	/// The state of this game.
	/// </summary>
	private stateGame13 myState;
	/// <summary>
	/// The previous identifier button.0 is  nothing, 1 is Right and 2 is Left
	/// </summary>
	private int prevIDButton;
	public GameObject[] Fuegos;
	private int nivel;
	private int totaltaps;
	public int[] tapsToDestroy;
	public bool isPausing=false;
	//Audios
	public AudioSource _audioTema;
	//public AudioClip[] winloseAudio;
	public AudioSource audioWin;
	public AudioSource audioLose;
	public AudioClip[] _sfxClip;
	public AudioSource _sfx;
	public AudioSource _sfx2;
	// Use this for initialization
	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
		_playerPrefs.CamaraIpadResolution();
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		myState = stateGame13.Begin;
		nivel = _playerPrefs.NivelActual;
		_changeQuake = GameObject.Find ("mj13_01").GetComponent<ChangeSprite>();
		_animatorQuake = GameObject.Find ("mj13_01").GetComponent<Animator> ();
		_animatorQuake.speed = 0;
		prevIDButton = 0;
		totaltaps = 0;

		tapsToDestroy= new int[3] {10, 15, 20};
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPausing) {
			if(_timeDown.isTimeOver && myState==stateGame13.Earthquake){
				_btnleft.enabled=false;
				_btnRight.enabled=false;
				_audioTema.Stop();
				audioLose.Play();
				_timeDown.ActivateClock=false;
				myState= stateGame13.Lose;
				_animatorQuake.speed = 0;
				StartCoroutine (countdown());
			}
			
			if(myState==stateGame13.Earthquake){
				if(totaltaps==(1*tapsToDestroy[nivel-1])){
					_changeQuake.ChangeImg(1);
					_sfx.PlayOneShot(_sfxClip[0]);
				}
				else if(totaltaps==(2*tapsToDestroy[nivel-1])){
					_changeQuake.ChangeImg(2);
					_sfx.PlayOneShot(_sfxClip[0]);
					Fuegos[0].SetActive(true);
					Fuegos[1].SetActive(true);
					Fuegos[2].SetActive(true);

				}
				else if(totaltaps==(3*tapsToDestroy[nivel-1])){

					Fuegos[0].SetActive(false);
					Fuegos[1].SetActive(false);
					Fuegos[2].SetActive(false);

					Fuegos[3].SetActive(true);
					Fuegos[4].SetActive(true);
					Fuegos[5].SetActive(true);
					Fuegos[6].SetActive(true);
					Fuegos[7].SetActive(true);
					Fuegos[8].SetActive(true);
					Fuegos[9].SetActive(true);
					Fuegos[10].SetActive(true);



					_changeQuake.ChangeImg(3);
					_sfx.PlayOneShot(_sfxClip[0]);
					_btnleft.enabled=false;
					_btnRight.enabled=false;
					myState= stateGame13.Win;
					_playerPrefs.SetNewLevel();
					_txtPuntos.text = _playerPrefs.getPointsTxt ();

					_timeDown.ActivateClock=false;
					_audioTema.Stop();
					audioWin.Play();
					_animatorQuake.speed = 0;
					StartCoroutine (countdown());
				}
			}
			if ((myState == stateGame13.Lose || myState == stateGame13.Win) && time<=0) {
				_sfx2.Stop();
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(myState == stateGame13.Win ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.PerdioFrackit);
				
			}
		}


	}


	public void CountButton(int IDButtonPress){
		if (!isPausing) {
			if (myState == stateGame13.Earthquake) {
				if (prevIDButton != 0) {
					if(prevIDButton != IDButtonPress){
						totaltaps++;
						prevIDButton=IDButtonPress;
						Handheld.Vibrate();
					}
				} 
				else {
					prevIDButton=IDButtonPress;
					totaltaps++;
					_animatorQuake.speed = 1;
					_sfx2.Play();
					
				}
			}
		}
	}

	IEnumerator countdown()
	{
		while (time >0 && (myState != stateGame13.Lose || myState != stateGame13.Win))
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
		}
	}
	//Funciones para  botones de la UI
	public void InPause(){
		_playerPrefs.SoundPauseApply (true);
		_sfx.Pause ();
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);
	}
	public void OutPause(){
		_playerPrefs.SoundPauseApply (false);
		_sfx.UnPause ();
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;
	}
	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		myState = stateGame13.Earthquake;
		_timeDown.ActivateClock = true;
		_ParpadeoRojo.GetComponent<AlphaRed>().SetActivateAlphaRed();
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		/*if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			myState = stateGame13.Earthquake;
			_timeDown.ActivateClock = true;
			_ParpadeoRojo.GetComponent<AlphaRed>().SetActivateAlphaRed();
		
		}*/
		
	}


}
