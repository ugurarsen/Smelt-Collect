using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class PressMachine : MonoBehaviour
{
    public Transform press;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Press(other.gameObject.GetComponent<Part>());
        }
    }
    
    public void Press(Part part = null)
    {
        if (part.partType != 0) return;
        press.transform.DOKill();
        press.transform.DOLocalMoveY(-2.67f, 0.1f).SetEase(Ease.Linear).OnComplete((() =>
        {
            part.partType = 1;
            press.transform.DOLocalMoveY(0.41f, 0.1f).SetEase(Ease.Linear);
        }));
    }
}
