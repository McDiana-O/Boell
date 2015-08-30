using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MoveWater : MonoBehaviour {
	public float scrollSpeed = 0.25f;
	RawImage imageWater;
	float offset=0.0f;
	void Start () {
		imageWater = this.gameObject.GetComponent<RawImage> ();
	}
	
	// Update is called once per frame
	void Update () {
		offset += Time.deltaTime * scrollSpeed;
		imageWater.uvRect = new Rect (new Vector2(0.0f,-offset),new Vector2(1.0f,1.0f));
	}
}
