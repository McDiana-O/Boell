using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay11 : MonoBehaviour {
	public float time,lowerLimit,upperLimit;
	public int numMethane=20,numGas=5;
	private int creados=0,pointID,position,position2,positionY;
	private float[] posX=new float[6];
	private float[] posX2=new float[6];
	private float[] posY=new float[6];
	public enum stateGameMini11{Pausa,Inicio,Jugando,Gano,Perdio};
	public stateGameMini11 mystate;
	public GameObject[] MethaneArray;
	public GameObject[] GasArray;
	public GameObject MenuWinLose;
	public GameObject Gas;
	private GameObject tempObj;
	public AudioSource audioClipMain;
	public AudioSource audioWin;
	public AudioSource audioLose;
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;

	private timedown _timeDown;
	//esta variable va ser  global
	public int level=1;
	// Use this for initialization
	public GamePlayerPrefs _playerPrefs;
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
		//nivel = _playerPrefs.NivelActual;
		mystate = stateGameMini11.Pausa;
		level= _playerPrefs.NivelActual;
		posX [0] = -3.0f;
		posX [1] = -2.1f;
		posX [2] = -0.8f;
		posX [3] = 0.5f;
		posX [4] = 1.8f;
		posX [5] = 3.1f;
		posX2 [0] = -2.8f;
		posX2 [1] = -0.3f;
		posX2 [2] = 2.8f;
		posY [1] = -8f;
		posY [2] = -2.0f;
		posY [3] = 4.0f;
		posY [4] = 10.0f;
		posY [5] = 16.0f;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		switch (level) {
		case 1:
			numGas=10;
			lowerLimit=1.4f;
			upperLimit=4.4f;
			break;
		case 2:
			numGas=15;
			lowerLimit=1.0f;
			upperLimit=5.0f;
			break;
		case 3:
			numGas=20;
			lowerLimit=1.0f;
			upperLimit=4.0f;
			break;
		}
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		//StartCoroutine (SetElements());
		for (int index=0; index<10; index++) {
			pointID = Random.Range (0, 3);
			position = Random.Range (0, 6);
			positionY = Random.Range (0, 5);
			Instantiate (GasArray [pointID], new Vector3 (posX [position], posY [positionY], 0.0f), Quaternion.identity);
			creados++;
			//Debug.Log(creados);
			pointID = Random.Range (0, 4);
			position2 = Random.Range (0, 3);
			positionY = Random.Range (0, 5);
			Instantiate (MethaneArray [pointID], new Vector3 (posX2 [position2], posY [positionY], 0.0f), Quaternion.identity);
		}
		StartCoroutine (SetElements2());
	}
	
	// Update is called once per frame
	void Update () {
	
	} 
	IEnumerator SetElements()
	{
		_timeDown.ActivateClock = true;
		while (!_timeDown.isTimeOver)
		{
			if (numGas<=0 && mystate!= stateGameMini11.Perdio && mystate!= stateGameMini11.Gano) {
				mystate = stateGameMini11.Gano;
				_playerPrefs.SetNewLevel();
				_txtPuntos.text = _playerPrefs.getPointsTxt ();
				_timeDown.ActivateClock = false;
			}
			time -= 0.2f;
			//Debug.Log(time);
			/*if(time < upperLimit && time > lowerLimit){
				if(tempCount==(4-level))
				{
					position = Random.Range(0,6);
					Instantiate(Gas,new Vector3(posX[position],-14.0f,0.0f),Quaternion.identity);
					tempCount=1;
					creados++;
					//Debug.Log(creados);
				}
				else tempCount++;
				pointID = Random.Range(0,4);
				position2 = Random.Range(0,3);
				if(tempCount<3)
					Instantiate(MethaneArray[pointID],new Vector3(posX2[position2],-14.0f,0.0f),Quaternion.identity);
			}*/
			yield return new WaitForSeconds(0.2f);
		}
		if (_timeDown.isTimeOver && mystate!= stateGameMini11.Perdio && mystate!= stateGameMini11.Gano) {
			mystate = stateGameMini11.Perdio;
		}
	}

	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		_timeDown.ActivateClock = true;
		StartCoroutine (SetElements());
		StartCoroutine (SetWinLose());
		mystate = stateGameMini11.Jugando;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
	}

	IEnumerator SetWinLose()
	{
		while (mystate!= stateGameMini11.Perdio && mystate!= stateGameMini11.Gano) {
			yield return new WaitForSeconds(0.5f);
		}
		audioClipMain.Stop();
		if(mystate == stateGameMini11.Gano)
			audioWin.Play ();
		else
			audioLose.Play ();
		yield return new WaitForSeconds(1);
		MenuWinLose.SetActive (true);
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mystate==stateGameMini11.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.PerdioFrackit);
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
	IEnumerator SetElements2(){
		while (!_timeDown.isTimeOver) {
			pointID = Random.Range (0, 3);
			position = Random.Range (0, 6);
			Instantiate (GasArray [pointID], new Vector3 (posX [position], -14.0f, 0.0f), Quaternion.identity);
			creados++;
			//Debug.Log(creados);
			pointID = Random.Range (0, 4);
			position2 = Random.Range (0, 3);
			Instantiate (MethaneArray [pointID], new Vector3 (posX2 [position2], -14.0f, 0.0f), Quaternion.identity);
			yield return new WaitForSeconds (0.3f);
		}
	}
}
