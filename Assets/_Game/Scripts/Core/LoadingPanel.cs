using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;

#if SupersonicWisdomSDK
using SupersonicWisdomSDK;
#endif

#if TinySauce
using TinySauce;
#endif
using UnityEngine;
using UnityEngine.UI;

public class LoadingPanel : Singleton<LoadingPanel>
{
    public Image loadingBar;

    public float loadingSpeed = 1f, maxFillAmount = 10f;
    private float fillAmount = 0f;

    public bool isActive;

    public void StartLoading()
    {
        isActive = true;
        StartCoroutine(CheckSDK());
    }

    IEnumerator CheckSDK()
    {
        while (isActive)
        {
            yield return new WaitForSeconds(.1f);
            isActive = false;
#if SupersonicWisdomSDK
        if (SupersonicWisdom.Api.IsReady())
            {
                isActive = false;
                loadingBar.DOFillAmount(1, .5f).OnComplete(() =>
                {
                    LevelHandler.I.StartGame();
                });
            }    
#endif
        }
    }
    private void Update()
    {
        if (isActive)
        {
            fillAmount += loadingSpeed * Time.deltaTime;
            loadingBar.fillAmount = fillAmount / maxFillAmount;
        }
        
    }
}
