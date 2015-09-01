using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour {
	float contador=3;
	public GameObject imgCargando;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{	 
			Application.Quit(); 
		}

	}

	public void GotoWorld(string level){
		imgCargando.SetActive (true);
		Application.LoadLevel(level);
	}
}
