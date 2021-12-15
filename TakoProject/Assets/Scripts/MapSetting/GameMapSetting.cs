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
            Debug.LogError("�̱��� ������");


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

  
        //����ٰ� ���� ���� ���� ǥ���� ��, ���۹� �˷��ִ°� �����. �װ��ϰ� ���� ����?

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
         
        
      
     
        Debug.Log("����");
      
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
        //�� �ε� ���� 
        ranCount = Random.Range(1, 5);

        //������ �� ���� ȿ�������� ���� 


        Debug.Log("�α��α��α�");

        switch (ranCount)
        {
            case 1:
                // 1�� �� ������ ��������
                Instantiate(gameMaps[0], mapTrm);
                break;
            case 2:
                // 2�� �� ������ ��������
                Instantiate(gameMaps[1], mapTrm);
                break;
            case 3:
                // 3�� �� ������ ��������
                Instantiate(gameMaps[2], mapTrm);
                break;
            case 4:
                // 4�� �� ������ ��������
                Instantiate(gameMaps[3], mapTrm);
                break;
            case 5:
                // 5�� �� ������ ��������
                Instantiate(gameMaps[4], mapTrm);
                break;
            default:
                // �⺻ �� ������ ��������
                Instantiate(gameMaps[1], mapTrm);
                break;
        }

        Debug.Log("º");


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

