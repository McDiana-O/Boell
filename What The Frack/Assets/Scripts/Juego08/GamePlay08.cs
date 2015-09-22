using UnityEngine;
using System.Collections;

public class GamePlay08 : MonoBehaviour {
	public enum stateGameMini08{Inicio,Iniciando,Jugando,Gano,Perdio};
	public stateGameMini08 mystate;
	public int level;
	public WaterAnimacion _fondo;
	public float divisorVelPerfo=60f;
	public float divisorVelLinea=19f;
	private timedown _timeDown;
	public float time=2,velocidadFondo;
	public GameObject MenuWinLose;
	public GameObject TarjetasInformativas; 
	public GameObject CanvasTutorial;
	public AudioSource audioPerforacion;
	public AudioSource audioClipMain;
	public AudioSource audioWin;
	public AudioSource audioLose;
	// Use this for initialization
	void Start () {
		_fondo = GameObject.FindGameObjectWithTag ("Fondo").GetComponent<WaterAnimacion> ();
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		mystate = stateGameMini08.Inicio;
		level = PlayerPrefs.GetInt("Nivel");
		//level = 3;
		_fondo.scrollSpeed=0.0f;
		switch (level) {
		case 1:
			//_fondo.scrollSpeed=0.1f;
			velocidadFondo=0.1f;
			divisorVelPerfo=60f;
			divisorVelLinea=19f;
			time = 12.0f;
			break;
		case 2:
			//_fondo.scrollSpeed=0.15f;
			velocidadFondo=0.15f;
			divisorVelPerfo=45f;
			divisorVelLinea=13.75f;
			time = 9.0f;
			break;
		case 3:
			//_fondo.scrollSpeed=0.2f;
			velocidadFondo=0.2f;
			divisorVelPerfo=30f;
			divisorVelLinea=8.5f;
			time = 6.0f;
			break;
		}
		StartCoroutine (SetWinLose ());
		//_timeDown.waitTime = time;
		//_timeDown.ActivateClock = true;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	IEnumerator SetWinLose()
	{
		while (mystate!= stateGameMini08.Perdio && mystate!= stateGameMini08.Gano) {
			yield return new WaitForSeconds(0.7f);
		}
		_timeDown.ActivateClock = false;
		audioClipMain.Stop();
		audioPerforacion.Stop();
		_fondo.scrollSpeed = 0.0f;
		if(mystate == stateGameMini08.Gano)
			audioWin.Play ();
		else
			audioLose.Play ();
		yield return new WaitForSeconds(1);
		MenuWinLose.SetActive (true);
		MenuWinLose.GetComponent<ScriptMenuWinLose> ().SetMenssageWinorLose (mystate== stateGameMini08.Gano ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
	}
	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		_timeDown.waitTime = time;
		_timeDown.ActivateClock = true;
		_fondo.scrollSpeed = velocidadFondo;
		audioPerforacion.Play();
		mystate = stateGameMini08.Iniciando;
	}
	
	public void HideTarjetaInformativa(){
		TarjetasInformativas.SetActive (false);
	}
}
