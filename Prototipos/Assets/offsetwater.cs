using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class offsetwater : MonoBehaviour {
	public float scrollSpeed = 0.5F;
	Image imageWater;
	float offset=0.25f;
	//public Renderer rend;
	// Use this for initialization
	void Start () {
		//rend = GetComponent<Renderer>();
		imageWater = this.gameObject.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		offset += Time.deltaTime * scrollSpeed;
		Debug.Log (imageWater.material.mainTextureOffset.x );
		if (offset >= 0.5f)
			offset = 0.25f;

		imageWater.material.SetTextureOffset ("_MainTex", new Vector2 (offset, 0));
	}
}
