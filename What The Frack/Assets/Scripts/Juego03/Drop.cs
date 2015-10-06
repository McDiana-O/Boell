using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {
	public int idDropping;
	private GameObject tempPileton;
	private ScripPileton scriptPileton;
	public GameObject Gameplay3;
	private AlmaJuego3 scriptGameplay;
	public AudioSource _sfx;
	// Use this for initialization
	void Start () {
		scriptGameplay = Gameplay3.GetComponent<AlmaJuego3> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D coll) {
		tempPileton=coll.gameObject;
		scriptPileton =tempPileton.GetComponent<ScripPileton>();

		if (coll.gameObject.name == "Pileton1" && scriptPileton.idPileton== this.idDropping) {
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			_sfx.Play();
			scriptGameplay.lessPiletones();
			coll.gameObject.GetComponent<BoxCollider2D>().enabled=false;
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			tempPileton.transform.position= this.transform.position;
		}
		else if (coll.gameObject.name == "Pileton2" && scriptPileton.idPileton== this.idDropping) {
			_sfx.Play();
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptGameplay.lessPiletones();
			coll.gameObject.GetComponent<BoxCollider2D>().enabled=false;
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			tempPileton.transform.position= this.transform.position;
			
		}
		else if (coll.gameObject.name == "Pileton3" && scriptPileton.idPileton== this.idDropping) {
			_sfx.Play();
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptGameplay.lessPiletones();
			coll.gameObject.GetComponent<BoxCollider2D>().enabled=false;
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			tempPileton.transform.position= this.transform.position;
			
		}
		else if (coll.gameObject.name == "Pileton4" && scriptPileton.idPileton== this.idDropping) {
			_sfx.Play();
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptGameplay.lessPiletones();
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			coll.gameObject.GetComponent<BoxCollider2D>().enabled=false;
			tempPileton.transform.position= this.transform.position;
		}
		else if (coll.gameObject.name == "Pileton5" && scriptPileton.idPileton== this.idDropping) {
			_sfx.Play();
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptGameplay.lessPiletones();
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			coll.gameObject.GetComponent<BoxCollider2D>().enabled=false;
			tempPileton.transform.position= this.transform.position;
			
		}
		else if (coll.gameObject.name == "Pileton6" && scriptPileton.idPileton== this.idDropping) {
			_sfx.Play();
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptGameplay.lessPiletones();
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			coll.gameObject.GetComponent<BoxCollider2D>().enabled=false;
			tempPileton.transform.position= this.transform.position;
			
		}

	}
	/*
	void OnCollisionEnter2D(Collision2D coll) {
		tempPileton=coll.gameObject;
		scriptPileton =tempPileton.GetComponent<ScripPileton>();

		if (coll.gameObject.name == "Pileton1" && scriptPileton.idPileton== this.idDropping) {
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			tempPileton.transform.position= this.transform.position;
		}
		else if (coll.gameObject.name == "Pileton2" && scriptPileton.idPileton== this.idDropping) {
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			tempPileton.transform.position= this.transform.position;
			
		}
		else if (coll.gameObject.name == "Pileton3" && scriptPileton.idPileton== this.idDropping) {
			//tempPileton.GetComponent<BoxCollider2D>().enabled=false;
			scriptPileton.mystate=ScripPileton.statePileton.drop;
			tempPileton.transform.position= this.transform.position;
			
		}
	}
	*/
}
