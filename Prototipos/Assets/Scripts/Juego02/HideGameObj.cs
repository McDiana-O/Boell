using UnityEngine;
using System.Collections;

public class HideGameObj : MonoBehaviour {
	public GameObject[] gamesObjects;
	// Use this for initialization
	void Start () {
		foreach(GameObject gamesObj in  gamesObjects)
		{
			gamesObj.SetActive(false);
		}
	}


	void hidegameobject(int id,bool activate){
		gamesObjects [id].SetActive(activate);
		gamesObjects [id].GetComponent<AlphaAnimacion> ().activateAnimacion = activate;
	}
}
