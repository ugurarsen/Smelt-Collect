using MoreMountains.Feedbacks;
using UnityEngine;

public class Chest : MonoBehaviour
{
    public Transform cover;
    public ParticleSystem confettiParticle;
    private bool isActive = true;
    public MMFeedbacks feedback;

    public void Close()
    {
        feedback.PlayFeedbacks();
    }

}