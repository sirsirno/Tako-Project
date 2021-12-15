using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Blackhole : MonoBehaviour
{


    float speed = 3f;
    Vector3 dir;
    [SerializeField]
    private float radius = 25f; 


    void Update()
    {
      
        
        
        foreach (var item in GameManager.instance.m_Tanks)
        {
           
            if(Vector3.Distance(gameObject.transform.localPosition, item.m_Instance.transform.localPosition) < radius)
            {
                dir = new Vector3(gameObject.transform.localPosition.x - item.m_Instance.transform.localPosition.x,
                                  0f,
                                  gameObject.transform.localPosition.z - item.m_Instance.transform.localPosition.z);

                item.m_Instance.transform.localPosition += dir * Time.deltaTime / speed ;

                item.m_Movement.m_Speed = 8f;
                item.m_Movement.m_TurnSpeed = 120f;

            }
            else
            {
                item.m_Movement.m_Speed = 12f;
                item.m_Movement.m_TurnSpeed = 180f;
                item.m_Instance.transform.localPosition=item.m_Instance.transform.localPosition;
            }
        }

        
    }

    
}
