using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackholeCol : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PLAYER")
        {
            other.gameObject.GetComponent<TankHealth>().TakeDamage(100);
        }
    }
   
}   
