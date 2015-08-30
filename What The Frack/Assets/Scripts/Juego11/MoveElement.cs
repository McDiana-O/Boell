using UnityEngine;
using System.Collections;

public class MoveElement : MonoBehaviour {
	public float translation;
	public float position;
	void Start () {
		//translation = 0.1f+Random.value/8;
		translation = 0.1f;
		}
	
	// Update is called once per frame
	void Update () {
		this.gameObject.transform.Translate (0.0f,translation,0.0f);
	} 
}
