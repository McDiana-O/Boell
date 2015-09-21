using UnityEngine;
using System.Collections;

public class BlinkOrgano : MonoBehaviour {

	public bool animaDown=false;
	public float waitTime = 1.0f;
	public SpriteRenderer thisObjet;
	public bool activateAnimacion = false;
	public enum Estado{Sano,Enfermo};
	public Estado miEstado;
	public Sprite[] _spritesOrganos;
	public bool Enferma=false; 
	public float timeForSick=0.8f;
	bool FirstTime=false;
	// Use this for initialization
	void Start () {
		thisObjet = this.GetComponent<SpriteRenderer> ();
	}

	// Update is called once per frame
	void Update () 
	{
		if (Enferma) {
			SetEnfermo ();
		} else {
			miEstado=Estado.Sano;
		}
		if (activateAnimacion && miEstado == Estado.Enfermo) {
			thisObjet.sprite = _spritesOrganos[1];
			if (animaDown == true) {
				thisObjet.color = new Color (1f, (thisObjet.color.b - (1.0f / waitTime * Time.deltaTime)), (thisObjet.color.g - (1.0f / waitTime * Time.deltaTime)));
			} else {
				thisObjet.color = new Color (1f, (thisObjet.color.b + (1.0f / waitTime * Time.deltaTime)), (thisObjet.color.g + (1.0f / waitTime * Time.deltaTime)));
			}
			
			if (thisObjet.color.g < 0.0) {
				animaDown = false;
			} else if (thisObjet.color.g >= 1.0) {
				animaDown = true;
			}
		}
		else if (miEstado==Estado.Sano) {
			activateAnimacion=false;
			thisObjet.sprite = _spritesOrganos[0];
			thisObjet.color = new Color(1f,1f,1f);
			timeForSick=0.8f;
			if(!FirstTime){
				FirstTime=true;
				StartCoroutine (countdown());
			}
		}
	}

	public void SetEnfermo(){
		activateAnimacion=true;
		miEstado = Estado.Enfermo;
	}

	IEnumerator countdown()
	{
		while (timeForSick >0 && miEstado==Estado.Sano)
		{
			yield return new WaitForSeconds(0.2f);
			timeForSick -= 0.2f;
		}
	}
}
