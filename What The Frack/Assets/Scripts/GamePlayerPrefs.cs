using UnityEngine;
using System.Collections;

public class GamePlayerPrefs : MonoBehaviour {

	public int PuntosTotales;
	public int NivelActual;
	public int NivelMaximo;

	public int OnMuteMusic;
	public int OnMuteSFX;
	public int MiniGameActual;
	public int[] Minigame= new int[14];
	public int[] Tutos = new int[14];
	public int[] OpenedCards = new int[25];


	public static GamePlayerPrefs _gamePlayerPrefs;
	void Awake(){
		if (_gamePlayerPrefs == null) {
			_gamePlayerPrefs = this;
			DontDestroyOnLoad (gameObject);
		} 
		else if (_gamePlayerPrefs != this) 
		{
			Destroy(gameObject);
		}
	}
	// Use this for initialization
	void Start () {
		//PlayerPrefs.DeleteAll ();
		NivelActual = 0;
		CreateVariables ();
		CreateNumPoints ();
		CreateNivelArray ();
		CreateTutoArray ();
		CreateCardsArray ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void CreateVariables(){
		if (PlayerPrefs.HasKey ("Nivel")) {
			NivelActual = PlayerPrefs.GetInt ("Nivel");
		} 
		else {
			PlayerPrefs.SetInt("Nivel",1);
			NivelActual=1;
		}

		if (PlayerPrefs.HasKey ("NivelMaximo")) {
			NivelMaximo = PlayerPrefs.GetInt ("NivelMaximo");
		} 
		else {
			PlayerPrefs.SetInt("NivelMaximo",1);
			NivelMaximo=1;
		}

		if (PlayerPrefs.HasKey ("OnMuteMusic")) {
			OnMuteMusic = PlayerPrefs.GetInt ("OnMuteMusic");
		} 
		else {
			PlayerPrefs.SetInt("OnMuteMusic",0);
			OnMuteMusic= 0;
		}


		if (PlayerPrefs.HasKey ("OnMuteSFX")) {
			OnMuteSFX = PlayerPrefs.GetInt ("OnMuteSFX");
		} 
		else {
			PlayerPrefs.SetInt("OnMuteSFX",0);
			OnMuteSFX =0;
		}

	}
	void CreateNumPoints(){
		if (PlayerPrefs.HasKey ("PuntosTotales")) {
			PuntosTotales = PlayerPrefs.GetInt ("PuntosTotales");

		} 
		else {
			PuntosTotales =0;
			PlayerPrefs.SetInt("PuntosTotales",PuntosTotales);
		}
	}

	void CreateNivelArray(){
		for (int index=0; index<Minigame.Length; index++) {
			if (PlayerPrefs.HasKey ("MiniGame"+index)) {
				Minigame[index] = PlayerPrefs.GetInt ("MiniGame"+index);
				
			} 
			else {
				if(index==0){
					PlayerPrefs.SetInt("MiniGame"+index,1);
					Minigame[index] = 1;
				}else{
					PlayerPrefs.SetInt("MiniGame"+index,0);
					Minigame[index] = 0;
				}
			}
		}
	}
	/*
	 * 0 Buton y Tarjeta Bloqueada (Requiere puntos para Desbloquear)
	 * 1 Buton Desbloquado 
	 */
	void CreateCardsArray(){
		PlayerPrefs.SetInt("OpenCards0",1);
		OpenedCards[0] = 1;
		for (int index=1; index<OpenedCards.Length; index++) {
			if (PlayerPrefs.HasKey ("OpenCards"+index) ){
				OpenedCards[index] = PlayerPrefs.GetInt ("OpenCards"+index);
			} 
			else {
				PlayerPrefs.SetInt("OpenCards"+index,0);
				OpenedCards[index] = 0;
			}
		}
	}

	void CreateTutoArray(){
		for (int index=0; index<Tutos.Length; index++) {
			if (PlayerPrefs.HasKey ("Tutoriales"+index)) {
				Tutos[index] = PlayerPrefs.GetInt ("Tutoriales"+index);
			} 
			else {
				PlayerPrefs.SetInt("Tutoriales"+index,0);
				Tutos[index] = 0;
			}
		}
	}

	public void seveTutorial(){
		setOpenCard (MiniGameActual, 1);
		PlayerPrefs.SetInt("Tutoriales"+(MiniGameActual-1),1);
		Tutos [MiniGameActual - 1] = 1;
	}


	public void SetNewLevel(){
		if ((NivelMaximo) == Minigame [MiniGameActual-1]) {
			//Minigame[MiniGameActual-1]=(Minigame[MiniGameActual-1]+1);
			if(NivelMaximo==1){
				PuntosTotales=PuntosTotales+30;
				PlayerPrefs.SetInt("PuntosTotales",PuntosTotales);
				if(MiniGameActual<14){
					PlayerPrefs.SetInt("MiniGame"+MiniGameActual,1);
				}
				PlayerPrefs.SetInt("MiniGame"+(MiniGameActual-1),2);
			}
			else if(NivelMaximo==2){
				PuntosTotales=PuntosTotales+50;
				PlayerPrefs.SetInt("PuntosTotales",PuntosTotales);
				//PlayerPrefs.SetInt("MiniGame"+MiniGameActual,2);
				PlayerPrefs.SetInt("MiniGame"+(MiniGameActual-1),3);
			}
			else if(NivelMaximo==3){
				PuntosTotales=PuntosTotales+70;
				//PlayerPrefs.SetInt("MiniGame"+MiniGameActual,3);
				PlayerPrefs.SetInt("PuntosTotales",PuntosTotales);
				PlayerPrefs.SetInt("MiniGame"+(MiniGameActual-1),4);
			}

			Minigame[MiniGameActual-1] = PlayerPrefs.GetInt ("MiniGame"+(MiniGameActual-1));
			if(MiniGameActual<14){
				Minigame[MiniGameActual] = PlayerPrefs.GetInt ("MiniGame"+MiniGameActual);
			}

		}
	}
	public void addOneNivelMaximo(){
		int index;
		for(index=0; index<Minigame.Length;index++){
			//Debug.Log ("Level: "+Minigame[index]+" NivelMaximo: "+NivelMaximo);

			if((NivelMaximo+1)==Minigame[index]){
				//Debug.Log("Continue");
				//continue;
			}
			else{
				//Debug.Log("break");
				break;
			}

			//Debug.Log (index);
			if (index == 13) {
				PlayerPrefs.SetInt("NivelMaximo",(NivelMaximo+1));
				NivelMaximo= PlayerPrefs.GetInt("NivelMaximo");
			}
		}
	}
	public void setOpenCard(int index,int value){
		PlayerPrefs.SetInt ("OpenCards"+index,value);
		//Debug.Log ("EntroAqui"+PlayerPrefs.GetInt ("OpenCards" + (17 + index)).ToString());
		OpenedCards [index] = PlayerPrefs.GetInt ("OpenCards"+index);
		if (index == 14) {
			PlayerPrefs.SetInt ("OpenCards"+(index+1),value);
			//Debug.Log ("EntroAqui"+PlayerPrefs.GetInt ("OpenCards" + (17 + index)).ToString());
			OpenedCards [index] = PlayerPrefs.GetInt ("OpenCards"+(index+1));

		}
	}
	public void UpdatePuntos(int sumando){
		PuntosTotales = PuntosTotales + sumando;
		PlayerPrefs.SetInt("PuntosTotales",PuntosTotales);

	}
	public string getPointsTxt(){
		string pointsTemp=PlayerPrefs.GetInt("PuntosTotales").ToString();
		int ptsLen = 4-pointsTemp.Length;
		for (int i=0; i<ptsLen; i++)
			pointsTemp = "0" + pointsTemp;
		pointsTemp+=" pts";
		return pointsTemp;
	}
	public void SetMusicSounds(int value){
		PlayerPrefs.SetInt("OnMuteMusic",value);
		OnMuteMusic = value;
	}

	public void SetSoundsFX(int value){
		PlayerPrefs.SetInt("OnMuteSFX",value);
		OnMuteSFX = value;
	}
	public void SoundMuteApply(){
		GameObject [] MusicSounds = GameObject.FindGameObjectsWithTag ("MainSounds");
		GameObject [] SoundsFX = GameObject.FindGameObjectsWithTag ("SFXSounds");
		if (OnMuteMusic == 1) {
			for (int i=0; i<MusicSounds.Length; i++) {
				MusicSounds [i].GetComponent<AudioSource> ().mute = true;
			}
		} 
		else {
			for (int i=0; i<MusicSounds.Length; i++) {
				MusicSounds [i].GetComponent<AudioSource> ().mute = false;
			}
		}
		if (OnMuteSFX == 1) {
			for (int i=0; i<SoundsFX.Length; i++) {
				SoundsFX [i].GetComponent<AudioSource> ().mute = true;
			}
		} 
		else {
			for (int i=0; i<SoundsFX.Length; i++) {
				SoundsFX [i].GetComponent<AudioSource> ().mute = false;
			}
		}
	}
}
