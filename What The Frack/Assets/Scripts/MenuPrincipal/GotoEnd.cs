using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GotoEnd : MonoBehaviour {

	public GameObject[] UIMenuMapa;
	public GameObject[] UISalir;
    private GamePlayerPrefs _playerPrefs;
    // Use this for initialization
    void Start () {
        _playerPrefs = GameObject.FindGameObjectWithTag("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
    }
	
	// Update is called once per frame
	void Update () {
	
	}
	public void SetActivateUIMenuGame(bool value){
		for (int i=0; i<UIMenuMapa.Length; i++) {
			UIMenuMapa[i].SetActive(value);
		}
	}

	public void SetActivateUiSalir(bool value){
		for (int i=0; i<UISalir.Length; i++) {
			UISalir[i].SetActive(value);
            if (UISalir[i].name == "txtSalir") {
                UISalir[i].GetComponent<Text>().text= _playerPrefs.Lgui.getString("exitscreen_title");
            }
		}
	}

	public void AksToQuit(){
		SetActivateUIMenuGame (false);
		SetActivateUiSalir (true);
	}
	public void NoSalir(){
		SetActivateUIMenuGame (true);
		SetActivateUiSalir (false);
	}
	public void SiSalir(){
		Application.Quit ();
	}
}
