using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Game1Touch : MonoBehaviour {
	//public Text debugText;
	public Vector2 coordenadas;
	public Vector3 coordScreen;
	public GameObject sierra;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {


#if UNITY_STANDALONE || UNITY_EDITOR
		coordenadas= Camera.main.ScreenToWorldPoint( Input.mousePosition);

		sierra.transform.position=coordenadas;

		if (Input.GetMouseButtonDown (0)) {

			Vector2 pos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
			RaycastHit2D hitInfo = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos), Vector2.zero);
			// RaycastHit2D can be either true or null, but has an implicit conversion to bool, so we can use it like this
			if(hitInfo)
			{

				//Debug.Log( hitInfo.transform.gameObject.name );
				// Here you can check hitInfo to see which collider has been hit, and act appropriately.
			}
		}
#endif

#if UNITY_ANDROID
		if(Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved){
			//	Vector2 pos =Input.GetTouch(0).position;
			//RaycastHit2D hitInfo=Physics2D.Raycast(Camera.main.ScreenToWorldPoint(pos),Vector2.zero);
			//sierra.transform.position=pos;
			Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
			sierra.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
			/*if(hitInfo.transform.gameObject.name=="Sierra");
			{
				Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
				sierra.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
				debugText.text="Coordenadas: "+ Camera.main.ScreenToWorldPoint(pos).ToString();
			
			}*/
		
			/*Ray ray = Camera.main.ScreenPointToRay(new Vector3(Input.GetTouch (0).position.x, Input.GetTouch (0).position.y, 500));
			Debug.DrawRay(ray.origin, ray.direction * 1000, Color.yellow);
			RaycastHit hit;
			if(Physics.Raycast(ray, out hit, 100)) {
				if(hit.collider.name == "Sierra") {
					Vector3 worldPos = Camera.main.ScreenToWorldPoint(Input.GetTouch (0).position);
					sierra.transform.position = new Vector3 (worldPos.x, worldPos.y, 0);
				}
			}*/	
		}

		//else{sierra.transform.position=new Vector3(-1000,222,0);}

			/*if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved) {
				Vector2 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
				sierra.transform.Translate(-touchDeltaPosition.x * speed, -touchDeltaPosition.y * speed, 0);
			}*/
#endif

	}
}
