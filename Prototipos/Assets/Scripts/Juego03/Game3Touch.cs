using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game3Touch : MonoBehaviour {

	public Vector2 coordenadas;
	public Vector3 coordScreen;
	//public GameObject sierra;
	private GameObject tempPileton;
	public int tempidPileton;
	public ScripPileton scriptpileton;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		#if UNITY_ANDROID
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){

			Vector2 pos =Input.GetTouch(0).position;
			//debugText.text="Coordenadas: "+ Camera.main.ScreenToWorldPoint(pos).ToString();
			RaycastHit2D hitInfo=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos),Vector2.zero);
			//sierra.transform.position=pos;
			//Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
			//sierra.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
			tempPileton  = hitInfo.transform.gameObject;
			scriptpileton = tempPileton.GetComponent<ScripPileton>();
			if(tempPileton.name=="Pileton1" && scriptpileton.mystate ==ScripPileton.statePileton.drag)
			{
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
				tempPileton.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
				
			}
			else if(tempPileton.name=="Pileton2" && scriptpileton.mystate ==ScripPileton.statePileton.drag)
			{
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
				tempPileton.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
				
			}
			else if(tempPileton.name=="Pileton3" && scriptpileton.mystate ==ScripPileton.statePileton.drag)
			{
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
				tempPileton.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
				
			}

		}
		#endif
	
	}
}
