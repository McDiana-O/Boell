using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class AlmaJuego : MonoBehaviour {
	public int time;
	public Text timer;
	static int totalTree= 49;
	public int totalArboles;
	public enum stateGame{Taladora,Aplanadora,Mezcladora,Gano,Perdio};
	public stateGame  MyStateGame;
	public GameObject carrito;
	private Animator animCarrito;

	public GameObject MenuWinLose;
	// Use this for initialization
	void Start () {
		MyStateGame = stateGame.Taladora;
		StartCoroutine (countdown());
		totalArboles = totalTree;
		animCarrito = carrito.GetComponent<Animator>();

	}
	
	// Update is called once per frame
	void Update () {
		if (MyStateGame.Equals (stateGame.Taladora) && totalArboles<=0) {
			totalArboles=totalTree;
			animCarrito.SetBool("estaAplanando",true);
			MyStateGame= stateGame.Aplanadora;
		}
		else if (MyStateGame.Equals (stateGame.Aplanadora) && totalArboles<=0) {
			totalArboles=totalTree;
			animCarrito.SetBool("estaCementado",true);
			MyStateGame= stateGame.Mezcladora;
		}
		else if (MyStateGame.Equals (stateGame.Mezcladora) && totalArboles<=0) {;
			MyStateGame= stateGame.Gano;
			timer.text = "you win!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);
		}
		else if(MyStateGame.Equals (stateGame.Perdio)){
			timer.text = "you lost!!!";
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}


	}


	IEnumerator countdown()
	{
		while (time > 0 && MyStateGame!=stateGame.Gano)
		{
			timer.text = time.ToString();
			time -= 1;
			yield return new WaitForSeconds(1);
		}
		if (time <= 0) {
			MyStateGame = stateGame.Perdio;
		}
	}
}
