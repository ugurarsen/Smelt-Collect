using MoreMountains.Feedbacks;
using MoreMountains.NiceVibrations;
using UnityEngine;

public class Part : MonoBehaviour
{
    public MMFeedbacks TextFeedback, ScaleFeedbacks;
    public bool TriggerFeedbackButton;
    public int price;

    public void Feedback()
    { 
        ScaleFeedbacks?.PlayFeedbacks(transform.position);
        Vibrator.Haptic(HapticTypes.LightImpact);
    }

    private int _partType;
    public int partType
    {
        get { return _partType; }
        set
        {
            _partType = value;
            MeshChanger();
        }
    }
    
    public GameObject[] modes;
    public void MeshChanger()
    {
        price = _partType*(partType+1) + 5;
        for (int i = 0; i < modes.Length; i++)
        {
            modes[i].SetActive(i == _partType);
        }
        if (PlayerController.I.parts[0] == this)
        {
            HandController.I.ChangeAnimaState(_partType);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Part"))
        {
           AddPartToPlayer(collision.gameObject.GetComponent<Part>());
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (tag == "Part" && other.gameObject.CompareTag("PlayerCenter"))
        {
            AddPartToPlayer(this);
        }
    }

    public void AddPartToPlayer(Part tempPart)
    {
        PlayerController.I.AddPart(tempPart);
        Vibrator.Haptic(HapticTypes.MediumImpact);
    }
}
