using UnityEngine;
using System.Collections;

public class RotateElement : MonoBehaviour {
	public float rotation;
	public float position;
	public GamePlay11 _gamePlay11;
	public bool randomVel=true;
	void Start () {
		int rango = 0;
		rotation = 0;
		if (randomVel)
			while (rotation==0) {
			rango = Random.Range (-1, 2) ;
			rotation = Random.value * rango;
			}
			//rotation = 0.1f+Random.Range(-1,2)/8;
		else
			rotation = 0.15f;
		Debug.Log ("rango="+rango+" rotation="+rotation);
		_gamePlay11=GameObject.FindGameObjectWithTag("almadelJuego").GetComponent<GamePlay11>();
		//translation = 0.1f;
		}
	
	// Update is called once per frame
	void Update () {
		if (!_gamePlay11.isPausing) {
			this.gameObject.transform.Rotate (0.0f, 0.0f, rotation);
		}
	} 
}
