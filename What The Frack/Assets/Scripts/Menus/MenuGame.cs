using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MenuGame : MonoBehaviour {

	public GotoEnd _gotoEnd;
	public GameObject imgCargando;
	public Text textCargando;
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
	public GameObject tarjetaMensajeQuiz;
	public GameObject resplandor;
    Text[] textosRayos;
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
		//Debug.Log (_playerPrefs.IsMyFirstTime ().ToString ());
		if (_playerPrefs.MyFirstTime==0 && _playerPrefs.IsMyFirstTime()) {
			resplandor.SetActive(true);
		}


		startWorld ();
		if (_playerPrefs.NivelMaximo < 3) {
			_playerPrefs.addOneNivelMaximo ();
		}
		//_textPuntos.text="0 pts";
		_playerPrefs.NivelActual=PlayerPrefs.GetInt("Nivel");
		nivelActual = _playerPrefs.NivelActual;
		imgLelvel.sprite = spriteLevels [_playerPrefs.NivelActual- 1];
        GetTxtRayos();
		textCargando.text = "";
    }
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape))
		{	 
			_gotoEnd.AksToQuit();
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

		//textCargando.text = _playerPrefs.Lgui.getString("loadingscreen_text");
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
			tarjetaMensajeQuiz.SendMessage ("ShowMensaje", "mainmenu_mapamundi_popup_completa");
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
	public void GotoUrl(string url){
		Application.OpenURL (url);
	}

	void OnDestroy() {
		if (_playerPrefs.MyFirstTime == 1) {
			_playerPrefs.setMyFirstTime ();
			resplandor.SetActive(false); 
		}

	}

    void GetTxtRayos() {
        GameObject[] objetos;
        objetos = GameObject.FindGameObjectsWithTag("txtrayos");
        int i=1; 
        foreach (GameObject objeto in objetos) {
			//Debug.Log("d:"+objeto.name);
			string s;
			s = objeto.name.Substring(5,2);
			Debug.Log("d:"+s);
			objeto.GetComponent<Text>().text = System.Text.RegularExpressions.Regex.Unescape(_playerPrefs.LMenuMapa.getString("minigame_" + s+ "_title"));
            /*if (i < 10)
            {
                objeto.GetComponent<Text>().text = System.Text.RegularExpressions.Regex.Unescape(_playerPrefs.LMenuMapa.getString("minigame_0" + i + "_title"));
            }
            else {
                objeto.GetComponent<Text>().text = System.Text.RegularExpressions.Regex.Unescape(_playerPrefs.LMenuMapa.getString("minigame_" + i + "_title"));
            }*/
            i++;
        }


        
    }
}
