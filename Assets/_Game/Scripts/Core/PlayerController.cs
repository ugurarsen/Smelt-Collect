using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UA.Toolkit.Transforms;
public class PlayerController : Singleton<PlayerController>
{
    //Some variables...
    float Speed => Configs.Player.speed;

    public void OnGameStarted()
    {
    }
}
