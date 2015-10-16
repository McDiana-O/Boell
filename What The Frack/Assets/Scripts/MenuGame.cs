﻿using UnityEngine;
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
	public Image ImgSFX;
	public Sprite[] SpriteBtnSFX;
	public Image ImgMusicSound;
	public  Sprite[] SpriteBtnMusicSound;
	//public int[] NivelesGames = new int[14];
	// Use this for initialization
	void Awake(){
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_playerPrefs.SoundMuteApply ();
	}
	void Start () {
		_playerPrefs.MiniGameActual = 0;
		_textPuntos.text = _playerPrefs.getPointsTxt ();
		_playerPrefs.SoundMuteApply ();
		ImgSFX.sprite = SpriteBtnSFX[_playerPrefs.OnMuteSFX];
		ImgMusicSound.sprite = SpriteBtnMusicSound[_playerPrefs.OnMuteMusic];

		startWorld ();
		_playerPrefs.addOneNivelMaximo ();
		//_textPuntos.text="0 pts";
		_playerPrefs.NivelActual=PlayerPrefs.GetInt("Nivel");
		nivelActual = _playerPrefs.NivelActual;
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

	public void SetMuteSFX(){
		_playerPrefs.SetSoundsFX (_playerPrefs.OnMuteSFX == 1 ? 0 : 1);
		_playerPrefs.SoundMuteApply ();
		ImgSFX.sprite = SpriteBtnSFX[_playerPrefs.OnMuteSFX];
	}
	public void SetMuteSoundMain(){
		_playerPrefs.SetMusicSounds (_playerPrefs.OnMuteMusic == 1 ? 0 : 1);
		_playerPrefs.SoundMuteApply ();
		ImgMusicSound.sprite = SpriteBtnMusicSound[_playerPrefs.OnMuteMusic];
	
	//_playerPrefs.OnMuteMusic==1?btnSFX.:1
	}
	public void choseLevel(){
		if (_playerPrefs.NivelMaximo == 1) 
		{
			PlayerPrefs.SetInt("Nivel",nivelActual);
		}
		else if (_playerPrefs.NivelMaximo == 2) 
		{
			if (nivelActual<=1) {
				nivelActual++;
				imgLelvel.sprite = spriteLevels [nivelActual-1];
				PlayerPrefs.SetInt("Nivel",nivelActual);
			}
			else if (nivelActual==2){
				nivelActual=1;
				imgLelvel.sprite = spriteLevels [nivelActual-1];
				PlayerPrefs.SetInt("Nivel",nivelActual);
			}
		}
		else if (_playerPrefs.NivelMaximo == 3 || _playerPrefs.NivelMaximo == 4)
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
		_playerPrefs.NivelActual = nivelActual;
	}
}
