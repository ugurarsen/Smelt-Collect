using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class UIMoney : PoolObject
{
    
    
    public void GoToTarget(int money)
    {
        transform.DOMove(UIMoneyController.I.target.position, 1f).OnStart((() =>
        {
            transform.DOScale(1, 0.8f);
        })).OnComplete(() =>
        {
            UIMoneyController.I.TargetFeedback();
            SaveLoadManager.AddCoin(money);
            OnDeactivate();
        });
    }
    

    public override void OnDeactivate()
    {
        gameObject.SetActive(false);
    }

    public override void OnSpawn()
    {
        gameObject.SetActive(true);
    }

    public override void OnCreated()
    {
        OnDeactivate();
    }
}
