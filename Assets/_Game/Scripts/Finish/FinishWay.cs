using DG.Tweening;
using TMPro;
using UnityEngine;

public class FinishWay : MonoBehaviour
{
    public TextMeshPro text;
    private bool isActive = true;
    public Transform movePoint;
    public Chest chest;
    public void OnTriggerEnter(Collider other)
    {
        if (!isActive) return;
        if (other.gameObject.CompareTag("Player"))
        {
            isActive = false;
            Part part = other.gameObject.GetComponent<Part>();
            FinishWayFeedback(part);
            CameraController.I.ChangeCamera(2);
        }
    }
    
    public void FinishWayFeedback(Part part = null)
    {
        PlayerController.I.RemovePart(part);
        part.transform.DOMove(movePoint.position, 0.5f).OnComplete(() =>
        {
            chest.Close();
        });
    }
}
