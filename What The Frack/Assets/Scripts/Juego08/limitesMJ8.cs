using UnityEngine;
using System.Collections;

public class limitesMJ8 : MonoBehaviour {
	public float yPos = 100.0f;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (this.gameObject.transform.position.y != yPos)
			this.gameObject.transform.position = new Vector3(0.0f,yPos, 0.0f);
	}
}
