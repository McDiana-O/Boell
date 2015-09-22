using UnityEngine;
using System.Collections;

public class GamePlay11 : MonoBehaviour {
	public float time,lowerLimit,upperLimit;
	public int numMethane=20,numGas=5;
	private int creados=0,pointID,tempCount=1,position,position2;
	private float[] posX=new float[6];
	private float[] posX2=new float[6];
	public enum stateGameMini11{Inicio,Jugando,Gano,Perdio};
	stateGameMini11 mystate;
	public GameObject[] MethaneArray;
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
	void Start () {
		mystate = stateGameMini11.Inicio;
		level=PlayerPrefs.GetInt("Nivel");
		posX [0] = -3.5f;
		posX [1] = -2.2f;
		posX [2] = -0.9f;
		posX [3] = 0.4f;
		posX [4] = 1.7f;
		posX [5] = 3.0f;
		posX2 [0] = -2.8f;
		posX2 [1] = -0.3f;
		posX2 [2] = 2.8f;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		switch (level) {
		case 1:
			numGas=5;
			lowerLimit=1.4f;
			upperLimit=4.4f;
			break;
		case 2:
			numGas=10;
			lowerLimit=1.0f;
			upperLimit=5.0f;
			break;
		case 3:
			numGas=15;
			lowerLimit=1.0f;
			upperLimit=4.0f;
			break;
		}
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		//StartCoroutine (SetElements());
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
				_timeDown.ActivateClock = false;
			}
			time -= 0.2f;
			//Debug.Log(time);
			if(time < upperLimit && time > lowerLimit){
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
			}
			yield return new WaitForSeconds(0.2f);
		}
		if (_timeDown.isTimeOver && mystate!= stateGameMini11.Perdio && mystate!= stateGameMini11.Gano) {
			mystate = stateGameMini11.Perdio;
		}
	}

	public void HideCanvasTutorial(){
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
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mystate== stateGameMini11.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
	}
}
