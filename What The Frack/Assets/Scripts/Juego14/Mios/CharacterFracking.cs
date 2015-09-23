using UnityEngine;
using System.Collections;

public class CharacterFracking : MonoBehaviour {
	private bool startGame;
	private float waitTime=3.0f;
	public SpriteRenderer _spriteRenderer;
	public Sprite[] _spritesCharacter;
	public enum Genero{Hombre,Mujer};
	public Genero miGenero;
	private int IntGenero;
	// Use this for initialization
	void Start () {
		startGame = false;
		IntGenero =Random.Range (0,2);
		if (IntGenero == 0) 
		{
			miGenero= Genero.Hombre;
		}
		else 
		{
			miGenero= Genero.Mujer;
		}
		//miGenero = (IntGenero==0)? Genero.Hombre:Genero.Mujer;
		_spriteRenderer = GetComponent<SpriteRenderer> ();
		_spriteRenderer.sprite = _spritesCharacter [IntGenero];
	
	}
	
	// Update is called once per frame
	void Update () {
		if (startGame && _spriteRenderer.color.a>0) {
			_spriteRenderer.color = new Color(1f, 1f, 1f,_spriteRenderer.color.a -(1.0f/waitTime * Time.deltaTime));
		}
	
	}
	public void setStartBodyAplha(){
		startGame = true;
	}

}
