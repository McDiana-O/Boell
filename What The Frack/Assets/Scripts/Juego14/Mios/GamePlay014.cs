using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GamePlay014 : MonoBehaviour {

	//Estados del juego 
	public enum StateGame{Begin,Introduccion,InGame,Lose,Pause};
	public StateGame myState; 

	private CharacterFracking _characterFracking;
	private GameObject _OrganoTocado;
	private BlinkOrgano _BlinkOrganoTocado;
	public GameObject[] Cuerpecito;
	private int[] pointID;
	private int IndexOrgano;

	////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////////
	public bool isPausing=false;	/// 
	//Objetos para tutorial y Tarjeta informativa
	public GameObject TarjestasInformativas; 
	public GameObject CanvasTutorial;
	public GameObject MenuWinLose;
	//For the touch
	private Touch myTouch;
	private int tapCount;
	//esperando un segundo
	private timedown _timeDown;
	public float time=1.0f;
	public float CountTime=0.0f;
	private float timePrev;
	//Audios
	public AudioSource _audioTema;
	public AudioSource _AudioBip;
	public AudioSource _SFX;
	public AudioClip[] winloseAudio;
	// Use this for initialization
	private GamePlayerPrefs _playerPrefs;
	public Text _txtPuntos;
	void Start () {
		_playerPrefs = GameObject.FindGameObjectWithTag ("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
		_txtPuntos.text =_playerPrefs.PuntosTotales.ToString()+" pts";
		//nivel = PlayerPrefs.GetInt ("Nivel");nivel = PlayerPrefs.GetInt ("Nivel");

		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		_characterFracking = GameObject.Find ("CharacterMH").GetComponent<CharacterFracking>();
		IndexOrgano = 0;
		myState = StateGame.Begin;
		StartCoroutine(CountToSick());
	
	}
	
	// Update is called once per frame
	void Update () {

		if(!isPausing) 
		{
			if (myState == StateGame.Introduccion && _characterFracking._spriteRenderer.color.a <= 0) {
				_timeDown.ActivateClock = true;
				myState = StateGame.InGame;
				timePrev=CountTime;
				_AudioBip.Play();
			} 
			else if (myState == StateGame.InGame) 
			{
				if(_timeDown.isTimeOver ){
					myState = StateGame.Lose;
					_playerPrefs.SetNewLevel();
					_txtPuntos.text =_playerPrefs.PuntosTotales.ToString()+" pts";
					_timeDown.ActivateClock=false;
					_audioTema.Stop();
					_audioTema.PlayOneShot(winloseAudio[1],0.6f);
					StartCoroutine (countdown());

				}
				else{
					touchToOrgano();
					if(CountTime-timePrev>=0.8f && IndexOrgano<pointID.Length){
						Cuerpecito[pointID[IndexOrgano]].GetComponent<BlinkOrgano>().SetEnfermo();
						timePrev=CountTime;
						IndexOrgano++;
					}

				}
			}
			if(myState== StateGame.Lose && time<=0){
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Gano);

			}
		}
	}
	
	void touchToOrgano(){
		tapCount = Input.touchCount;
		for (int i = 0 ; i < tapCount ; i++ ) {
			myTouch = Input.GetTouch(i);
			
			if(tapCount > 0 && ( myTouch.phase == TouchPhase.Began || myTouch.phase == TouchPhase.Moved || myTouch.phase == TouchPhase.Stationary)){
				
				Vector2 pos =myTouch.position;
				
				RaycastHit2D hitInfo=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos),Vector2.zero);
				
				if (hitInfo){
					_OrganoTocado  = hitInfo.transform.gameObject;
					if(_OrganoTocado.tag =="crack")
					{
						_BlinkOrganoTocado= _OrganoTocado.GetComponent<BlinkOrgano>();
						if(_BlinkOrganoTocado.miEstado == BlinkOrgano.Estado.Enfermo){
							_BlinkOrganoTocado.SetSano();
							_SFX.PlayOneShot(winloseAudio[2]);
						}
					}
				}
			}
		}
	}


	IEnumerator CountToSick()
	{	
		while (CountTime <35)
		{
			yield return new WaitForSeconds(0.1f);
			CountTime += 0.1f;
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

	//Funciones para  botones de la UI
	public void InPause(){
		isPausing = true;
		Time.timeScale=0;
		MenuWinLose.SetActive(true);
		MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Pause);
		_AudioBip.Pause();
	}
	public void OutPause(){
		isPausing = false;
		MenuWinLose.SetActive(false);
		Time.timeScale=1;
		_AudioBip.UnPause();
	}
	public void HideCanvasTutorial(){
		_playerPrefs.seveTutorial ();
		CanvasTutorial.SetActive (false);
		myState = StateGame.Introduccion;
		_characterFracking.setStartBodyAplha();

	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		if (_characterFracking.miGenero == CharacterFracking.Genero.Hombre) {
			pointID = NumerosRandom.randomArray (6);
			Cuerpecito[6].SetActive(false);
		} else {
			pointID = NumerosRandom.randomArray (7);
			Cuerpecito[6].SetActive(true);
		}
		if (_playerPrefs.Tutos [_playerPrefs.MiniGameActual - 1] == 1) {
			CanvasTutorial.SetActive (false);
			myState = StateGame.Introduccion;
			_characterFracking.setStartBodyAplha();
		}
	}
}
