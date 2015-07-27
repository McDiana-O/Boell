using UnityEngine;
using System.Collections;

public class ScripPileton : MonoBehaviour {

	public int idPileton=0;
	public enum statePileton{drag,drop};
	public statePileton mystate;
	// Use this for initialization
	void Start () {
		mystate=statePileton.drag;
	}
	
	// Update is called once per frame
	void Update () {

	}
}
