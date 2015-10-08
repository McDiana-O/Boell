using UnityEngine;
using System.Collections;

public class MoveElement : MonoBehaviour {
	public float translation;
	public float position;
	public GamePlay11 _gamePlay11;
	public bool randomVel=true;
	void Start () {
		if(randomVel)
			translation = 0.1f+Random.value/8;
		else
			translation = 0.15f;
		_gamePlay11=GameObject.FindGameObjectWithTag("almadelJuego").GetComponent<GamePlay11>();
		//translation = 0.1f;
		}
	
	// Update is called once per frame
	void Update () {
		//if (_gamePlay11.mystate != GamePlay11.stateGameMini11.Pausa && _gamePlay11.mystate != GamePlay11.stateGameMini11.Gano && _gamePlay11.mystate != GamePlay11.stateGameMini11.Perdio) {
			if (this.transform.position.x > 8.0f || this.transform.position.x < -8.0f) {
				_gamePlay11.numGas--;
				Destroy (this.gameObject);
			}
			if (this.transform.position.y > 22.0f) {
				Destroy (this.gameObject);
			}
			this.gameObject.transform.Translate (0.0f, translation, 0.0f);
		//}
	} 
}
