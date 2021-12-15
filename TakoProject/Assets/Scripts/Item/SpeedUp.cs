using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedUp : MonoBehaviour, IUseable 
{
    private TankMovement tm;
    private TankItemEffect te;

    void Start()
    {
        tm = null;
        te = null;
    }
    public void Use(GameObject target)
    {
        tm = target.GetComponent<TankMovement>();
        te = target.GetComponent<TankItemEffect>();

        EnableSpeedUp();
        te.isActiveItem = true;

        gameObject.transform.position = new Vector3(gameObject.transform.position.x,
               gameObject.transform.position.y - 20f, gameObject.transform.position.z);

        Debug.Log("æ∆¿’2");
    }

    public void  EnableSpeedUp()
    {
        tm.isMoveItem = true;

        Invoke("DisableSpeedUp", 4f);
    }

    private void DisableSpeedUp()
    {
        tm.isMoveItem = false;
        te.isActiveItem = false;
        Invoke("DestroyThis", 1f);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "PLAYER")
        {
            CheckTankDistance();
        }
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

