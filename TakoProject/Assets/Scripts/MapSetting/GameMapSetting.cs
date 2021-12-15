using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameMapSetting : MonoBehaviour
{

    public int ranCount;
    public float speed;
    public float waitChooseMap = 3f;
    public float waitSetupMap = 3f;
    public float waitReset = 3f;
    public GameObject[] gameMaps;
    private Transform mapTrm;
    public GameObject mapLoadingPanel;
    public Image loadingImage;

    public bool isEndLoading = false;


    public GameObject[] playerTutorialObj;




    public static GameMapSetting instance;
    // Start is called before the first frame update

    private void Awake()
    {

        loadingImage.color = new Color(1, 1, 1, 1f);
        isEndLoading = false;

        if (instance != null)
        {
            Debug.LogError("싱글톤 여러개");


        }
        else
        {
            instance = this;
        }
    }
  

    public IEnumerator MapSetLoop()
    {
        yield return StartCoroutine(MapSettingUIPanel());
       
        yield return StartCoroutine(ChooseMap());

        yield return StartCoroutine(ShowMovingTutorial());

  
        //여기다가 게임 시작 라운드 표시할 때, 조작법 알려주는거 만들기. 그거하고 빌드 ㄱㄱ?

       // yield return StartCoroutine(OnMapSetup());
        

    }
    IEnumerator ShowMovingTutorial()
    {
        Image[] imageLists_0 = null;
        Image[] imageLists_1 = null;
        bool isEndAlphaChange = false;
        imageLists_0 = playerTutorialObj[0].gameObject.transform.GetComponentsInChildren<Image>();
        imageLists_1 = playerTutorialObj[1].gameObject.transform.GetComponentsInChildren<Image>();


        for (int i = 0; i < playerTutorialObj.Length; i++)
        {
            playerTutorialObj[i].gameObject.SetActive(true);
        }

        playerTutorialObj[0].gameObject.transform.position =
            new Vector3(playerTutorialObj[0].gameObject.transform.position.x + (playerTutorialObj[0].gameObject.transform.position.x * 1.5f),
            playerTutorialObj[0].gameObject.transform.position.y,
            playerTutorialObj[0].gameObject.transform.position.z);
        playerTutorialObj[1].gameObject.transform.position =
            new Vector3(playerTutorialObj[1].gameObject.transform.position.x - playerTutorialObj[1].gameObject.transform.position.x /4.5f,
            playerTutorialObj[1].gameObject.transform.position.y,
            playerTutorialObj[1].gameObject.transform.position.z);

        yield return new WaitForSeconds(1.5f);

      
        for (int i = 0; i < imageLists_0.Length; i++)
        {
            StartCoroutine(AlphaChange(imageLists_0[i]));
            
        }

        for (int i = 0; i < imageLists_1.Length; i++)
        {

            StartCoroutine(AlphaChange(imageLists_1[i]));
            
        }


        Invoke("SetPositionTuroialObj", 0.45f);
         
        
      
     
        Debug.Log("ㅎㅇ");
      
    }

    void SetPositionTuroialObj()
    {
        playerTutorialObj[0].gameObject.transform.position =
     new Vector3(playerTutorialObj[0].gameObject.transform.position.x - playerTutorialObj[0].gameObject.transform.position.x / 1.5f,
     playerTutorialObj[0].gameObject.transform.position.y,
     playerTutorialObj[0].gameObject.transform.position.z);
        playerTutorialObj[1].gameObject.transform.position =
            new Vector3(playerTutorialObj[1].gameObject.transform.position.x + playerTutorialObj[1].gameObject.transform.position.x / 4.5f,
            playerTutorialObj[1].gameObject.transform.position.y,
            playerTutorialObj[1].gameObject.transform.position.z);

        for (int i = 0; i < playerTutorialObj.Length; i++)
        {
            playerTutorialObj[i].gameObject.SetActive(false);
        }
    }
    public IEnumerator MapSetLoop( int i )
    {
        yield return StartCoroutine(MapSettingUIPanel());

        yield return new WaitForSeconds(2f);
        // yield return StartCoroutine(OnMapSetup());


    }

    public IEnumerator ChooseMap()
    {
        //맵 로딩 구현 
        ranCount = Random.Range(1, 5);

        //여따가 맵 고르는 효과같은거 ㄱㄱ 


        Debug.Log("두구두구두구");

        switch (ranCount)
        {
            case 1:
                // 1번 맵 프리팹 가져오기
                Instantiate(gameMaps[0], mapTrm);
                break;
            case 2:
                // 2번 맵 프리팹 가져오기
                Instantiate(gameMaps[1], mapTrm);
                break;
            case 3:
                // 3번 맵 프리팹 가져오기
                Instantiate(gameMaps[2], mapTrm);
                break;
            case 4:
                // 4번 맵 프리팹 가져오기
                Instantiate(gameMaps[3], mapTrm);
                break;
            case 5:
                // 5번 맵 프리팹 가져오기
                Instantiate(gameMaps[4], mapTrm);
                break;
            default:
                // 기본 맵 프리팹 가져오기
                Instantiate(gameMaps[1], mapTrm);
                break;
        }

        Debug.Log("쨘");


        yield return null ;
    }
    
 

    private IEnumerator MapSettingUIPanel()
    {
        isEndLoading = true;
        ChangePanelState();

        float alpha = 1f;
        yield return new WaitForSeconds(waitReset);


        StartCoroutine(AlphaChange(loadingImage));


        isEndLoading = false;


    }


    private void ChangePanelState()
    {
        mapLoadingPanel.SetActive(!mapLoadingPanel.activeInHierarchy);
    }

   
    private IEnumerator AlphaChange( Image image, float alpha = 1f)
    {
       
        while (true)
        {
            if (alpha > 0f)
            {
                alpha -= Time.deltaTime * 2f;
            }
            else
            {               
                break;
            }

            alpha = Mathf.Clamp(alpha, 0f, 1f);
            if (image == null)
            {
            
                yield return null; 
            }
            else
            {
                image.color = new Color(image.color.r,
                                   image.color.g,
                                   image.color.b, alpha);
            }


           
            yield return null;
        }
       
    }
}

