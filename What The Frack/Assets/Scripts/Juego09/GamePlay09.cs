using UnityEngine;
using System.Collections;

public class GamePlay09 : MonoBehaviour {
	public GameObject _grieta;
	public Vector2[] iniPosition;
	public float time;
	int numRandom=0;
	public GameObject _tempGrieta;
	public int totalExplosivos;
	public int nivel;
	// Use this for initialization
	void Start () {
		//everySeconds = 0.5f;
		time = 4.5f;
		totalExplosivos = 14;
		StartCoroutine (CreaGrietas());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator CreaGrietas()
	{
		//timer.text = time.ToString();
		while (time>0.0f/* && totalExplosivos!=0*/){
			yield return new WaitForSeconds(0.3f);
			numRandom = Random.Range (1, 101);
			numRandom = numRandom >49?1:0;

			_tempGrieta=(GameObject)Instantiate(_grieta,iniPosition[numRandom],Quaternion.identity);
			_tempGrieta.transform.localScale = numRandom==1?new Vector3(0.7577969f,0.7577969f,0.7577969f):new Vector3(0.7577969f,-0.7577969f,0.7577969f);
			_tempGrieta.GetComponent<MoveExplosivo> ().RunExplosivo(nivel);
			time-=0.3f;
			//totalExplosivos--;
		}

			

			//timer.text = time.ToString();

	}
}
