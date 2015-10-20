using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class GamePlayTen : MonoBehaviour {
	//public int time;
	public Button button;
	public Image agua;

	private float tempPulsos;
	public enum stateGameMini10{Inicio,Pulsando,Gano,Perdio};
	stateGameMini10 mysate;

	public GameObject MenuWinLose;


	private timedown _timeDown;
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public GameObject Bomba;
	private Animator _animBomba;
	public GameObject Aguagrietas;
	private Animator _animAguaGrietas;
	public float[] tapSecond;
	public int nivel=1;
	//SFX audios

	public AudioSource SFX_Audio;
	public bool isPausing=false;
	//esperando un segundo
	private float time=1;
	
	//Audios
	public AudioSource _audioTema;
	public AudioClip[] winloseAudio;
	// Use this for initialization
	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
		nivel = _playerPrefs.NivelActual;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown>();
		//_timeDown.waitTime = (float)time;
		_animBomba = Bomba.GetComponent<Animator> ();
		_animAguaGrietas = Aguagrietas.GetComponent<Animator> ();
		_animBomba.speed = 0;
		_animAguaGrietas.speed = 0;
		mysate = stateGameMini10.Inicio;
		button.interactable = false; 
	}

	void FixedUpdate(){
		if (!isPausing) {
			if (agua.fillAmount == 0 &&mysate != stateGameMini10.Gano) 
			{
				mysate = stateGameMini10.Gano;
				_playerPrefs.SetNewLevel();
				_txtPuntos.text = _playerPrefs.getPointsTxt ();

				button.interactable = false; 
				button.enabled=false;
				//MenuWinLose.SetActive(true);
				_timeDown.ActivateClock=false;
				_audioTema.Stop();
				SFX_Audio.Stop();
				_animBomba.speed=0;
				_animAguaGrietas.speed = 0;
				_audioTema.PlayOneShot(winloseAudio[0],0.6f);
				StartCoroutine (countdown());
				//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
			} 
			else if (_timeDown.isTimeOver && mysate != stateGameMini10.Perdio )
			{
				_timeDown.ActivateClock=false;
				mysate = stateGameMini10.Perdio;
				button.enabled=false;
				_audioTema.Stop();
				SFX_Audio.Stop();
				_animBomba.speed=0;
				_animAguaGrietas.speed = 0;
				_audioTema.PlayOneShot(winloseAudio[1],0.6f);
				StartCoroutine (countdown());
				
				//MenuWinLose.SetActive(true);
				//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
			}
			
			if ((mysate == stateGameMini10.Gano ||mysate ==  stateGameMini10.Perdio) && time<=0) {
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(mysate == stateGameMini10.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
				
			}
		}

	}

	public void CuentaPulsadas(){
		if (!isPausing) {
			if (!SFX_Audio.isPlaying) {
				SFX_Audio.Play();
			}
			if (agua.fillAmount > 0 && (mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano)) {
				mysate = stateGameMini10.Pulsando;
				_animBomba.speed=1;
				_animAguaGrietas.speed = 1;
				//recTransformAgua.localScale = new Vector3(1,recTransformAgua.localScale.y-0.05f,1);
				//tempPulsos = (recTransformAgua.localScale.y *100)/2;
				agua.fillAmount -= tapSecond[nivel-1];
			} 
		}

	}
	IEnumerator countdown()
	{
		//timer.text = time.ToString();
		while (time >0 && (mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano))
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
			//timer.text = time.ToString();
		}
	}
	//Funciones para  botones de la UI
	public void InPause(){
		_playerPrefs.SoundPauseApply (true);
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);
		SFX_Audio.Pause ();
	}
	public void OutPause(){
		_playerPrefs.SoundPauseApply (false);
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;
		SFX_Audio.UnPause();
	}
	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		_timeDown.ActivateClock = true;
		button.interactable = true; 
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		/*if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			_timeDown.ActivateClock = true;
			button.interactable = true; 
		}*/
	}
		

	
}
