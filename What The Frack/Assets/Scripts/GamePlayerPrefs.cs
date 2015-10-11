using UnityEngine;
using System.Collections;

public class GamePlayerPrefs : MonoBehaviour {

	public int PuntosTotales;
	public int NivelActual;
	public int NivelMaximo;

	public int OnMusic;
	public int OnSFX;
	public int MiniGameActual;
	public int[] Minigame= new int[14];
	public int[] Tutos = new int[14];
	public int[] OpenedCards = new int[9];

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

		if (PlayerPrefs.HasKey ("OnMusic")) {
			OnMusic = PlayerPrefs.GetInt ("OnMusic");
		} 
		else {
			PlayerPrefs.SetInt("OnMusic",1);
			OnMusic= 1;
		}


		if (PlayerPrefs.HasKey ("OnSFX")) {
			OnSFX = PlayerPrefs.GetInt ("OnSFX");
		} 
		else {
			PlayerPrefs.SetInt("OnSFX",1);
			OnSFX =1;
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

	void CreateCardsArray(){
		for (int index=0; index<OpenedCards.Length; index++) {
			if (PlayerPrefs.HasKey ("OpenCards"+(17+index)) ){
				OpenedCards[index] = PlayerPrefs.GetInt ("OpenCards"+(17+index));
			} 
			else {
				PlayerPrefs.SetInt("OpenCards"+(17+index),0);
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
	public void setOpenCard(int index){
		PlayerPrefs.SetInt ("OpenCards"+(17+index),1);
		//Debug.Log ("EntroAqui"+PlayerPrefs.GetInt ("OpenCards" + (17 + index)).ToString());
		OpenedCards [index] = PlayerPrefs.GetInt ("OpenCards"+(17+index));
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
}
