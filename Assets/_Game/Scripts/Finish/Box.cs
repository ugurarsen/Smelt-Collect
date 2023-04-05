using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class Box : MonoBehaviour
{
    public TextMeshPro text;

    public bool isChecked = false;
    public Vector3 scale;
    private void OnTriggerEnter(Collider other)
    {
        if (isChecked) return;
        if (other.gameObject.CompareTag("MoneyTower"))
        {
            scale = transform.localScale;
            isChecked = true;
            transform.DOScale(scale*1.25f, 0.25f).OnComplete(() =>
            {
                transform.DOScale(scale, 0.2f);
            });
        }
    }
}
