using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlphaRed : MonoBehaviour {
	Image _thisImage;
	public bool animaDown=false;
	public float waitTime = 1.0f;
	public bool activateAnimacion = false;
	private float time=1;
	// Use this for initialization
	void Start () {
		_thisImage = this.GetComponent<Image> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activateAnimacion) {
			if (animaDown == true) {
				//thisObjet.color.a=50;
				_thisImage.material.color = new Color (1f, 1f, 1f, (_thisImage.material.color.a - (5.0f / waitTime * Time.deltaTime)));
			} else {
				_thisImage.material.color = new Color (1f, 1f, 1f, (_thisImage.material.color.a + (5.0f / waitTime * Time.deltaTime)));
			}
			
			if (_thisImage.material.color.a < 0.3) {
				animaDown = false;
			} else if (_thisImage.material.color.a > 1) {
				animaDown = true;
			}
		}
		if (time <= 0) {
			activateAnimacion=false;
			gameObject.SetActive(false);
			//gameObject.SetActive=false;
		}
	}
	public void SetActivateAlphaRed(){
		time = 1;
		//gameObject.SetActive=true;
		gameObject.SetActive(true);
		activateAnimacion = true;
		StartCoroutine (countdown());
	}
	IEnumerator countdown()
	{
		//timer.text = time.ToString();
		while (time >0)
		{
			yield return new WaitForSeconds(1.0f);
			time -= 1;
			//timer.text = time.ToString();
		}
	}
}
