using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallItem : MonoBehaviour
{ 
    public Transform[] spawnPoints;
    public GameObject[] items;
    public bool isGameStart;
    public bool isFalled = false;
    public TreasureChest tc;

    public GameObject[] prefabs;

    public List<GameObject> obj;


    private void Awake()
    {
        spawnPoints = GameObject.Find("ItemSpawnPoints").GetComponentsInChildren<Transform>();
        obj = new List<GameObject>();
    }

    private void FixedUpdate()
    {
        if (CheckCanFallState())
        {
            StartCoroutine(CreateItem());
            
        }
    }

    bool CheckCanFallState()
    {
        return !isFalled && GameManager.instance.isPlaying && !GameManager.instance.isInvinsible;
    }

    private IEnumerator CreateItem()
    {

        isFalled = true;
        tc.isStartItemSpawn = true;
        var a = Random.Range(0, prefabs.Length);

        for (int i = 1; i < spawnPoints.Length -1; i++)
        {

           GameObject go =  Instantiate(prefabs[a],
                   new Vector3(spawnPoints[i].transform.position.x, 1f, spawnPoints[i].transform.position.z)
                   , Quaternion.identity);

            obj.Add(go);



            Debug.Log("아이템 생성 완료");

      //아이템 랜덤으로 prefabs 생성하게 하긔 
        }
       
        yield return new WaitForSeconds(4f);

        foreach (var item in obj)
        {
            if(item != null)
            {
                item.SetActive(false);
            }      
        }
        tc.isStartItemSpawn = false;

        yield return new WaitForSeconds(4f);

        foreach (var item in obj)
        {
            Destroy(item);
        }
        isFalled = false;
  
    }



}

