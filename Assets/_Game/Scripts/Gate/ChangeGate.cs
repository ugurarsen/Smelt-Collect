using System.Collections.Generic;
using UnityEngine;

public class ChangeGate : MonoBehaviour
{
    List<Part> parts = new List<Part>();
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Part part = other.gameObject.GetComponent<Part>();
            if (!parts.Contains(part))
            {
                if (part.partType < 3)
                {
                    parts.Add(part);
                    part.partType++;
                    part.Feedback();
                }
            }
        }
    }
}
