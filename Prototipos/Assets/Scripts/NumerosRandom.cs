using UnityEngine;
using System.Collections;

public class NumerosRandom : MonoBehaviour {
	int[] tempNumeros;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	static public int[] randomArray(int tam){
		int[] result= new int[tam];
		int i, temp, numRandom;
		for(i=0;i<tam;i++){
			//result[i]=Random.Range(0,tam+1);
			result[i]=i;
		}

		for (i=tam-1; i>0; i--) {
			numRandom = Random.Range(0,tam-1);
			temp= result[i];
			result[i]=result[numRandom];
			result[numRandom]=temp;
		}
		for (i=tam-1; i>0; i--) {
			numRandom = Random.Range(0,tam-1);
			temp= result[i];
			result[i]=result[numRandom];
			result[numRandom]=temp;
		}
		return result;
	} 

}
