using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay09 : MonoBehaviour {
	//Objetos para tutorial y Tarjeta informativa
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public GameObject MenuWinLose;

	public GameObject _grieta;
	private GameObject _tempGrieta;

	private GameObject _textureTube;
	private float timeToGrietas;
	bool oneTime= false;
	private int numRandom=0;
	private Vector2[] iniPosition;
	public float[] timeGame;
	private int[] totalExplosivos;
	private float[] timeWaterAnim;
	private WaterAnimacion _waterAnimation;

	enum stateGame{Begin,InGame,Win,Lose,Pause};
	stateGame myState;
	private int nivel;

	//For the touch
	private Touch myTouch;
	private int tapCount;
	//para  cambiar  la  la grieta.
	private GameObject _tempTouchGrieta;
	private MoveExplosivo _moveExplosivo; 

	public bool isPausing=false;	
	//esperando un segundo
	private timedown _timeDown;
	private float time=2.0f;
	private float timeToWin=0.7f;
	//Audios
	public AudioSource _audioTema;
	public AudioClip[] winloseAudio;
	// Use this for initialization
	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text =_playerPrefs.PuntosTotales.ToString()+" pts";
		nivel = _playerPrefs.NivelActual;
		//nivel = 3;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		//nivel = _playerPrefs.NivelActual;

		timeGame = new float[]{0.0f,1.4f,0.9f,0.68f};
		totalExplosivos = new int[]{0,12,18,24};
		iniPosition = new Vector2[]{new Vector2 (10.0f,-7.24f),new Vector2 (10.0f,7.24f)};
		timeWaterAnim = new float[]{0,0.35f,0.35f,0.35f};
		_textureTube = GameObject.Find ("TextureTube");
		_waterAnimation = _textureTube.GetComponent<WaterAnimacion> ();
		_waterAnimation.scrollSpeed = timeWaterAnim [0];
		timeToGrietas = 16.0f;

	}
	
	// Update is called once per frame
	void Update () {
		if(!isPausing){
			if (myState == stateGame.InGame && totalExplosivos [nivel] > 0  && !_timeDown.isTimeOver) {
				touchToBoomb ();
			} 
			else if (myState != stateGame.Win && totalExplosivos [nivel] == 0 && !_timeDown.isTimeOver) {
				_playerPrefs.SetNewLevel();
				_txtPuntos.text =_playerPrefs.PuntosTotales.ToString()+" pts";
				myState= stateGame.Win;
				_timeDown.ActivateClock=false;
				_audioTema.Stop();

				StartCoroutine (countdown());
				StartCoroutine (countdown2());
			}
			else if (myState == stateGame.InGame && totalExplosivos [nivel] > 0 && _timeDown.isTimeOver) {
				myState = stateGame.Lose;
				_timeDown.ActivateClock=false;
				_audioTema.Stop();
				_audioTema.PlayOneShot(winloseAudio[1],0.6f);
				StartCoroutine (countdown());
			}
			if((myState == stateGame.Lose || myState == stateGame.Win) && timeToWin<=0 && !oneTime){
				_audioTema.PlayOneShot(winloseAudio[0],0.6f);
				oneTime= true;
			}
			if ((myState == stateGame.Lose || myState == stateGame.Win) && time<=0) {
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(myState == stateGame.Win ? ScriptMenuWinLose.tipoMensaje.Gano : ScriptMenuWinLose.tipoMensaje.Perdio);
			}
		}
	}

	IEnumerator CreaGrietas()
	{
		while (timeToGrietas>0.0 && myState== stateGame.InGame){
			yield return new WaitForSeconds(timeGame[nivel]);
			numRandom = Random.Range (1, 101);
			numRandom = numRandom >49?1:0;

			_tempGrieta=(GameObject)Instantiate(_grieta,iniPosition[numRandom],Quaternion.identity);
			_tempGrieta.transform.localScale = numRandom==1?new Vector3(0.7577969f,0.7577969f,0.7577969f):new Vector3(0.7577969f,-0.7577969f,0.7577969f);
			_tempGrieta.GetComponent<MoveExplosivo> ().RunExplosivo(nivel);
			timeToGrietas-=timeGame[nivel];
			//totalExplosivos--;
		}
	}

	void touchToBoomb(){
		tapCount = Input.touchCount;
		for (int i = 0 ; i < tapCount ; i++ ) {
			myTouch = Input.GetTouch(i);

			if(tapCount > 0 && ( myTouch.phase == TouchPhase.Began || myTouch.phase == TouchPhase.Moved || myTouch.phase == TouchPhase.Stationary)){

				Vector2 pos =myTouch.position;
				
				RaycastHit2D hitInfo=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos),Vector2.zero);

				if (hitInfo){
					_tempTouchGrieta  = hitInfo.transform.gameObject;
					Debug.Log (_tempTouchGrieta.tag);
					if(_tempTouchGrieta.tag =="crack" /*&& tempCrackHide.myState ==CrackHide.stateCrack.Grieta && juegosoul6.MyStateGame== AlmaJuego6.stateGame.InGame*/)
					{
						_moveExplosivo = _tempTouchGrieta.GetComponent<MoveExplosivo>();
						if(!_moveExplosivo.touched){
							_moveExplosivo.TouchToExplode();
							totalExplosivos[nivel]--;
						}
					}
				}
			}
		}
	}

	IEnumerator countdown()
	{
		while (time >0)
		{
			yield return new WaitForSeconds(1.5f);
			time -= 1;
		}
	}

	IEnumerator countdown2()
	{
		while (timeToWin >0)
		{
			yield return new WaitForSeconds(0.5f);
			timeToWin -= 0.5f;
		}
	}
	//Funciones para  botones de la UI
	public void InPause(){
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);
	}
	public void OutPause(){
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;
	}
	public void HideCanvasTutorial(){
		//_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		myState = stateGame.InGame;
		_waterAnimation.scrollSpeed = timeWaterAnim [nivel];
		StartCoroutine (CreaGrietas());
		_timeDown.ActivateClock = true;
	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		/*if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			myState = stateGame.InGame;
			_waterAnimation.scrollSpeed = timeWaterAnim [nivel];
			StartCoroutine (CreaGrietas());
			_timeDown.ActivateClock = true;
		}
		*/
	}
}
