using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shield : MonoBehaviour ,IUseable
{
     Transform objTrm;
    public GameObject shieldPrefab;
  

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "PLAYER")
        {         
            objTrm = other.gameObject.transform;    
            Use(other.gameObject);
        }
        
    }
    public void Use(GameObject target)
    {
        Instantiate(shieldPrefab, objTrm);

        Debug.Log("æ∆¿’");

        DestroyThis();
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }
    public void CheckTankDistance()
    {
        if (Vector3.Distance(GameManager.instance.m_Tanks[0].m_Instance.transform.position
               , gameObject.transform.position)
               < Vector3.Distance(GameManager.instance.m_Tanks[1].m_Instance.transform.position
               , gameObject.transform.position))
        {
            Use(GameManager.instance.m_Tanks[0].m_Instance);
        }
        else
        {
            Use(GameManager.instance.m_Tanks[1].m_Instance);
        }
    }
}

  

