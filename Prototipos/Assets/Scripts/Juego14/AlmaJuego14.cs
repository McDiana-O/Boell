using UnityEngine;
using System.Collections;

public class AlmaJuego14 : MonoBehaviour {

	private GameObject Organo;
	private Animation anim;
	//private int randoms;
	//public enum stateGame{Parpadea,NoParpadea};
	//public stateGame MyStateGame;
	//private GameObject ranOrg;
	//private int numOrganos = 5;

	Touch myTouch;
	private int tapCount;



	// Use this for initialization
	//void RandomAnim () {
		
		//randoms = anim.Play (Random.Range (0, 5));
	//}
	
	void Start() {
		//MyStateGame = stateGame.NoParpadea;
		anim = Organo.GetComponent<Animation> ();
		StartCoroutine (DelayAnim ());
	}

	void Update(){
		StopAnim ();
	}

	void StopAnim(){

			anim.Stop();
	}


	IEnumerator DelayAnim() {
		yield return new WaitForSeconds(5);
	//	if (anim.isPlaying) {
	//		anim.Stop();
	//	}
	//	print(Time.time);
	}


}
