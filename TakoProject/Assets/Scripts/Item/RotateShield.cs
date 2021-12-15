using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShield : MonoBehaviour
{
    private readonly float rot = 20f;

    void Update()
    {
        transform.Rotate(Vector3.up, rot * Time.deltaTime);
        
    }
}
