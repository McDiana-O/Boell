using UnityEngine;
using System.Collections;

public class MoveExplosivo : MonoBehaviour {
	public int[] velocidad;
	private int i;
	public GameObject _explosivo;
	public GameObject _explosion;
	private Animator _animaGrieta;
	private Animator _animExplosion;
	public AudioSource _SFX;
	public AudioClip[] _SoundSFX;
	private GamePlay09 _gameplay09;
	public bool touched;
	public float variable;
	// Use this for initialization
	void Start () {
		_SFX = GameObject.Find ("SFX_Audio").GetComponent<AudioSource>();
		_animaGrieta = GetComponent<Animator> ();
		_animExplosion = _explosion.GetComponent<Animator> ();

		_animaGrieta.Play("Grieta"+Random.Range(1,4));
		_animaGrieta.speed = 0;
		_animExplosion.speed = 0;
		touched = false;
		_gameplay09 = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<GamePlay09> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Time.timeScale != 0.0f) {
			transform.Translate (i==0?Vector3.zero:((Vector3.left/velocidad[i]))*Time.deltaTime*60.0f);

		}
		if (this.gameObject.transform.position.x < -13.0f && !touched) {
			_gameplay09.salioExplosivo = true;
		}
	}

	public void RunExplosivo(int index){
		i = index;
	}

	public void TouchToExplode(){
		_animaGrieta.speed = 1;
		_SFX.PlayOneShot(_SoundSFX[0]);
		_animExplosion.speed = 1;
		_explosivo.SetActive(false);
		_SFX.PlayOneShot(_SoundSFX[1]);
		touched= true;
	}

}
