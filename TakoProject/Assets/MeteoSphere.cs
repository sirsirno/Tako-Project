using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoSphere : MonoBehaviour
{
    public Transform markTrm;

    public ParticleSystem burst;
    public ParticleSystem trail;
    public MeteoJudge mj;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("PLAYER"))
        {
            collision.gameObject.GetComponent<TankHealth>().TakeDamage(100);
            mj.isEnd = true;
        }
        else
        {
            mj.isEnd = true;
        }
    }

}
