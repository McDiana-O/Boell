using UnityEngine;
using System.Collections;

public class GamePlay12 : MonoBehaviour {
	private float[] CarrY=new float[6];
	private float[] DestY=new float[6];
	public GameObject[] CarrType=new GameObject[2];
	public GameObject[] PlantaType=new GameObject[2];
	public GameObject[] CiudadType=new GameObject[2];
	private bool inicia=true;
	Touch myTouch;
	public GameObject MenuWinLose;
	public GameObject TarjetasInformativas; 
	public GameObject CanvasTutorial;
	public GameObject coche,destino;
	public CamionComportamiento cocheComportamiento;
	public CisternaComportamiento cisternaComportamiento;
	public ciudadComportamiento destinoComportamiento;
	private int tapCount;
	int[] arrRand,arrRand2;
	public int correctos=0;
	public int total=0,movidos=0;
	private int level=0;
	private timedown _timeDown;
	public enum stateGameMini12{Inicio,Iniciando,Jugando,Gano,Perdio};
	public stateGameMini12 mystate;
	public AudioSource audioClipMain;
	public AudioSource audioWin;
	public AudioSource audioLose;
	// Use this for initialization
	void Start () {
		inicia = true;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		arrRand=NumerosRandom.randomArray(6);
		arrRand2=NumerosRandom.randomArray(6);
		mystate = stateGameMini12.Inicio;
		level = PlayerPrefs.GetInt("Nivel");
		switch (level) {
		case 1:
			total=2;
			break;
		case 2:
			total=4;
			break;
		case 3:
			total=6;
			break;
		}
		CarrY[0]= 8.47f;
		CarrY[1]= 4.87f;
		CarrY[2]= 1.27f;
		CarrY[3]= -2.33f;
		CarrY[4]= -5.93f;
		CarrY[5]= -9.53f;
		DestY[0]= 8.8f;
		DestY[1]= 5.2f;
		DestY[2]= 1.6f;
		DestY[3]= -2f;
		DestY[4]= -5.6f;
		DestY[5]= -9.2f;
		if (total == 2) {
			Instantiate (CarrType [0], new Vector3 (-4.6f, CarrY[arrRand[0]], 0.0f), Quaternion.identity);
			Instantiate (CarrType [1], new Vector3 (-4.6f, CarrY[arrRand[1]], 0.0f), Quaternion.identity);
			Instantiate (PlantaType [0], new Vector3 (4.64f, DestY[arrRand2[0]], 0.0f), Quaternion.identity);
			Instantiate (CiudadType [1], new Vector3 (4.64f, DestY[arrRand2[1]], 0.0f), Quaternion.identity);
		} else {
			Instantiate (CarrType [0], new Vector3 (-4.6f, CarrY[arrRand[0]], 0.0f), Quaternion.identity);
			Instantiate (CarrType [1], new Vector3 (-4.6f, CarrY[arrRand[1]], 0.0f), Quaternion.identity);
			Instantiate (PlantaType [0], new Vector3 (4.64f, DestY[arrRand2[0]], 0.0f), Quaternion.identity);
			Instantiate (CiudadType [1], new Vector3 (4.64f, DestY[arrRand2[1]], 0.0f), Quaternion.identity);
			for (int i=2; i<total; i++) {
				int tipo=Random.Range(0,2);
				Instantiate(CarrType[tipo],new Vector3(-4.6f, CarrY[arrRand[i]], 0.0f),Quaternion.identity);
				if(tipo==0)
					Instantiate (PlantaType [0], new Vector3 (4.64f, DestY[arrRand2[i]], 0.0f), Quaternion.identity);
				else
					Instantiate (CiudadType [0], new Vector3 (4.64f, DestY[arrRand2[i]], 0.0f), Quaternion.identity);
			}
		}
		StartCoroutine (SetWinLose ());
	}
	
	// Update is called once per frame
	void Update () {
		if(mystate == stateGameMini12.Jugando){
			if(movidos==total){
				if(movidos==correctos){
					mystate = stateGameMini12.Gano;
				}
				else{
					mystate = stateGameMini12.Perdio;
				}
			}
			else{
				if(_timeDown.isTimeOver){
					mystate = stateGameMini12.Perdio;
				}
				else{
					#if UNITY_ANDROID
					if(Input.touchCount>0){
						myTouch = Input.GetTouch(0);
						if( myTouch.phase == TouchPhase.Began || myTouch.phase == TouchPhase.Moved || myTouch.phase == TouchPhase.Stationary){
							RaycastHit2D hitInfo=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(myTouch.position),Vector2.zero);
							if(hitInfo){
								if ((hitInfo.transform.gameObject.tag=="Carro"||hitInfo.transform.gameObject.tag=="Carro2") && inicia){
									coche  = hitInfo.transform.gameObject;
									if(coche.tag=="Carro"){
										cocheComportamiento = coche.GetComponent<CamionComportamiento>();
										//Debug.Log(cocheComportamiento.myState);
										if(cocheComportamiento.myState==CamionComportamiento.stateCamion.Idle){
											cocheComportamiento.myState=CamionComportamiento.stateCamion.Inactivo;
											inicia=false;
										}
									}
									else{
										cisternaComportamiento = coche.GetComponent<CisternaComportamiento>();
										//Debug.Log(cisternaComportamiento.myState);
										if(cisternaComportamiento.myState==CisternaComportamiento.stateCamion.Idle){
											cisternaComportamiento.myState=CisternaComportamiento.stateCamion.Inactivo;
											inicia=false;
										}
									}
								}else if((hitInfo.transform.gameObject.tag=="crack" || hitInfo.transform.gameObject.tag=="Nocivos")&& !inicia){
									destino=hitInfo.transform.gameObject;
									destinoComportamiento=destino.GetComponent<ciudadComportamiento>();
									if(!destinoComportamiento.ocupado){
										if(coche.tag=="Carro"){
											cocheComportamiento.xMov=0.01f*(destino.transform.position.x-1.7f-coche.transform.position.x);
											cocheComportamiento.yMov=0.01f*(destino.transform.position.y-coche.transform.position.y);
											cocheComportamiento.myState=CamionComportamiento.stateCamion.Andando;
											inicia=true;
											destinoComportamiento.ocupado=true;
										}else{
											cisternaComportamiento.xMov=0.01f*(destino.transform.position.x-1.7f-coche.transform.position.x);
											cisternaComportamiento.yMov=0.01f*(destino.transform.position.y-coche.transform.position.y);
											cisternaComportamiento.myState=CisternaComportamiento.stateCamion.Andando;
											inicia=true;
											destinoComportamiento.ocupado=true;
										}
									}
								}
							}
						}
					}
				#endif
				}
			}
		}
	}
	IEnumerator SetWinLose()
	{
		while (mystate!= stateGameMini12.Perdio && mystate!= stateGameMini12.Gano) {
			yield return new WaitForSeconds(0.7f);
		}
		_timeDown.ActivateClock = false;
		audioClipMain.Stop();
		if(mystate == stateGameMini12.Gano)
			audioWin.Play ();
		else
			audioLose.Play ();
		yield return new WaitForSeconds(1);
		MenuWinLose.SetActive (true);
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mystate== stateGameMini12.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
	}
	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		_timeDown.waitTime = 12.0f;
		_timeDown.ActivateClock = true;
		mystate = stateGameMini12.Jugando;
	}
	
	public void HideTarjetaInformativa(){
		TarjetasInformativas.SetActive (false);
	}
}
