using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class AlphaRed : MonoBehaviour {
	public bool animaDown=false;
	public float waitTime = 1.0f;
	public bool activateAnimacion = false;
	private float time=1;
	public AudioSource _SFX;
	public AudioClip _Alarma;
	public SpriteRenderer thisObjet;
	// Use this for initialization
	void Start () {
		thisObjet = this.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (activateAnimacion) {
			if (animaDown == true) {
				//thisObjet.color.a=50;
				thisObjet.material.color = new Color (1f, 1f, 1f, (thisObjet.material.color.a - (5.0f / waitTime * Time.deltaTime)));
			} else {
				thisObjet.material.color = new Color (1f, 1f, 1f, (thisObjet.material.color.a + (5.0f / waitTime * Time.deltaTime)));
			}
			
			if (thisObjet.material.color.a < 0.3) {
				animaDown = false;
			} else if (thisObjet.material.color.a > 1) {
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
		_SFX.PlayOneShot (_Alarma);
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
