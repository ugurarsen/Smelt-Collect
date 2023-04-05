using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIMoneyController : Singleton<UIMoneyController>
{
    public Transform target;
    
    public void CreateUIMoney(Vector3 createPosition, int money)
    {
        UIMoney uiMoney = PoolManager.I.GetObject<UIMoney>();
        uiMoney.transform.SetParent(transform);
        uiMoney.transform.position = createPosition;
        uiMoney.GoToTarget(money);
    }

    public void TargetFeedback()
    {
        target.DOKill();
        target.DOScale(Vector3.one * 1.1f, 0.25f).OnComplete(() =>
        {
            target.DOScale(Vector3.one, 0.2f);
        });
    }
    
}
