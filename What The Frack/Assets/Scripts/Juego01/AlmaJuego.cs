using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego : MonoBehaviour {
	public int time;
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
	private timedown _timeDown;
	// Use this for initialization
	void Start () {
		MyStateGame = stateGame.Inicio;

		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown>();

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
		if (MyStateGame.Equals(stateGame.BeginGame)){
			StartCoroutine (countdown());
			_timeDown.ActivateClock=true;
			MyStateGame= stateGame.Taladora;
			Audios[0].GetComponent<AudioSource>().Play();
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
			Audios[2].GetComponent<AudioSource>().Stop();
//			timer.text = "you win!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
			animCarrito1.speed = 0;
			animCarrito2.speed = 0;
			animCarrito3.speed = 0;
		}
		else if(time <= 0){
			Audios[0].GetComponent<AudioSource>().Stop();
			Audios[1].GetComponent<AudioSource>().Stop();
			Audios[2].GetComponent<AudioSource>().Stop();
			MyStateGame = stateGame.Perdio;
			//timer.text = "you lost!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}


	IEnumerator countdown()
	{
		while (time > 0 && MyStateGame!=stateGame.Gano)
		{
			//timer.text = time.ToString();
			time -= 1;
			yield return new WaitForSeconds(1);
		}

	}

	public void hideCards(){
		TarjestasInformativas.SetActive (false);
	} 
	public void HideTutorial(){

		CanvasTutorial.SetActive (false);
		MyStateGame = stateGame.BeginGame;
	} 
}
