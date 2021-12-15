using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankItemEffect : MonoBehaviour
{
    public bool isActiveItem = false;
    public ParticleSystem trail;
    public ParticleSystem idleParticle;

    private void Start()
    {
        isActiveItem = false;

        trail.gameObject.SetActive(false);
        idleParticle.gameObject.SetActive(false);
    }

    private void FixedUpdate()
    {
        if (!isActiveItem)
        {
            trail.gameObject.SetActive(false);
            idleParticle.gameObject.SetActive(false);
        }
        else
        {
            trail.gameObject.SetActive(true);
            idleParticle.gameObject.SetActive(true);
        }
    }


}
