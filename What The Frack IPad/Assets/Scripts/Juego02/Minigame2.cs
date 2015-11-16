using UnityEngine;
using System.Collections;

public class Minigame2 : MonoBehaviour {
	public int[] pointID;
	public GameObject[] roads;
	public GameObject[] points;
	//esta variable va ser  global
	public int nivel=1,numroads=2,numpoint=2;
	// Use this for initialization
	void Start () {
		switch (nivel) {
		
		case 1:
			numroads=2;
			numpoint=2;
			break;
		case 2:
			numroads=3;
			numpoint=3;
			break;
		case 3:
			numroads=4;
			numpoint=5;
			break;
		}

		pointID = NumerosRandom.randomArray (4);

		for (int i=0;i<numroads;i++)
		{
			roads[pointID[i]].SetActive(true);
		}
		pointID = NumerosRandom.randomArray (9);
		for (int i=0;i<numpoint;i++)
		{
			points[pointID[i]].SetActive(true);
			points[pointID[i]] .GetComponent<AlphaAnimacion>().activateAnimacion=true;
		}

	}
	
	// Update is called once per frame
	void Update () {
	
	}

}
