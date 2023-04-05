using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UA.Toolkit.Vector;
using UnityEngine;
using Random = UnityEngine.Random;

public class Obstacle : MonoBehaviour
{
    private bool isTriggered = false;
    public bool isKiller;
   
    public List<Part> parts = new List<Part>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Part tempPart = other.gameObject.GetComponent<Part>();
            if (!parts.Contains(tempPart))
            {
                parts.Add(tempPart);
            }
            if (isTriggered) return;
            PlayerTriggeredCondition();
        }
    }
    
    public void PlayerTriggeredCondition()
    {
        StartCoroutine(StartCondition());
        IEnumerator StartCondition()
        {
            PlayerController.I.ObstacleTriggered();
            yield return new WaitForSeconds(0.1f);
            
            isTriggered = true;
            if (!isKiller)
            {
                foreach (var part in parts)
                {
                    PlayerController.I.RemovePart(part,isKiller);
                    part.tag = "Part";
                    part.transform.DOJump(transform.position.WithX(Random.Range(-.7f, .7f))+Vector3.zero.WithZ(2f), 1, 1, 0.5f);
                }
            }
            else
            {
                Debug.Log("Hammer Triggered");
                for (int i = 0; i < parts.Count; i++)
                {
                    PlayerController.I.RemovePart(parts[i]);
                    parts[i].gameObject.SetActive(false);
                }
            }
            yield return new WaitForSeconds(.5f);
            isTriggered = false;
        }
    }
}
