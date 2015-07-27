using UnityEngine;
using System.Collections;

public class Drop : MonoBehaviour {
	public int idDropping;
	private GameObject tempPileton;
	private ScripPileton scriptPileton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnTriggerEnter2D(Collider2D coll) {
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
