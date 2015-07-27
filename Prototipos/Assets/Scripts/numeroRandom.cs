using UnityEngine;
using System.Collections;

public class numeroRandom : MonoBehaviour {
	int[] tempNumeros;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public int[] randomArray(int tam){
		int[] result= new int[tam];

		for(int i=0;i<tam;i++){
			result[i]=Random.Range(0,tam+1);
		}
			
		return result;
	} 

}
