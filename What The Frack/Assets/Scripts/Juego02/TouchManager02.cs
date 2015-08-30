using UnityEngine;
using UnityEngine.UI;


public class TouchManager02 : MonoBehaviour {
	
	public GamePlay02 _gamePlay02; 
	public float minMovement = 20.0f;
	public GameObject MessageTarget = null;
	
	private Vector2 StartPos;
	private int SwipeID = -1;
	
	public int afterIDFather=-1;

	private changeRoad _changeRoad;
	private changeCircle _changeCircle;

	public GameObject[] roadHorizontal1;
	public GameObject[] roadHorizontal2;
	public GameObject[] roadVertical1;
	public GameObject[] roadVertical2;
	void Awake(){
		_gamePlay02 = this.GetComponent<GamePlay02> ();
	}

	void Update ()
	{

		if (MessageTarget == null) 
		{
			MessageTarget = gameObject;
		}

		foreach (var T in Input.touches)
		{
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(T.position), Vector2.zero);

			if(!_gamePlay02.isTouchPoint){
				var P = T.position;
				if (T.phase == TouchPhase.Began && SwipeID == -1)
				{
					//Debugtext2.text="Inicio "+ T.fingerId;
					SwipeID = T.fingerId;
					StartPos = P;
					
					if(hitInfo)
					{
						_changeRoad = hitInfo.transform.GetComponent<changeRoad>();
						afterIDFather =_changeRoad.ID_Father;
						EnabledCollider();
					}
				}
				
				else if (T.fingerId == SwipeID)
				{
					
					var delta = P - StartPos;
					if (T.phase == TouchPhase.Moved && delta.magnitude > minMovement)
					{
						//Debugtext2.text="Se movio "+ T.fingerId;
						SwipeID = -1;
						
					}
					else if (T.phase == TouchPhase.Canceled || T.phase == TouchPhase.Ended)
					{
						//Debugtext2.text="Murio "+ T.fingerId;
						SwipeID = -1;
						//MessageTarget.SendMessage("OnTap", SendMessageOptions.DontRequireReceiver);
					}
					
					
				}
				else if ( T.phase == TouchPhase.Ended)
				{
					//Debugtext2.text="Termino: "+ T.fingerId;
					_gamePlay02.checkFullRoad(afterIDFather);
					afterIDFather=-1;
				}
				
				
				// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
				if(hitInfo)
				{
					//Debug.Log( hitInfo.transform.gameObject.name );
					//Debugtext1.text= hitInfo.transform.gameObject.name;
					_changeRoad = hitInfo.transform.GetComponent<changeRoad>();
					
					if(_changeRoad.ID_Father==afterIDFather)
					{
						_changeRoad.CountRoads();
						_changeRoad.ChangeLineToRoad();
					}
					
					// Here you can check hitInfo to see which collider has been hit, and act appropriately.
				}
			}
			//SecondPart

			else if(_gamePlay02.totalMachines<_gamePlay02.numpoint){

				if(hitInfo)
				{
					_changeCircle = hitInfo.transform.GetComponent<changeCircle>();
					_changeCircle.changeMachine(_gamePlay02.machines[_gamePlay02.totalMachines]);

				}
			}


		}
	}  

	void EnabledCollider(){
		int i;
		if(afterIDFather==0){
			for(i=0;i<roadHorizontal1.Length;i++){
				roadHorizontal1[i].GetComponent<BoxCollider2D>().enabled=true;
			}
		}

		else if(afterIDFather==1){
			for(i=0;i<roadHorizontal2.Length;i++){
				roadHorizontal2[i].GetComponent<BoxCollider2D>().enabled=true;
			}
		}

		else if(afterIDFather==2){
			for(i=0;i<roadVertical1.Length;i++){
				roadVertical1[i].GetComponent<BoxCollider2D>().enabled=true;
			}
		}

		else if(afterIDFather==3){
			for(i=0;i<roadVertical2.Length;i++){
				roadVertical2[i].GetComponent<BoxCollider2D>().enabled=true;
			}
		}
	}
}
