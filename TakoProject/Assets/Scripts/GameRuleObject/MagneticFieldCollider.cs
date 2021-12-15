using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticFieldCollider : MonoBehaviour
{
    private void OnTriggerExit(Collider other)
    {
        if (!(GameManager.instance.isInvinsible))
        {
            RaycastHit hit;

            var oldPos = -(other.transform.localPosition);

            other.transform.transform.localPosition = oldPos;

            if (Physics.Raycast(other.gameObject.transform.position, transform.forward * 10f, out hit))
            {
                if(hit.transform.tag == "MAGNETICFIELD")
                {
                    other.transform.position = oldPos + new Vector3(10f, 0f, 10f);
                }
            }


            
        }                
    }   
}
