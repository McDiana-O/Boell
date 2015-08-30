using UnityEngine;
using System.Collections;

public class FirstCard : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	public void gotoLevel (string Level) {
		Application.LoadLevel (Level);
	
	}
}
