using UnityEngine;
using System.Collections;

public class Game6Touch : MonoBehaviour {
	public Vector2 coordenadas;
	public Vector3 coordScreen;
	private GameObject tempCrack;
	private CrackHide tempCrackHide;

	private AlmaJuego6 juegosoul6;


	Touch myTouch;
	private int tapCount;
	// Use this for initialization
	void Start () {
		juegosoul6 = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<AlmaJuego6>();
	}
	
	// Update is called once per frame
	void Update () {
		#if UNITY_ANDROID


		tapCount = Input.touchCount;
		for (int i = 0 ; i < tapCount ; i++ ) {
			 myTouch = Input.GetTouch(i);
			if(tapCount > 0 &&( myTouch.phase == TouchPhase.Began || myTouch.phase == TouchPhase.Moved || myTouch.phase == TouchPhase.Stationary)){
				
				Vector2 pos =myTouch.position;
				
				RaycastHit2D hitInfo=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos),Vector2.zero);
				if (hitInfo){
					tempCrack  = hitInfo.transform.gameObject;
					tempCrackHide = tempCrack.GetComponent<CrackHide>();
					if(tempCrack.tag=="crack" && tempCrackHide.myState ==CrackHide.stateCrack.Grieta && juegosoul6.MyStateGame== AlmaJuego6.stateGame.InGame)
					{
						tempCrackHide.ChangeToSellado();
						
					}
				}

				
			}
			//Do whatever you want with the current touch.
		}
		/*if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Began){
			
			Vector2 pos =Input.GetTouch(0).position;

			RaycastHit2D hitInfo=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos),Vector2.zero);

			tempCrack  = hitInfo.transform.gameObject;
			tempCrackHide = tempCrack.GetComponent<CrackHide>();
			if(tempCrack.tag=="crack" && tempCrackHide.myState ==CrackHide.stateCrack.Grieta && juegosoul6.MyStateGame== AlmaJuego6.stateGame.InGame)
			{
				tempCrackHide.ChangeToSellado();
				
			}
			
		}*/
		#endif
	
	}
}
