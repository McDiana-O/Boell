using UnityEngine;
using UnityEngine.UI;

public class SwipeHandler : MonoBehaviour
{
	public AudioSource swipeSound;
	public Text Debugtext1;
	public Text Debugtext2;
	public float minMovement = 20.0f;
	public bool sendUpMessage = true;
	public bool sendDownMessage = true;
	public bool sendLeftMessage = true;
	public bool sendRightMessage = true;
	public GamePlay11 _gamePlay11;
	private Vector3[] Direcciones= new Vector3[6];
	//private Vector2 StartPos;
	private int SwipeID = -1;
	public string afterNameRoad;
	void Start(){
		//Debugtext1.text="";
		//Debugtext2.text="";
		Direcciones [0] = new Vector3(0.1f,0,0);
		Direcciones [1] = new Vector3(-0.1f,0,0);
		Direcciones [2] = new Vector3(0.1f,0.1f,0);
		Direcciones [3] = new Vector3(-0.1f,0.1f,0);
		Direcciones [4] = new Vector3(0.1f,-0.1f,0);
		Direcciones [5] = new Vector3(-0.1f,-0.1f,0);
		_gamePlay11=GameObject.FindGameObjectWithTag("almadelJuego").GetComponent<GamePlay11>();
	}

	void Update ()
	{
		if (_gamePlay11.mystate == GamePlay11.stateGameMini11.Jugando && !_gamePlay11.isPausing) {
			if (Input.touches.Length > 0) {
				Touch T = Input.touches [0];
				RaycastHit2D hitInfo = Physics2D.Raycast (Camera.main.ScreenToWorldPoint (T.position), Vector2.zero);
				//var P = T.position;
				if (T.phase == TouchPhase.Began) {
					SwipeID = T.fingerId;
					//StartPos = P;
					if (hitInfo) {
						hitInfo.rigidbody.AddForce (Direcciones [Random.Range (0, 6)]);
						swipeSound.Play ();
						//_changeSprite = hitInfo.transform.GetComponent<changeSprite>();
						//afterNameRoad=_changeSprite.nameOfFather;
					}
				} else if (T.fingerId == SwipeID) {
					//var delta = P - StartPos;
					if (T.phase == TouchPhase.Moved) {
						if (hitInfo) {
							//Debugtext2.text = "Objeto=" + hitInfo.transform.gameObject.tag;
							//hitInfo.rigidbody.AddForce (delta * delta.magnitude);
							//swipeSound.Play();
							SwipeID = -1;
						}
					} else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended) {
						SwipeID = -1;
					}
				} else if (T.phase == TouchPhase.Ended) {
					SwipeID = -1;
				}
				// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
				/*if(hitInfo && SwipeID!=-1){
				var delta = P - StartPos;
				Debugtext2.text="Objeto="+hitInfo.transform.gameObject.tag;
				hitInfo.rigidbody.AddForce(delta*delta.magnitude);
				SwipeID = -1;
			}*/
			}
		}
	}    
	
	void OnSwipeRight(){
		//Debugtext1.text="SwipeRight";
	}
	
	void OnSwipeLeft(){
		//Debugtext1.text="SwipeLeft";
	}
	
	void OnSwipeUp(){
		//Debugtext1.text="SwipeUp";
	}
	
	void OnSwipeDown(){
		//Debugtext1.text="SwipeDown";
	}
	void OnTap(){
		//Debugtext1.text="onTap";
	}
	
}

