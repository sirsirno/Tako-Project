using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeteoJudge : MonoBehaviour
{
    public bool isEnd = false;
    public MeteoSphere meteoShphere;



    private void Start()
    {
        isEnd = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        isEnd = true;

        meteoShphere.burst.Play();
        meteoShphere.trail.Play();

    }
}
