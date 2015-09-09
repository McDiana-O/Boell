using UnityEngine;
using System.Collections;

public class changeCircle : MonoBehaviour {
	public Sprite[] _sprites;
	SpriteRenderer _spriteRenderer;
	private bool isTouchme= false;
	public GamePlay02 _gamePlay02;
	private AlphaAnimacion _alpha;


	private SFX_Sounds _sfxSounds;
	// Use this for initialization
	void Start () {
		_spriteRenderer = this.GetComponent<SpriteRenderer> ();
		_gamePlay02 =GameObject.FindGameObjectWithTag ("GamePlay").GetComponent<GamePlay02> ();
		_sfxSounds = GameObject.FindGameObjectWithTag ("SFXSounds").GetComponent<SFX_Sounds>();
		_alpha = GetComponent<AlphaAnimacion> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void changeMachine(int idMachine){
		if(!isTouchme){
			_sfxSounds.ChangeAudio("Roca_Quebrandose(V2)");
			_sfxSounds.SFXLoop(false);
			_sfxSounds.SFXPlay();
			_spriteRenderer.sprite=_sprites[idMachine];
			_gamePlay02.totalMachines++;
			_alpha.alpheComplete();
			this.isTouchme = true;
		}
	}
}
