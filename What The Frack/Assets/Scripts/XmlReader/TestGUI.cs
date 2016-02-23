/*
This example script demonstrates how to use the Unity Multiple Language Support Lang class in a simple GUI.
The accompanying lang.xml file should be placed into your project's Assests folder.
 
-Adam T. Ryder
C# version by O. Glorieux
*/

using System.IO;
//using UnityEditor;

using UnityEngine;
using UnityEngine.UI;

public class TestGUI : MonoBehaviour 
{
	
	private Lang LMan;
	private string currentLang = "English";
	public Text texto1;
	public void OnEnable()
	{
		/*
    Initialize the Lang class by providing a path to the desired language XML file, a default language
    and a boolean to indicate if we are operating on an XML file located from a downloaded resource or local.
    True if XML resource is on the web, false if local
 
    If initializing from a web based XML resource you'll need to supply the text of the downloaded resource in placed
    of the path.
 
    web example:
    var wwwXML : WWW = new WWW("http://www.exampleURL.com/lang.xml");
    yield wwwXML;
     
    LMan = new Lang(wwwXML.text, currentLang, true);
    */
		//LMan = new Lang(Path.Combine(Application.dataPath, "lang.xml"), currentLang, false);
		//LMan = new Lang(Path.Combine(Application.dataPath, "inter.xml"), currentLang, false);
		//LMan = new Lang(Path.Combine(getPath(), "menu.xml"), currentLang, false);
		LMan = new Lang("menu", currentLang, false);
	}
	void Start () {
		//texto1.text=LMan.getString("creditmenu_title") + "\n\n\n" + LMan.getString("creditmenu_direccion");

		//texto1.text="h:"+Application.persistentDataPath+"\n\n...."+Application.dataPath+"\n\n"+LMan.getString("creditmenu_title") + "\n\n\n" + LMan.getString("creditmenu_direccion");
	}
	void Update () {
		//texto1.text=LMan.getString("minigame_01_title") + "\n\n\n" + LMan.getString("minigame_02_title");
		texto1.text="Rutas:"+Application.persistentDataPath+"\n\n...."+Application.dataPath+"\n\nPath: "+Lang.textopaht;
	}
	private string getPath(){
		#if UNITY_EDITOR
		return Application.dataPath +"/Resources/";
		#elif UNITY_ANDROID
		return Application.dataPath +"/";
		//return Application.persistentDataPath+"/";
		#elif UNITY_IPHONE
		return Application.persistentDataPath+"/";
		#else
		return Application.dataPath +"/";
		#endif
	}
	public void OnGUI()
	{
		/*
    To access a string in the currently set language use the Lang class' getString function with the string name identifier supplied to it.
    */
		GUI.Label(new Rect(0, 0, 800, 450), LMan.getString("minigame_01_title") + "\n\n\n" + LMan.getString("minigame_02_title"));
		
		if (GUI.Button(new Rect(0, 450 - 24, 800, 24), "Language:  " + currentLang))
		{
			if (currentLang == "English")
			{
				currentLang = "Spanish";
			}
			else if (currentLang == "Spanish")
			{
				currentLang = "German";
			}
			else
			{
				currentLang = "English";
			}
			
			/*
        To switch languages after the Lang class has been initialized call the setLanguage function
        and provide a path to the desired XML resource and the desired language.
     
        If the XML resource is located on the web you'll need to use the WWW class to download the resource
        and then supply the text of the downloaded resource in place of the path to the Lang class' setLanguageWeb function.
     
        web example:
        var wwwXML : WWW = new WWW("http://www.exampleURL.com/lang.xml");
        yield wwwXML;
     
        LMan.setLanguageWeb(wwwXML.text, currentLang);
        */
			//LMan.setLanguage(Path.Combine(getPath(), "menu.xml"), currentLang);
			LMan.setLanguage("menu", currentLang);
		}
	}
}
