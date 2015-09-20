using UnityEngine;
using System.Collections;

public class MoveExplosivo : MonoBehaviour {
	public int[] velocidad;
	public int i;
	public GameObject _explosivo;
	public GameObject _explosion;
	private Animator _animaGrieta;
	private Animator _animExplosion;
	public AudioSource _SFX;
	public AudioClip[] _SoundSFX;

	public bool touchme = false;
	// Use this for initialization
	void Start () {
		_SFX = GameObject.Find ("SFX_Audio").GetComponent<AudioSource>();
		_animaGrieta = GetComponent<Animator> ();
		_animExplosion = _explosion.GetComponent<Animator> ();

		_animaGrieta.Play("Grieta"+Random.Range(1,4));
		_animaGrieta.speed = 0;
		_animExplosion.speed = 0;
	}
	
	// Update is called once per frame
	void Update () {

		transform.Translate (i==0?Vector3.zero:(Vector3.left/velocidad[i]));
		if (touchme) {
			_animaGrieta.speed = 1;
			_SFX.PlayOneShot(_SoundSFX[0]);
			_animExplosion.speed = 1;
			_explosivo.SetActive(false);
			_SFX.PlayOneShot(_SoundSFX[1]);
			touchme= false;
		}
	}

	public void Explode(){
		touchme = true;

	}
	public void RunExplosivo(int index){
		i = index;
	}

}
