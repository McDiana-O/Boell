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

	public float[] tapSecond;
	public int nivel=1;

	//esperando un segundo
	private float time=1;
	
	//Audios
	public AudioSource _audioTema;
	public AudioClip[] winloseAudio;
	// Use this for initialization
	void Start () {
		nivel = PlayerPrefs.GetInt ("Nivel");
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown>();
		//_timeDown.waitTime = (float)time;
		_animBomba = Bomba.GetComponent<Animator> ();
		_animBomba.speed=0;
		mysate = stateGameMini10.Inicio;
		button.interactable = false; 
	}

	void FixedUpdate(){
		if (agua.fillAmount == 0 &&( mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano)) 
		{
			mysate = stateGameMini10.Gano;
			button.interactable = false; 
			//MenuWinLose.SetActive(true);
			_timeDown.ActivateClock=false;
			_audioTema.Stop();
			_audioTema.PlayOneShot(winloseAudio[0],0.6f);
			StartCoroutine (countdown());
			//MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		} 
		else if (_timeDown.isTimeOver && ( mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano))
		{
			_timeDown.ActivateClock=false;
			mysate = stateGameMini10.Perdio;
			_audioTema.Stop();
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

	public void CuentaPulsadas(){

		if (agua.fillAmount > 0 && (mysate != stateGameMini10.Perdio || mysate != stateGameMini10.Gano)) {
			mysate = stateGameMini10.Pulsando;
			_animBomba.speed=1;
			//recTransformAgua.localScale = new Vector3(1,recTransformAgua.localScale.y-0.05f,1);
			//tempPulsos = (recTransformAgua.localScale.y *100)/2;
			agua.fillAmount -= tapSecond[nivel-1];
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
	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		_timeDown.ActivateClock = true;
		button.interactable = true; 
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		
	}
	
}
