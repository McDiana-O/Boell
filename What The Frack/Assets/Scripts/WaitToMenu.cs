using UnityEngine;
using System.Collections;

public class WaitToMenu : MonoBehaviour {
	public int time=2;
	// Use this for initialization
	void Start () {
		StartCoroutine (countdown());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator countdown()
	{
		while (time > 0)
		{
			//timer.text = time.ToString();
			time -= 1;
			yield return new WaitForSeconds(1);
		}
		if (time <= 0) {
			Application.LoadLevel("tarjetainformativa");
		}
		
	}
}
