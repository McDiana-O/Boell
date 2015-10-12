using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego : MonoBehaviour {
	public Text timer;
	static int totalTree= 30;
	public int totalArboles;
	public enum stateGame{Inicio,BeginGame,Taladora,Aplanadora,Mezcladora,Gano,Perdio};
	public stateGame  MyStateGame;
	public GameObject carrito1;
	public GameObject carrito2;
	public GameObject carrito3;
	private Animator animCarrito1;
	private Animator animCarrito2;
	private Animator animCarrito3;
	public GameObject[] Audios;

	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public GameObject MenuWinLose;
	public Text _txtPuntos;
	private timedown _timeDown;
	public int[] timeLelvel;
	public int nivel=1;

	//
	//esperando un segundo
	private float time=1;
	//Audios
	public AudioSource _audioTema;
	public AudioClip[] winloseAudio;
	/// <summary>
	/// Pause	/// </summary>
	public bool isPausing=false;

	private GamePlayerPrefs _playerPrefs;

	// Use this for initialization
	void Awake(){
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
	}
	void Start () {
		MyStateGame = stateGame.Inicio;


		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown>();
		//nivel = PlayerPrefs.GetInt ("Nivel");
		nivel =_playerPrefs.NivelActual;
		_timeDown.waitTime = timeLelvel [nivel - 1];
		//time = timeLelvel [nivel - 1];
		totalArboles = totalTree;
		animCarrito1 = carrito1.GetComponent<Animator>();
		animCarrito2 = carrito2.GetComponent<Animator>();
		animCarrito3 = carrito3.GetComponent<Animator>();

		animCarrito1.speed = 1;
		animCarrito2.speed = 0;
		animCarrito3.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (!isPausing) {
			if (MyStateGame.Equals(stateGame.BeginGame)){
				_timeDown.ActivateClock=true;
				MyStateGame= stateGame.Taladora;
				Audios[0].GetComponent<AudioSource>().Play();
			}
			if (_timeDown.isTimeOver && MyStateGame!=stateGame.Perdio) {
				Audios[0].GetComponent<AudioSource>().Stop();
				Audios[1].GetComponent<AudioSource>().Stop();
				Audios[2].GetComponent<AudioSource>().Stop();
				MyStateGame = stateGame.Perdio;
				_audioTema.Stop();
				_audioTema.PlayOneShot(winloseAudio[1],0.6f);
				StartCoroutine (countdown());
				_timeDown.ActivateClock=false;
				//timer.text = "you lost!!!";
				//MenuWinLose.SetActive(true);
				//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
			}
			else if (MyStateGame.Equals (stateGame.Taladora) && totalArboles<=0) {
				Audios[0].GetComponent<AudioSource>().Stop();
				Audios[1].GetComponent<AudioSource>().Play();
				totalArboles=totalTree;
				animCarrito1.speed = 0;
				animCarrito2.speed = 1;
				animCarrito3.speed = 0;
				//animCarrito.SetBool("estaAplanando",true);
				MyStateGame= stateGame.Aplanadora;
			}
			else if (MyStateGame.Equals (stateGame.Aplanadora) && totalArboles<=0) {
				Audios[1].GetComponent<AudioSource>().Stop();
				Audios[2].GetComponent<AudioSource>().Play();
				totalArboles=totalTree;
				animCarrito1.speed = 0;
				animCarrito2.speed = 0;
				animCarrito3.speed = 1;
				//animCarrito.SetBool("estaCementado",true);
				MyStateGame= stateGame.Mezcladora;
			}
			else if (MyStateGame.Equals (stateGame.Mezcladora) && totalArboles<=0) {;
				MyStateGame= stateGame.Gano;

				_playerPrefs.SetNewLevel();
				_txtPuntos.text =_playerPrefs.getPointsTxt();

				Audios[2].GetComponent<AudioSource>().Stop();
				_timeDown.ActivateClock=false;
				_audioTema.Stop();
				_audioTema.PlayOneShot(winloseAudio[0],0.6f);
				StartCoroutine (countdown());
				//			timer.text = "you win!!!";
				//MenuWinLose.SetActive(true);
				//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
				animCarrito1.speed = 0;
				animCarrito2.speed = 0;
				animCarrito3.speed = 0;
			}
			if ((MyStateGame == stateGame.Perdio || MyStateGame == stateGame.Gano) && time<=0) {
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(MyStateGame == stateGame.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
				
			}
		}


	}
	IEnumerator countdown()
	{
		//timer.text = time.ToString();
		while (time >0 && (MyStateGame != stateGame.Perdio || MyStateGame != stateGame.Gano))
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
			//timer.text = time.ToString();
		}
	}
	//Funciones para  botones de la UI
	public void InPause(){
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);
		Audios[0].GetComponent<AudioSource>().Pause ();
		Audios[1].GetComponent<AudioSource>().Pause ();
		Audios[2].GetComponent<AudioSource>().Pause ();

	}
	public void OutPause(){
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;
		Audios[0].GetComponent<AudioSource>().UnPause ();
		Audios[1].GetComponent<AudioSource>().UnPause ();
		Audios[2].GetComponent<AudioSource>().UnPause ();

	}
	public void hideCards(){
		TarjestasInformativas.SetActive (false);
		/*if(_playerPrefs.Tutos[_playerPrefs.MiniGameActual-1]== 1){
			CanvasTutorial.SetActive (false);
			MyStateGame = stateGame.BeginGame;
		}*/
	} 
	public void HideTutorial(){
		CanvasTutorial.SetActive (false);
		MyStateGame = stateGame.BeginGame;

		_playerPrefs.seveTutorial ();
	} 
}
