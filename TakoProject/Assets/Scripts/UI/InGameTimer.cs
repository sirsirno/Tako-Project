using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGameTimer : MonoBehaviour
{
    public Text timer;
    public float originTime = 30f;
    public float currentTime = 0f;
    public TankHealth th;
    public bool ableTimer = false;
    public bool isTimerOver = false;
    public GameObject[] shellPrefabs;
    public SuddenDeathUI sd;

    public static InGameTimer instance;

    public IEnumerator coroutine;


    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("인스턴스 이미 있음 위험");

        }
        else
        {
            instance = this;
        }

        coroutine = Timer();
    }
    // Start is called before the first frame update
    void Start()
    {
        timer.text = originTime.ToString();      
        isTimerOver = false;
        ableTimer = EnableTimer();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.instance.isPlaying )
        {
            StartCoroutine(Timer());
        }
    }

    public IEnumerator Timer()
    {
        if(float.Parse(timer.text) <= 0 )
        {


            int ran = Random.Range(1, 2);
            //라운드 종료 ㅊ처리 
            ableTimer = false;
            isTimerOver = true;
            timer.text = InitTimer();

            switch (ran)
            {
                case 1:
                    Instantiate(shellPrefabs[0], GameManager.instance.m_Tanks[0].m_Instance.transform);
                    Instantiate(shellPrefabs[1], GameManager.instance.m_Tanks[1].m_Instance.transform);
                    break;
                case 2:
                    Instantiate(shellPrefabs[0], GameManager.instance.m_Tanks[1].m_Instance.transform);
                    Instantiate(shellPrefabs[1], GameManager.instance.m_Tanks[0].m_Instance.transform);
                    break;

                default:
                    Instantiate(shellPrefabs[0], GameManager.instance.m_Tanks[1].m_Instance.transform);
                    Instantiate(shellPrefabs[1], GameManager.instance.m_Tanks[0].m_Instance.transform);
                    break;
            }
            
            GameManager.instance.DisableTankControl();
           // StopCoroutine(coroutine);

        }

        timer.text = (float.Parse(timer.text) - Time.deltaTime).ToString("0.00");

        yield return new WaitForSeconds(1f);
    }

    public string InitTimer()
    {
        GameManager.instance.isPlaying = false;
        timer.text = originTime.ToString();   
        isTimerOver = false;

        GameManager.instance.EnableTankControl();

        return timer.text;

    }

    private bool EnableTimer()
    {
        return true;
    }
   
}
