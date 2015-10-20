using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay02 : MonoBehaviour {

	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;

	public int[] pointID;
	public GameObject[] roads;
	public GameObject[] points;
	public int[] machines;
	public int totalMachines=0;
	public GameObject MenuWinLose;

	public enum stateGame02{Begin,CreateRoads,TouchPoints,Win,Lose};
	public stateGame02 myState;

	int total;
	private timedown _timeDown;
	//esta variable va ser  global
	public int nivel=1,numroads=2,numpoint=2;

	public int[] roadFull= new int[4];
	public bool[] IsRoadFull = new bool[4];

	public bool isTouchPoint= false;

	//esperando un segundo
	private float time=1;
	private float timeStart=0.4f;
	public bool isPausing=false;
	//Audios
	public AudioSource _audioTema;
	public AudioClip[] winloseAudio;
	public AudioSource _sfxSounds;

	public Text _txtPuntos;
	private GamePlayerPrefs _playerPrefs;
	// Use this for initialization
	void Awake(){
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
	}
	void Start () {
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		//nivel = PlayerPrefs.GetInt ("Nivel");
		nivel =_playerPrefs.NivelActual;

		myState = stateGame02.Begin;
		switch (nivel) {
		
		case 1:
			numroads=2;
			numpoint=2;
			break;
		case 2:
			numroads=3;
			numpoint=3;
			break;
		case 3:
			numroads=4;
			numpoint=5;
			break;
		}

		pointID = NumerosRandom.randomArray (4);
		for (int i=0;i<numroads;i++)
		{
			roads[pointID[i]].SetActive(true);
		}


	}
	
	// Update is called once per frame
	void Update () {
		if (!isPausing) 
		{
			if(myState==stateGame02.Begin && timeStart<=0.0f){
				myState = stateGame02.CreateRoads;
				_timeDown.ActivateClock = true;
			}
			if (myState != stateGame02.Lose && myState == stateGame02.CreateRoads && !_timeDown.isTimeOver) {
				for (int i=0,k=0; i<4; i++) {
					if (IsRoadFull [i]) {
						k++;
					}
					total = k;
				}
				if (total == numroads && myState == stateGame02.CreateRoads) {
					pointID = NumerosRandom.randomArray (9);
					for (int i=0; i<numpoint; i++) {
						points [pointID [i]].SetActive (true);
						points [pointID [i]] .GetComponent<AlphaAnimacion> ().activateAnimacion = true;
					}
					myState = stateGame02.TouchPoints;
					isTouchPoint = true;
					machines = NumerosRandom.randomArray (6);
				}
				
				//continuos
			} 
			else if (myState == stateGame02.TouchPoints && !_timeDown.isTimeOver) 
			{
				if (totalMachines == numpoint) {
					
					myState = stateGame02.Win;
					_playerPrefs.SetNewLevel();
					_txtPuntos.text = _playerPrefs.getPointsTxt ();


					_timeDown.ActivateClock=false;
					_audioTema.Stop();
					_audioTema.PlayOneShot(winloseAudio[0],0.6f);
					StartCoroutine (countdown());
					
					/*if(!couroutineStarted)
					StartCoroutine(UsingYield(1));*/
					//MenuWinLose.SetActive (true);
					//MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (ScriptMenuWinLose.tipoMensaje.Gano);
				}
			} 
			else if (_timeDown.isTimeOver && myState != stateGame02.Lose) 
			{
				myState = stateGame02.Lose;
				Debug.Log("LoseTime");
				_timeDown.ActivateClock=false;
				_audioTema.Stop();
				_audioTema.PlayOneShot(winloseAudio[1],0.6f);
				StartCoroutine (countdown());
				
			}
			if ((myState == stateGame02.Lose || myState == stateGame02.Win) && time<=0){
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(myState == stateGame02.Win ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
				
			}
		}
	}

	public void checkFullRoad(int idFather)
	{
		if (idFather == 0 || idFather == 1) {
			if (roadFull [idFather] == 8) {
				IsRoadFull [idFather] = true;
			}
			else if(roadFull[idFather]<8)
			{
				myState = stateGame02.Lose;
				//Debug.Log("Lose1");
				_timeDown.ActivateClock=false;
				_audioTema.Stop();
				_audioTema.PlayOneShot(winloseAudio[1],0.6f);
				StartCoroutine (countdown());
			}
		} 

		if (idFather == 2 || idFather == 3){
			if (roadFull [idFather] == 9) {
				IsRoadFull [idFather] = true;
			}
			else if(roadFull[idFather]<9)
			{
				//Debug.Log("Lose2");
				myState = stateGame02.Lose;
				_timeDown.ActivateClock=false;
				_audioTema.Stop();
				_audioTema.PlayOneShot(winloseAudio[1],0.6f);
				StartCoroutine (countdown());
			}
		}

	}

	IEnumerator countdown()
	{
		//timer.text = time.ToString();
		while (time >0 && (myState != stateGame02.Lose || myState != stateGame02.Win))
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
			//timer.text = time.ToString();
		}
	}
	IEnumerator counToStart()
	{
		//timer.text = time.ToString();
		while (timeStart >0 )
		{
			yield return new WaitForSeconds(0.1f);
			timeStart -= 0.1f;
			//timer.text = time.ToString();
		}
	}
	//Funciones para  botones de la UI
	public void InPause(){
		_playerPrefs.SoundPauseApply (true);
		_sfxSounds.Pause ();
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);

	}
	public void OutPause(){
		_playerPrefs.SoundPauseApply (false);
		_sfxSounds.Pause ();
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;

	}
	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		StartCoroutine (counToStart());

	}

	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		/*if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			StartCoroutine (counToStart());
		}*/
	}
}
