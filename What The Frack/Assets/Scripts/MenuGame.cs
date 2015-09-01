using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour {
	float contador=3;
	public GameObject imgCargando;
	public Image imgLelvel; 
	public Sprite[] spriteLevels;
	int nivelActual=1;
	// Use this for initialization
	void Start () {
		if (PlayerPrefs.HasKey ("Nivel")) {
			nivelActual = PlayerPrefs.GetInt ("Nivel");
			imgLelvel.sprite = spriteLevels [nivelActual-1];
		} 
		else {
			PlayerPrefs.SetInt("Nivel",1);
			imgLelvel.sprite = spriteLevels [nivelActual-1];
		}

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
	public void choseLevel(){
		if (nivelActual<=2) {
			nivelActual++;
			imgLelvel.sprite = spriteLevels [nivelActual-1];
			PlayerPrefs.SetInt("Nivel",nivelActual);
		} 
		else if (nivelActual==3){
			nivelActual=1;
			imgLelvel.sprite = spriteLevels [nivelActual-1];
			PlayerPrefs.SetInt("Nivel",nivelActual);
		}

	}
}
