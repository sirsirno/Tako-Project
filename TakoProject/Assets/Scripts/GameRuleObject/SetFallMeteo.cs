using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFallMeteo : MonoBehaviour
{
    public GameObject meteoSetPrefab;
    public Transform parentTrm;

    public static SetFallMeteo instance;

    private bool isStartMeteo = false;
    private void Awake()
    {
        if(instance != null)
        {
            Debug.LogError(" 이미 메테오 관련 싱글턴 존재 ");

        }
        else
        {
            instance = this;
        }
    }
 
    private void Update()
    {
        if(CheckFallMeteoState())
        {
           StartCoroutine(StartFallMeteo());        
        }
       
    }

    private bool CheckFallMeteoState()
    {
        if (isStartMeteo)
        {
            return false;
        }
        return (GameManager.instance.isPlaying && !(GameManager.instance.isInvinsible));
    }

    private IEnumerator StartFallMeteo()
    {
        isStartMeteo = true;
        System.Random ran = new System.Random();

        
        var a = Instantiate(meteoSetPrefab, parentTrm);
        a.transform.position = new Vector3(ran.Next(-35, 35), 0, ran.Next(-35, 35));

        var b = Instantiate(meteoSetPrefab, parentTrm);
        b.transform.position = new Vector3(ran.Next(-35, 35), 0, ran.Next(-35, 35));

        yield return new WaitForSeconds(3f);

        isStartMeteo = false;

        // 인스턴셰이트 
    }

   
}
