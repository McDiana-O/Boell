using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TouchGameDiez : MonoBehaviour {
	public int tapsPerSecond;
	public Text timer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		getTapsPerSecond ();
	}


	void getTapsPerSecond(){
		#if UNITY_ANDROID

		if (Input.touchCount > 0){
		Touch myTouch = Input.GetTouch(0);
		tapsPerSecond= myTouch.tapCount;
		timer.text= "Son:" + tapsPerSecond.ToString();
		/*for(int i = 0; i < Input.touchCount; i++)
		{
			tapsPerSecond= myTouches[i].tapCount;
		}*/
		}
		#endif
	}
}
