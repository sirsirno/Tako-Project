using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class FlipSelectUI : MonoBehaviour
{
    bool isStop = false;
    bool isShowImage = false;
    float rotSpeed = 10f;

    public Material[] mapViewImages;
 
    private void Start()
    {
        Invoke("StopUI", 6.1f);

         isStop = false;
         isShowImage = false;
    }
    void Update()
    {
        if (!isStop)
        {
            gameObject.transform.Rotate(new Vector3(0f, 1 * rotSpeed, 0f));

            rotSpeed -= 0.01f;

        }
    }

    void ShowMapImage()
    {
        int ranCount = Random.Range(0, 4);

        switch (ranCount)
        {
            case 0:
                gameObject.GetComponent<MeshRenderer>().material =
                    mapViewImages[0];
                break;
            case 1:
                gameObject.GetComponent<MeshRenderer>().material =
                   mapViewImages[1];
                break;
            case 2:
                gameObject.GetComponent<MeshRenderer>().material =
                   mapViewImages[2];
                break;
            case 3:
                gameObject.GetComponent<MeshRenderer>().material =
                   mapViewImages[3];
                break;
            case 4:
                gameObject.GetComponent<MeshRenderer>().material =
                   mapViewImages[4];
                break;

           
        }

        isShowImage = true;

        if(isStop && isShowImage)
        {


            Invoke("StartGameSceneLoop", 2f);
            
        }
    }



    void StopUI()
    {
        isStop = true;
        gameObject.transform.rotation = Quaternion.Euler( new Vector3(180f, -180f, 0f));
        

        Invoke("ShowMapImage", 0.1f);
    
    }
}
