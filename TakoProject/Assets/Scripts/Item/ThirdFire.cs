using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdFire : MonoBehaviour, IUseable
{
    private TankShooting ts;
    private TankItemEffect te;
    
    void Start()
    {
        ts = null;
        te = null;
    }
   

    public void Use(GameObject target)
    {
        ts = target.GetComponent<TankShooting>();
        te = target.GetComponent<TankItemEffect>();

        EnableThirdFire();
        te.isActiveItem = true;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
             gameObject.transform.position.y - 20f, gameObject.transform.position.z);
    }
    private void EnableThirdFire()
    {
        ts.isFireItem = true;
        Invoke("DisableThirdFire", 3f);
    }

    private void DisableThirdFire()
    {
        ts.isFireItem = false ;
        te.isActiveItem = false;

        Invoke("DistroyThis", 1f);
    }
    public void DestroyThis()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PLAYER")
        {
            CheckTankDistance();
        }
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
