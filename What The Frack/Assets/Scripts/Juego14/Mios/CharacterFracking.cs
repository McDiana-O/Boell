using UnityEngine;
using System.Collections;

public class CharacterFracking : MonoBehaviour {
	public bool startGame;
	public float waitTime;
	private SpriteRenderer _spriteRenderer;
	public Sprite[] _spritesCharacter;
	public enum Genero{Hombre,Mujer};
	public Genero miGenero;
	private int IntGenero;
	// Use this for initialization
	void Start () {
		IntGenero =Random.Range (0,2);
		miGenero = (IntGenero==0)? Genero.Hombre:Genero.Mujer;
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		_spriteRenderer.sprite = _spritesCharacter [IntGenero];
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startGame) {
			_spriteRenderer.color = new Color(1f, 1f, 1f,_spriteRenderer.color.a -(1.0f/waitTime * Time.deltaTime));
		}
	
	}

}
