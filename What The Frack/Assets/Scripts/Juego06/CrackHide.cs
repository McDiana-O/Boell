using UnityEngine;
using System.Collections;

public class CrackHide : MonoBehaviour {

	public enum stateCrack{Hide,Grieta,Sellado};
	public stateCrack myState;
	private AlmaJuego6 juegosoul6;
	private SpriteRenderer mySpriteRender;
	private Animator _animator;
	public GameObject sello;
	public AudioSource _cremallera;

	// Use this for initialization
	void Start () {
		juegosoul6 = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<AlmaJuego6>();
		myState=stateCrack.Hide;
		mySpriteRender = gameObject.GetComponent<SpriteRenderer> ();
		_animator = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		if (gameObject.activeInHierarchy && myState.Equals(stateCrack.Hide)) {
			myState=stateCrack.Grieta;
			_animator.SetInteger("typeCrack",Random.Range(1,4));

		}
	}

	public void ChangeToSellado(){
		myState=stateCrack.Sellado;
		//mySpriteRender.sprite = spriteSellado;
		Instantiate(sello,gameObject.transform.position,Quaternion.identity);
		//transform.localScale += new Vector3(1.5F, 1.5F, 0);
		_cremallera.Play ();
		juegosoul6.SendMessage("sellando");
	}
}
