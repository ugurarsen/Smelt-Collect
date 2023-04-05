using UnityEngine;
using DG.Tweening;
public class SellMachine : MonoBehaviour
{
    public float bandSpeed, partDuration;
    public MeshRenderer BandMeshRenderer;
    public Transform partTarget;

    private Material _material;
    private void Start()
    {
        _material = BandMeshRenderer.material;
    }

    private void Update()
    {
        _material.mainTextureOffset += new Vector2(0, bandSpeed)*Time.deltaTime;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Part part = other.gameObject.GetComponent<Part>();
            PlayerController.I.RemovePart(part);
            UIMoneyController.I.CreateUIMoney(Camera.main.WorldToScreenPoint(transform.position), part.price);
            part.transform.DOMove(partTarget.position, partDuration).OnComplete(() =>
            {
                part.gameObject.SetActive(false);
            });
        }
    }
}
