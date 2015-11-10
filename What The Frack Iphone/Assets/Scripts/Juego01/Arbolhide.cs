using UnityEngine;
using System.Collections;

public class Arbolhide : MonoBehaviour {
	//private Animator arbolAnim;
	public AlmaJuego juegosoul;
	private SpriteRenderer mySpriteRender;
	public Sprite spriteTreeCutting;
	public Sprite spriteAplanado;
	public Sprite spriteCementado;
	enum stateTree{Complete,Cutting,Aplanado,Cementado};
	stateTree myStateTree;
	// Use this for initialization
	void Start () {

		//arbolAnim=gameObject.GetComponent<Animator> ();
		juegosoul = GameObject.FindGameObjectWithTag ("almadelJuego").GetComponent<AlmaJuego>();
		mySpriteRender = gameObject.GetComponent<SpriteRenderer> ();
		myStateTree = stateTree.Complete;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnCollisionEnter2D(Collision2D coll) {

		if (coll.gameObject.name == "Sierra") {
			if(myStateTree.Equals(stateTree.Complete)&& juegosoul.MyStateGame.Equals(AlmaJuego.stateGame.Taladora)){
				juegosoul.totalArboles=juegosoul.totalArboles-1;
				mySpriteRender.sprite = spriteTreeCutting;
				myStateTree= stateTree.Cutting;
			}
			else if(myStateTree.Equals(stateTree.Cutting)&& juegosoul.MyStateGame.Equals(AlmaJuego.stateGame.Aplanadora)){
				juegosoul.totalArboles=juegosoul.totalArboles-1;
				mySpriteRender.sprite = spriteAplanado;
				myStateTree= stateTree.Aplanado;
			}
			else if(myStateTree.Equals(stateTree.Aplanado)&& juegosoul.MyStateGame.Equals(AlmaJuego.stateGame.Mezcladora)){
				juegosoul.totalArboles=juegosoul.totalArboles-1;
				mySpriteRender.sprite = spriteCementado;
				myStateTree= stateTree.Cementado;
			}
		}

	}
}
