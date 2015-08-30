using UnityEngine;
using System.Collections;

public class StopPerforacion : MonoBehaviour {
	public bool isTouchPoint=false;
	// Use this for initialization
	void Start () {
		
	}

	void OnCollisionEnter2D(Collision2D coll) {
		if (coll.gameObject.name == "PuntoObjetivo") {
			isTouchPoint=true;
			Destroy(coll.gameObject);
		}
	}
}
