using UnityEngine;
using System.Collections;

public class GamePlay11 : MonoBehaviour {
	public float time,lowerLimit,upperLimit;
	private int creados=0,pointID,tempCount=1,position,position2,numMethane=5,numGas=20,createdMethane=0,createdGas=0;
	private float[] posX=new float[6];
	private float[] posX2=new float[6];
	public GameObject[] MethaneArray;
	public GameObject MenuWinLose;
	public GameObject Gas;
	private GameObject tempObj;
	bool win;
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	private bool BeginGame=false;

	private timedown _timeDown;
	//esta variable va ser  global
	public int level=1;
	// Use this for initialization
	void Start () {
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
		win = false;
		switch (level) {
		case 1:
			numMethane=5;
			lowerLimit=1.4f;
			upperLimit=4.4f;
			break;
		case 2:
			numMethane=10;
			lowerLimit=1.0f;
			upperLimit=5.0f;
			break;
		case 3:
			numMethane=15;
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
			time -= 0.2f;
			//Debug.Log(time);
			if(time < upperLimit && time > lowerLimit){
				if(tempCount==(4-level))
				{
					pointID = Random.Range(0,4);
					position2 = Random.Range(0,3);
					Instantiate(MethaneArray[pointID],new Vector3(posX2[position2],-14.0f,0.0f),Quaternion.identity);
					tempCount=1;
					creados++;
					//Debug.Log(creados);
				}
				else tempCount++;
				position = Random.Range(0,6);
				if(tempCount<3)
					Instantiate(Gas,new Vector3(posX[position],-14.0f,0.0f),Quaternion.identity);
			}
			yield return new WaitForSeconds(0.2f);
		}
		if (time <= 0) {
			//MyStateGame = stateGame.Perdio;
			//timer.text = "you lost!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}

	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		_timeDown.ActivateClock = true;
		StartCoroutine (SetElements());
		BeginGame = true;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
	}
}
