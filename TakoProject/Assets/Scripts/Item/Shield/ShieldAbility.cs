using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldAbility : MonoBehaviour
{
    private void Start()
    {
        Invoke("DestroyShield",8f);
    }
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("BULLET"))
        {

            if (Vector3.Distance(gameObject.transform.position, other.gameObject.transform.position) < 2.9f)
            {
                return;
            }
            else
            {
                Destroy(other.gameObject);
                Debug.Log("ÃÑ¾Ë");
                DestroyShield();
            }

        }
        else
        {
            return;
        }
        
        
       
      
    }



    private void DestroyShield()
    {
        Destroy(gameObject);
    }

    



}
