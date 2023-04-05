using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HotGate : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Part part = other.gameObject.GetComponent<Part>();
            if (part.partType == 1)
            {
                part.partType = 2;
                part.Feedback();
            }
        }
    }
}
