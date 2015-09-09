using UnityEngine;
using System.Collections;

public class MoveElement : MonoBehaviour {
	public float translation;
	public float position;
	public GamePlay11 _gamePlay11;
	void Start () {
		translation = 0.1f+Random.value/8;
		_gamePlay11=GameObject.FindGameObjectWithTag("almadelJuego").GetComponent<GamePlay11>();
		//translation = 0.1f;
		}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.position.x > 8.0f || this.transform.position.x < -8.0f) {
			_gamePlay11.numGas--;
			Destroy(this.gameObject);
		}
		this.gameObject.transform.Translate (0.0f,translation,0.0f);
	} 
}
