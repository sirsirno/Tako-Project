using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagneticMask : MonoBehaviour
{
    bool isOvered = false;
    Jagijang jg;
    private void OnParticleCollision(GameObject other)
    {
        jg = new Jagijang();
        if (Vector3.Distance(other.transform.position, new Vector3(0,0,0)) > jg.sm.radius)
        {
            other.GetComponent<TankHealth>().TakeDamage(100);
        }

    }

 

}
//탱크와 원의 중심, 원의 반지름( 자기장 )  체크 