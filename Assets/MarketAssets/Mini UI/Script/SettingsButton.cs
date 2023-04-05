using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SettingsButton : MonoBehaviour
{
    public GameObject blur, panel;
    
    public Switch_Slide switch_Slider;
    

    public void Close()
    {
        panel.transform.DOScale(Vector3.zero, Configs.UI.FadeOutTime).SetEase(Ease.InOutElastic).OnComplete(() =>
        {
            panel.SetActive(false);
            blur.SetActive(false);
            gameObject.SetActive(false);
        });
    }

    public void Open()
    {
        if(!gameObject.activeSelf)
        {
            gameObject.SetActive(true);
            blur.SetActive(true);
            panel.transform.localScale = Vector3.zero;
            panel.SetActive(true);
            panel.transform.DOScale(Vector3.one, Configs.UI.FadeOutTime*2f).SetEase(Ease.InOutElastic);
        }
    }
}
