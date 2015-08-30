using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GamePlay14 : MonoBehaviour {

	private int gender;
	public float time;
	public Sprite Dude;
	public Sprite Gurl;
	public GameObject Person;
	public GameObject GirlStuff;
	public GameObject GirlStuff2;
	public GameObject MenuWinLose;
	//private GameObject [] Organs;
	bool win;
	//este minijuego dura 8 seg en los 3 niveles
	private timedown _timeDown;

	// Use this for initialization
	void Start () {
		gender = Random.Range (0, 2);
		win = false;
		_timeDown = GameObject.FindGameObjectWithTag ("Clock").GetComponent<timedown> ();
		//Organs[] = 
		Debug.Log (gender);
		if (gender == 0) {
			Person.GetComponent<Image> ().sprite = Dude;
			GirlStuff.SetActive(false);
			GirlStuff2.SetActive(false);
		}
		if (gender == 1) {
			Person.GetComponent<Image> ().sprite = Gurl;
		}
		_timeDown.ActivateClock = true;
		StartCoroutine (SetElements ());
	}
	
	// Update is called once per frame
	void Update () {

	}
	//gameObject.SetActive (true);

	IEnumerator SetElements(){
		while (time > 0 && !win) {
			time-=0.2f;

			if(time > 1){

				/*if (gender == 0) {
					Instantiate(Dude,new Vector3(this.transform().x,this.transform().y,this.transform().z), Quaternion.identity);
				}
				if (gender == 1) {
					Instantiate(Gurl,new Vector3(this.transform().x,this.transform().y,this.transform().z), Quaternion.identity);
				}*/


				}
				yield return new WaitForSeconds(0.2f);
			}
		if (time <= 0){
			MenuWinLose.SetActive(true);
			MenuWinLose.GetComponent<ScriptMenuWinLose>().SetMenssageWinorLose(ScriptMenuWinLose.tipoMensaje.Perdio);
		}
	}
	
}
