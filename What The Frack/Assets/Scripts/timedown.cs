using UnityEngine;
using System.Collections;
using UnityEngine.UI; // Required when Using UI elements.

public class timedown : MonoBehaviour {

	public Image cooldown;
	public bool coolingDown;
	public float waitTime = 0.0f;
	//public GamePlay02 _gamePlay02;
	public bool ActivateClock = false;
	public bool isTimeOver;
	private float debugTime;
	// Use this for initialization
	// Use this for initialization
	void Start () {
		debugTime = this.waitTime;
	}
	// Update is called once per frame
	void Update () 
	{
		if (ActivateClock) 
		{
			if (coolingDown == true)
			{
				Debug.Log(waitTime * Time.deltaTime);
				//Reduce fill amount over 30 seconds
				cooldown.fillAmount -= 1.0f/waitTime * Time.deltaTime;
			}
			if (cooldown.fillAmount <= 0) {
				isTimeOver=true;
			}
		}

	}
	public void StopRelog()
	{

	}
}
