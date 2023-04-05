using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UnityEngine;

public class RouteSwitch : MonoBehaviour
{
    public void OnNodePassed()
    {
        PlayerController.I._follower.SetPercent(0);
    }
}

