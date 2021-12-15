using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class SuddenDeathUI : MonoBehaviour
{
    public Text noticeText;
    public Text noticeTimeText;
    public Image image;

    private void Awake()
    {
        noticeText.transform.localScale = new Vector3(0f, 0f, 0f);
        noticeTimeText.transform.localScale = new Vector3(0f, 0f, 0f);
        image.gameObject.SetActive(false);
    }


    public void OnSuddenDeath()
    {
        if(noticeText != null && noticeTimeText != null && image != null)
        {
            SetSuddenDeath();
        }
    }

    void SetSuddenDeath()
    {
        noticeText.transform.DOScale(1f, 1f);
        noticeTimeText.transform.DOScale(1f, 1f);
    }


}
