using UnityEngine;
using System.Collections;

public class CisternaComportamiento : MonoBehaviour {
	public enum stateCamion{Idle,Inactivo,Andando,Vacio,Error};
	public stateCamion myState;
	private int camionEstado=0;
	public float xMov=0,yMov=0;
	private Animator anim;
	private GamePlay12 _gameplay;
	// Use this for initialization
	void Start () {
		myState = stateCamion.Idle;
		anim = this.gameObject.GetComponent<Animator> ();
		anim.SetInteger ("Estado",camionEstado);
		_gameplay = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<GamePlay12> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (myState == stateCamion.Inactivo && camionEstado == 0) {
			camionEstado=1;
			anim.SetInteger ("Estado", camionEstado);
		}
		if (myState == stateCamion.Andando) {
			if(camionEstado == 1){
				camionEstado=2;
				anim.SetInteger ("Estado", camionEstado);
			}
			else if(camionEstado == 2){
				this.gameObject.transform.Translate(xMov,yMov,0.0f);
			}
		}
		if (myState == stateCamion.Vacio && camionEstado == 2) {
			camionEstado=3;
			anim.SetInteger ("Estado", camionEstado);
		}
		if (myState == stateCamion.Error && camionEstado == 2) {
			camionEstado=4;
			anim.SetInteger ("Estado", camionEstado);
		}
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (myState == stateCamion.Andando && camionEstado == 2 && (coll.gameObject.tag == "crack"||coll.gameObject.tag == "Nocivos")) {
			if (coll.gameObject.tag == "crack") {
				myState = stateCamion.Vacio;
				_gameplay.correctos++;
			} else {
				myState = stateCamion.Error;
			}
			_gameplay.movidos++;
		}
	}

}
