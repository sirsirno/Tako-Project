using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class UIManager : MonoBehaviour
{
    public static UIManager UIinstance;

    public GameObject gameMenu;
    public GameObject inGameMenu;
    public GameObject optionMenu;
    public GameObject creditMenu;
    public GameObject quitMenu;
    public Text titleText;
    public Image titleTextImage;

    public Button BGM_Button;
    public Button FX_Button;

    public Sprite[] optionButtonImages;

    [SerializeField]
    private int maxTimerValue;
    
    private void Awake()
    {

        if(UIinstance != null)
        {
            Debug.LogError("UI매니저 아 하지말라고");

        }
        else
        {
            UIinstance = this;
        }

        gameMenu = GameObject.FindGameObjectWithTag("GameMunu").gameObject;
        inGameMenu = GameObject.FindGameObjectWithTag("InGameUI").gameObject;
        titleText.gameObject.SetActive(false);
        titleTextImage.gameObject.SetActive(true);

    }

    private void Start()
    {
        inGameMenu.SetActive(false);
    }

    public void OnPlayButton()
    {
        
        GameManager.instance.GameStart();
        StartCoroutine(GameMapSetting.instance.MapSetLoop());
        gameMenu.gameObject.SetActive(false);
        if (gameMenu != null && inGameMenu != null)
        {

            inGameMenu.SetActive(true);
            titleText.gameObject.SetActive(true);
            titleTextImage.gameObject.SetActive(false);
        }
      
       
  
    }
  
   
  
    public void OnOptionButton()
    {
        optionMenu.SetActive(!optionMenu.activeInHierarchy);
        titleTextImage.gameObject.SetActive(!titleTextImage.gameObject.activeInHierarchy);


    }

    public void OnCreditButton()
    {
        creditMenu.SetActive(!creditMenu.activeInHierarchy);
        titleTextImage.gameObject.SetActive(!titleTextImage.gameObject.activeInHierarchy);
    }

    public void OnQuitButton()
    {
        quitMenu.SetActive(!quitMenu.activeInHierarchy);
        titleTextImage.gameObject.SetActive(!titleTextImage.gameObject.activeInHierarchy);
    }

    public void OnQuitYes()
    {
        Application.Quit();
    }

    

}
