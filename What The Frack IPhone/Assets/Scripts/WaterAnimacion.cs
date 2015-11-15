using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class WaterAnimacion : MonoBehaviour {

	public float scrollSpeed = 0.03f;
	RawImage imageWater;
	float offset=0.0f;
	void Start () {
		imageWater = this.gameObject.GetComponent<RawImage> ();
	}
	
	// Update is called once per frame
	void Update () {
		offset += Time.deltaTime * scrollSpeed;
		imageWater.uvRect = new Rect (new Vector2(offset,0.0f),new Vector2(1.0f,1.0f));
	}
}
