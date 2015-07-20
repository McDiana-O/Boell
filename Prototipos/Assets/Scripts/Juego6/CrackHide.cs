using UnityEngine;
using System.Collections;

public class CrackHide : MonoBehaviour {

	public enum stateCrack{Grieta,Sellado};
	public stateCrack myState;
	private AlmaJuego6 juegosoul6;
	public Sprite spriteSellado;
	private SpriteRenderer mySpriteRender;

	// Use this for initialization
	void Start () {
		juegosoul6 = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<AlmaJuego6>();
		myState=stateCrack.Grieta;
		mySpriteRender = gameObject.GetComponent<SpriteRenderer> ();
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ChangeToSellado(){
		myState=stateCrack.Sellado;
		mySpriteRender.sprite = spriteSellado;
		transform.localScale += new Vector3(1.5F, 1.5F, 0);
		juegosoul6.SendMessage("sellando");
	}
}
