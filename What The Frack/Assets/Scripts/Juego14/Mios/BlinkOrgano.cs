using UnityEngine;
using System.Collections;

public class BlinkOrgano : MonoBehaviour {

	public bool animaDown=false;
	public float waitTime = 1.0f;
	public SpriteRenderer thisObjet;
	public bool activateAnimacion = false;
	public enum Estado{Begin,Sano,TimeForSick,Enfermo};
	public Estado miEstado;
	public Sprite[] _spritesOrganos;
	public bool Enferma=false; 
	private float timeForSick=0.0f;
	private float[] timeToStartAgain;
	private int IdToStart=0;
	bool OnceTime=true;
	float timePrev=0;
	// Use this for initialization
	void Start () {
		thisObjet = this.GetComponent<SpriteRenderer> ();
		timeToStartAgain = new float[]{3.5f,4.0f,4.5f,5.0f,5.25f}; 
		StartCoroutine (countUp());
		miEstado = Estado.Begin;
	}

	// Update is called once per frame
	void Update () 
	{
		if (timeForSick-timePrev>=timeToStartAgain[IdToStart] && miEstado==Estado.TimeForSick) {
			SetEnfermo ();
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
		else if (miEstado==Estado.Sano && OnceTime) {
			activateAnimacion=false;
			thisObjet.sprite = _spritesOrganos[0];
			thisObjet.color = new Color(1f,1f,1f);
			miEstado= Estado.TimeForSick;
			OnceTime=false;
		}
	}

	public void SetEnfermo(){
		activateAnimacion=true;
		miEstado = Estado.Enfermo;
	}
	public void  SetSano(){
		timePrev = timeForSick;
		IdToStart = Random.Range(0,5);
		OnceTime=true;
		miEstado = Estado.Sano;
	}

	IEnumerator countUp()
	{	
		while (timeForSick <35)
		{
			yield return new WaitForSeconds(0.1f);
			timeForSick += 0.1f;
		}

	}
}
