using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using MyBox;
using UnityEngine;

public class CameraController : Singleton<CameraController>
{
    public Animator animator;

    public void ChangeCamera(int CamID)
    {
        animator.SetInteger("CamID", CamID);
    }
}
