using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class Jagijang : MonoBehaviour
{
    public GameObject magneticField;
    public ParticleSystem[] magneticEffects;
    public CapsuleCollider fieldColObj;
    public GameObject magneticMask;

    public float speed = 5f;
    ShapeModule mask;
    public ShapeModule sm;
    private void Start()
    {       
            magneticEffects = magneticField.transform.GetComponentsInChildren<ParticleSystem>();

        mask = magneticMask.GetComponent<ParticleSystem>().shape;
        //0번째 인수 사용 x -> 부모꺼임
    }
    void Update()
    {
        if (GameManager.instance.isPlaying)
        {
            fieldColObj.enabled = true;
            StartCoroutine(MagneticField());
            StartCoroutine(MagneticMask());
        }
        else
        {
            InitField();
        }
       
    }

    private IEnumerator MagneticField()
    {
        for (int i = 1; i < magneticEffects.Length; i++)
        {
           
            var me = magneticEffects[i].shape;
            me.radius -= Time.deltaTime * speed;
            sm = magneticEffects[i].shape;
        }

        fieldColObj.radius -= Time.deltaTime * speed ;

        yield return null;

    }
    private IEnumerator MagneticMask()
    {
        mask.radius -= Time.deltaTime * speed;
        yield return null;
    }
    private void InitField()
    {
        for (int i = 1; i < magneticEffects.Length; i++)
        {
            var me = magneticEffects[i].shape;
            me.radius = 60f;
        }

        fieldColObj.radius = 60f;
        mask.radius = 130f;

        fieldColObj.enabled = false;
    }

}
