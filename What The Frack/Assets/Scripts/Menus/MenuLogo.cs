using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MenuLogo : MonoBehaviour {

    private GamePlayerPrefs _playerPrefs;
    public Image imgIdiom;
    public Sprite[] spritesIdiom;
    public Button btnEnter;
    private Image imgEnter;
    private SpriteState spriteStateEnter;
    public Sprite[] spritesEnter;
    // Use this for initialization
    void Awake()
    {
        _playerPrefs = GameObject.FindGameObjectWithTag("GamePlayerPrefs").GetComponent<GamePlayerPrefs>();
        _playerPrefs.SoundMuteApply();
    }
    void Start () {
        imgEnter = btnEnter.GetComponent<Image>();
        CheckIdioms(PlayerPrefs.GetString("Language"));
    }

	void Update () {

    }
    public void CheckIdioms() {
        
        if (_playerPrefs.Language == "English")
        {
            imgIdiom.sprite = spritesIdiom[0];
            imgEnter.sprite = spritesEnter[0];
            spriteStateEnter.highlightedSprite = spritesEnter[0];
            spriteStateEnter.pressedSprite = spritesEnter[1];
            spriteStateEnter.disabledSprite = spritesEnter[1];
            
        }
        else if (_playerPrefs.Language == "Spanish")
        {
            imgIdiom.sprite = spritesIdiom[1];
            imgEnter.sprite = spritesEnter[2];
            spriteStateEnter.highlightedSprite = spritesEnter[2];
            spriteStateEnter.pressedSprite = spritesEnter[3];
            spriteStateEnter.disabledSprite = spritesEnter[3];
        }
        else if (_playerPrefs.Language == "German")
        {
            imgIdiom.sprite = spritesIdiom[2];
            imgEnter.sprite = spritesEnter[4];
            spriteStateEnter.highlightedSprite = spritesEnter[4];
            spriteStateEnter.pressedSprite = spritesEnter[5];
            spriteStateEnter.disabledSprite = spritesEnter[5];
        }
        btnEnter.spriteState = spriteStateEnter;
    }
    public void CheckIdioms(string Value)
    {

        if (Value == "English")
        {
            imgIdiom.sprite = spritesIdiom[0];
            imgEnter.sprite = spritesEnter[0];
            spriteStateEnter.highlightedSprite = spritesEnter[0];
            spriteStateEnter.pressedSprite = spritesEnter[1];
            spriteStateEnter.disabledSprite = spritesEnter[1];
        }
        else if (Value == "Spanish")
        {
            imgIdiom.sprite = spritesIdiom[1];
            imgEnter.sprite = spritesEnter[2];
            spriteStateEnter.highlightedSprite = spritesEnter[2];
            spriteStateEnter.pressedSprite = spritesEnter[3];
            spriteStateEnter.disabledSprite = spritesEnter[3];
            Debug.Log("Español");
        }
        else if (Value == "German")
        {
            imgIdiom.sprite = spritesIdiom[2];
            imgEnter.sprite = spritesEnter[4];
            spriteStateEnter.highlightedSprite = spritesEnter[4];
            spriteStateEnter.pressedSprite = spritesEnter[5];
            spriteStateEnter.disabledSprite = spritesEnter[5];
            Debug.Log("Aleman");
        }
        btnEnter.spriteState = spriteStateEnter;
    }

}
