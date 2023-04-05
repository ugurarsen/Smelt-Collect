using System.Collections.Generic;
using DG.Tweening;
using MoreMountains.Feedbacks;
using UnityEngine;

public class Finish : MonoBehaviour
{
    public Animator animator;

    enum AnimState
    {
        Closed,
        Open,
        Opened,
        Close
    }

    AnimState animState
    {
        get => _animState;
        set
        {
            if(value != _animState)
            {
                _animState = value;
                animator.SetTrigger(_animState.ToString());
            }
        }
    }

    private AnimState _animState = AnimState.Closed;
    public MMFeedbacks trashOpen;
    public Transform[] BoxPos;
    public Transform binPos1, binPos2;
    public Transform handPos;
    public List<Part> parts = new List<Part>();

    bool _isTriggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Part part = other.gameObject.GetComponent<Part>();
            if (!parts.Contains(part))
            {
                PlayerController.I.RemovePart(part);
                parts.Add(part);
                PartMove(part);
            }
        }
    }

    public void PartMove(Part part)
    {
        if (part.partType != 3)
        {
            part.transform.DOJump(binPos1.transform.position,1f,1,.5f).OnComplete(() =>
            {
                part.transform.DOMove(binPos2.transform.position,.5f).OnComplete(() =>
                {
                    part.gameObject.SetActive(false);
                });
            });
        }
        else
        {
            SafeboxParts.Add(part);
            part.transform.DOJump(BoxPos[SafeboxParts.Count - 1].position,.5f,1, .5f).OnStart((() =>
            {
                part.transform.DORotate(BoxPos[SafeboxParts.Count - 1].rotation.eulerAngles, .5f);
                part.transform.DOScale(1, .5f);
            }));
        }
    }

    public List<Part> SafeboxParts = new List<Part>();


    public void ReadyForFinish()
    {
        animState = AnimState.Open;
        trashOpen.PlayFeedbacks();
    }
    
    public void HandMoveTarget()
    {
        HandController.I.HandFinishCondition(handPos);
    }
    
}
