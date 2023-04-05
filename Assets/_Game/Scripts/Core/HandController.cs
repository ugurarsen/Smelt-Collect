using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class HandController : Singleton<HandController>
{
    public TextMeshProUGUI priceText;
    public Animator animator;

    public enum  AnimaState
    {
        Stone,
        Owen,
        Gold,
    }
    
    


    public AnimaState animaState
    {
        get { return _animaState; }
        set
        {
            if (_animaState != value)
            {
                _animaState = value;
                animator.SetTrigger(_animaState.ToString());
            }
        }
    }
    
    AnimaState _animaState = AnimaState.Stone;
    private int _price = 0;
    public int Price
    {
        get { return _price; }
        set
        {
            _price = value;
            priceText.text = "$"+_price;
        }
    }

    public void ChangeAnimaState(int stateID)
    {
        // Write SwichCase for each state

        switch (stateID)
        {
            case 0:
                animaState = AnimaState.Stone;
                break;
            case 1:
                animaState = AnimaState.Owen;
                break;
            case 2:
                animaState = AnimaState.Owen;
                break;
            case 3:
                animaState = AnimaState.Gold;
                break;
            
        }
        
    }
    
    public void HandFinishCondition(Transform handpos)
    {
        ChangeAnimaState(3);
        transform.DOMove(handpos.position, .3f).OnComplete(() =>
        {
            MoneyTower.I.SetHandParent();
            CameraController.I.ChangeCamera(3);
        });

    }
}
