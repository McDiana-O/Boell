using UnityEngine;
using System.Collections;

public class muevePerforacion : MonoBehaviour {
	public int succeeded=0;
	private float mov=0;
	private GamePlay08 _gamePlay;
	//private int level=0;
	// Use this for initialization
	void Start () {
		_gamePlay = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<GamePlay08> ();
		//level = PlayerPrefs.GetInt("Nivel");
		//level = 3;
		/*switch (level) {
		case 1:
			rangeMove=0.4f;
			break;
		case 2:
			rangeMove=0.6f;
			break;
		case 3:
			rangeMove=0.8f;
			break;
		}*/
		StartCoroutine (SetMov ());
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (!_gamePlay.isPausing) {
			if (_gamePlay.mystate == GamePlay08.stateGameMini08.Iniciando)
			if (this.gameObject.transform.position.x < 3.7)
				this.gameObject.transform.Translate (Vector3.right / 8.0f);
			else
				_gamePlay.mystate = GamePlay08.stateGameMini08.Jugando;
			if (_gamePlay.mystate == GamePlay08.stateGameMini08.Jugando) {
				//Debug.Log("antes="+this.gameObject.transform.rotation.z);
				//Debug.Log(Input.acceleration.x);
				//rotation=this.gameObject.transform.rotation.z+Input.acceleration.x/4;
				//Debug.Log("despues="+rotation);
				/*if(rotation > 0.3)
				this.gameObject.transform.rotation = new Quaternion(0,0,0.28f,1.0f);
			else if(rotation < -0.3)
				this.gameObject.transform.rotation = new Quaternion(0,0,-0.28f,1.0f);
			else*/
				this.gameObject.transform.Rotate (Vector3.back * Input.acceleration.x * (2));
				if (this.gameObject.transform.rotation.z > 0.17)
					this.gameObject.transform.rotation = new Quaternion (0, 0, 0.17f, 1.0f);
				else if (this.gameObject.transform.rotation.z < -0.17)
					this.gameObject.transform.rotation = new Quaternion (0, 0, -0.17f, 1.0f);
				//Debug.Log(this.gameObject.transform.rotation.z);
				//this.gameObject.transform.rotation = new Quaternion(0,0,0.28f,1.0f);
				//Debug.Log(mov);
				this.gameObject.transform.parent.transform.Translate (Vector3.up * (this.gameObject.transform.rotation.z * 0.5f + mov));
				//this.gameObject.transform.Translate (Vector3.up*Input.acceleration.x);
				//if(this.gameObject.transform.parent.transform.position.y<-3 ||this.gameObject.transform.parent.transform.position.y>3)
				//	_gamePlay.mystate=GamePlay08.stateGameMini08.Perdio;
			}
		}
	}
	void OnCollisionEnter2D(Collision2D coll) {
		if (!_gamePlay.isPausing && (_gamePlay.mystate == GamePlay08.stateGameMini08.Jugando ||_gamePlay.mystate == GamePlay08.stateGameMini08.Iniciando)) {
			if (coll.gameObject.name != "PuntoObjetivo") {
				//Debug.Log(coll.gameObject.name);
				if (coll.gameObject.tag == "crack") {
					//Debug.Log(coll.gameObject.name);
					_gamePlay.mystate = GamePlay08.stateGameMini08.Perdio;
				}
				else
					Destroy (coll.gameObject);
			} else {
				succeeded = 1;
				_gamePlay.mystate = GamePlay08.stateGameMini08.Gano;
			}
		}
	}
	IEnumerator SetMov()
	{
		while (!_gamePlay.isPausing && (_gamePlay.mystate!= GamePlay08.stateGameMini08.Gano||_gamePlay.mystate!= GamePlay08.stateGameMini08.Perdio)) {
			mov = Random.Range(-0.04f,0.04f)*1;
			yield return new WaitForSeconds (2.0f);
		}
	}
}
