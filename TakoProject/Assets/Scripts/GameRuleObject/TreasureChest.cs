using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureChest : MonoBehaviour
{
    public Transform[] treasureChests;
    public Transform[] openedTreasureChests;
    public bool isStartItemSpawn;

    private void Start()
    {
        treasureChests = GameObject.Find("ItemSpawnChests").transform.GetComponentsInChildren<Transform>();
        openedTreasureChests = GameObject.Find("ItemSpawnChestsOpen").transform.GetComponentsInChildren<Transform>();

        for (int i = 0; i < 4 ; i++)
        {
            openedTreasureChests[i].gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if(GameManager.instance.isPlaying && !GameManager.instance.isInvinsible)
        {
            if (isStartItemSpawn)
            {
                for (int i = 0; i < 4 ; i++)
                {
                    treasureChests[i].gameObject.SetActive(false);
                    openedTreasureChests[i].gameObject.SetActive(true);

                }
            }
            else
            {
                for (int i = 0; i < 4  ; i++)
                {
                    treasureChests[i].gameObject.SetActive(true);
                    openedTreasureChests[i].gameObject.SetActive(false);

                }
            }
        }
        else
        {
            for (int i = 0; i < 4; i++)
            {
                treasureChests[i].gameObject.SetActive(true);
                openedTreasureChests[i].gameObject.SetActive(false);

            }
        }

    }
      
}
