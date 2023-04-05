using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class WhellController : MonoBehaviour
{
    public Transform cursor;
    public float x5Aangle, x5Bangle, x3Aangle, x3Bangle;
    public TextMeshProUGUI nextButtonText;

    public void ShowWhell()
    {
        transform.DOScale(1, 0.5f).SetEase(Ease.OutBack).OnComplete((() =>
        {
            StartWhell();
        }));
       
    }

    public void StartWhell()
    {
        cursor.DORotate(new Vector3(0,0, 0), 1f).SetEase(Ease.Linear).SetLoops(-1,LoopType.Yoyo).OnUpdate(() =>
        {
            Calculate();
        });
    }
    
    public int Price = 0;
    public void Calculate()
    {
        float angle = cursor.eulerAngles.z;
        if (angle < x3Aangle && angle > x3Bangle)
        {
            if (angle < x5Aangle && angle > x5Bangle)
            {
                Price = MoneyTower.I.totalPrice * 5;
            }
            else
            {
                Price = MoneyTower.I.totalPrice * 3;
            }
        }
        else
        {
            Price = MoneyTower.I.totalPrice;
        }
        nextButtonText.text = "$"+Price;
    }

    public void ClaimCoins()
    {
        StartCoroutine(MoneyCorotine());
        cursor.DOKill();
        IEnumerator MoneyCorotine()
        {
            for (int i = 0; i < 5; i++)
            {
                UIMoneyController.I.CreateUIMoney(nextButtonText.transform.position, Price);
                yield return new WaitForSeconds(0.1f);
            }
            yield return new WaitForSeconds(2f);
            GameManager.ReloadScene(true);
        }
    }
}
