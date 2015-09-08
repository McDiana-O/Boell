using UnityEngine;
using System.Collections;

public class AlphaAnimacion : MonoBehaviour {
	public bool animaDown=false;
	public float waitTime = 1.0f;
	public SpriteRenderer thisObjet;
	public bool activateAnimacion = false;
	// Use this for initialization
	void Start () {
		thisObjet = this.GetComponent<SpriteRenderer> ();
	}
	

	
	// Update is called once per frame
	void Update () 
	{
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
	}

	public void alpheComplete(){
		thisObjet.material.color = new Color (1f, 1f, 1f, 1f);
		activateAnimacion = false;
	}


}
