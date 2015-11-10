using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class changeRoad : MonoBehaviour {


	public GameObject _ObjGamePlay;
	public GamePlay02 _gamePlay02;

	public Sprite[] otherSprite;
	public enum typeRoad {Horizontal,Vertical};
	public typeRoad camino;
	private SpriteRenderer _spriteRenderer;
	public int ID_Father;

	void Awake(){
		_gamePlay02 = _ObjGamePlay.GetComponent<GamePlay02> ();
		_spriteRenderer = this.GetComponent<SpriteRenderer> ();
		if (camino == typeRoad.Horizontal) 
		{
			_spriteRenderer.sprite = otherSprite [0];
		} 
		else 
		{
			_spriteRenderer.sprite = otherSprite [1];
		}
	}
	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
		//debugTxt.text = "H1: " + _gamePlay02.roadFull [0] + "H2: " + _gamePlay02.roadFull [1] + "V1: " + _gamePlay02.roadFull [2] + "V2:" + _gamePlay02.roadFull [3];
	}
	
	public void ChangeLineToRoad(){
		if (this.camino == typeRoad.Horizontal) {
			_spriteRenderer.sprite = otherSprite [2];
		}
		else {
			_spriteRenderer.sprite = otherSprite [3];
		}
	}

	public void CountRoads(){
		if (ID_Father == 0 && _spriteRenderer.sprite != otherSprite [2]) {
			_gamePlay02.roadFull [0]++;

		}

		else if(ID_Father == 1 && _spriteRenderer.sprite != otherSprite [2]){
			_gamePlay02.roadFull[1]++;
		}
		
		else if(ID_Father == 2 && _spriteRenderer.sprite != otherSprite [3]){
			_gamePlay02.roadFull[2]++;
		}
		
		else if(ID_Father == 3 && _spriteRenderer.sprite != otherSprite [3]){
			_gamePlay02.roadFull[3]++;
		}
	}
}
