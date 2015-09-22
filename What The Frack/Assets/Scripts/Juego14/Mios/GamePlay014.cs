using UnityEngine;
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
	private float time=1;
	//Audios
	public AudioSource _audioTema;
	public AudioClip[] winloseAudio;
	// Use this for initialization
	void Start () {
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		_characterFracking = GameObject.Find ("CharacterMH").GetComponent<CharacterFracking>();

		if (_characterFracking.miGenero == CharacterFracking.Genero.Hombre) {
			pointID = NumerosRandom.randomArray (6);
		} else {
			pointID = NumerosRandom.randomArray (7);
		}
		myState = StateGame.Begin;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (isPausing) {
			Time.timeScale=0;
		} 
		else 
		{
			Time.timeScale=1;
			if (myState == StateGame.Introduccion && _characterFracking._spriteRenderer.color.a <= 0) {
				_timeDown.ActivateClock = true;
				myState = StateGame.InGame;
			} 
			else if (myState == StateGame.InGame) 
			{
				if(_timeDown.isTimeOver ){
					myState = StateGame.Lose;
					_timeDown.ActivateClock=false;
					_audioTema.Stop();
					_audioTema.PlayOneShot(winloseAudio[1],0.6f);
					StartCoroutine (countdown());
				}
			}
			if(myState== StateGame.Lose && time<=0){
				MenuWinLose.SetActive(true);
				MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
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
	public void HideCanvasTutorial(){
		CanvasTutorial.SetActive (false);
		myState = StateGame.Introduccion;
		_characterFracking.setStartBodyAplha();

	}
	
	public void HideTarjetaInformativa(){
		TarjestasInformativas.SetActive (false);
		
	}
}
