using UnityEngine;
using System.Collections;

public class ChangeSprite : MonoBehaviour {

	public Sprite[]  sprites;
	private SpriteRenderer _spriteRenderer;
	// Use this for initialization
	void Start () {
		_spriteRenderer = GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	/// <summary>
	/// Funcion para  cambiar de  sprite/// </summary>
	/// <param name="index">Index del arreglo del sprite que quieres  cambiar</param>
	public void ChangeImg(int index){
		_spriteRenderer.sprite = sprites [index];
	}

	/// <summary>
	/// Funcion para  cambiar de  sprite/// </summary>
	/// <param name="name">Nombre  del sprite cambiar del arreglo</param>
	public void ChangeImg(string name){
		for (int i=0; i<sprites.Length; i++) {
			if(sprites[i].name==name)
			{
				_spriteRenderer.sprite = sprites [i];

			}
		}
	}
}
