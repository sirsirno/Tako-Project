using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meteo : MonoBehaviour
{
    public Transform markTrm;
    public GameObject meteoObject;
    public MeteoJudge mj;

    private float speed = 2f;

    private void Start()
    {
        float time = Time.time;

        if (time > 3.0f)
        {
            ShootMeteo(markTrm);
            time = 0f;
        }

        Invoke("DestoryStage", 3f);
      
    }

    private void Update()
    {
        if(mj.isEnd)
        {
            Invoke("DestoryStage", 1f);
          
        }
    }
    private void ShootMeteo(Transform trm)
    {
        meteoObject.AddComponent<Rigidbody>();
    }

    private void DestoryStage()
    {
        Destroy(gameObject);
    }

    
}
