using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour {
	float contador=3;
	public GameObject imgCargando;
	public Image imgLelvel; 
	public Sprite[] spriteLevels;
	int nivelActual=1;
	public Text _textPuntos;
	private GamePlayerPrefs _playerPrefs;
	public Button[] _btnsMiniGames= new Button[14];
	//public int[] NivelesGames = new int[14];
	// Use this for initialization
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_playerPrefs.MiniGameActual = 0;
		_textPuntos.text=_playerPrefs.PuntosTotales.ToString()+" pts";
		startWorld ();
		_playerPrefs.addOneNivelMaximo ();
		//_textPuntos.text="0 pts";
		if (_playerPrefs.NivelMaximo == 4) {
			nivelActual = PlayerPrefs.GetInt ("Nivel");
		} 
		else {
			_playerPrefs.NivelActual=_playerPrefs.NivelMaximo;
			//PlayerPrefs.SetInt("Nivel",_playerPrefs.NivelMaximo);
		}
		imgLelvel.sprite = spriteLevels [_playerPrefs.NivelActual- 1];
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{	 
			Application.Quit(); 
		}

	}
	void startWorld(){
		//playerPrefs
		for (int index=0; index</*NivelesGames.Length*/_playerPrefs.Minigame.Length; index++) {
			if(_playerPrefs.Minigame[index]>0)
			{
				_btnsMiniGames[index].interactable=true;
			}	
		}
	}
	public void GotoWorld(string level){
		int id;
		id =int.Parse(level.Remove (0, 5).ToString());
		_playerPrefs.MiniGameActual = id;


		imgCargando.SetActive (true);
		Application.LoadLevel(level);
	}
	//Cualquiera que no sean minijuegos
	public void GotoOther(string level){
		imgCargando.SetActive (true);
		Application.LoadLevel(level);

	}
	public void choseLevel(){
		if (_playerPrefs.NivelMaximo == 1) 
		{
			PlayerPrefs.SetInt("Nivel",nivelActual);
			
		}
		else if (_playerPrefs.NivelMaximo == 2) 
		{
			PlayerPrefs.SetInt("Nivel",nivelActual);

		}
		else if (_playerPrefs.NivelMaximo == 3) 
		{
			PlayerPrefs.SetInt("Nivel",nivelActual);
			
		}
		else if (_playerPrefs.NivelMaximo == 4) 
		{
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
}
