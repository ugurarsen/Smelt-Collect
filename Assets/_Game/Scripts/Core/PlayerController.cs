using System.Collections;
using System.Collections.Generic;
using Dreamteck.Splines;
using UA.Toolkit;
using UA.Toolkit.Vector;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerController : Singleton<PlayerController>
{
    public float Speed => Configs.Player.speed;
    public SplineFollower _follower;
    public List<Part> parts = new List<Part>();
    public float maxX = 1;
    [HideInInspector] public bool isRunning = false, moveX = false;
    public int startPartCount;
    public Part partPrefab;
    public float partOffset;
    public float sensivity;

    
    private void Start()
    {
        isRunning = true;
        
        for (int i = 0; i < startPartCount; i++)
        {
            Part tempPart = Instantiate(partPrefab);
            tempPart.tag = "Player";
            AddPart(tempPart);
        }
        
    }

    public void OnGameStarted()
    {
        moveX = true;
        _follower.follow = true;
    }
    public void Update()
    {
        if (isRunning)
        {
            PartsSetLine();
        }
        if (!moveX)
        {
            _follower.motion.offset = Vector2.Lerp(_follower.motion.offset,Vector2.zero,(Speed/3)*Time.deltaTime);
        }
    }
    
    

    public void MoveX(float x)
    {
        if (!moveX) return;
        x = Mathf.Clamp(x*sensivity, -maxX, maxX);
        _follower.motion.offset = new Vector2(x,0);
    }

    public void PartsSetLine()
    {
        if (isRunning)
        {
            if (parts.Count > 0)
            {
                float step = Speed * Time.deltaTime; // Sabit bir adım boyutu için sadece hızı kullanın
                Transform previousPosition = parts[0].transform;
                for (int i = 1; i < parts.Count; i++)
                {
                    Vector3 targetPosition = previousPosition.position + (previousPosition.forward * partOffset);
                    Vector3 newPosition = Vector3.Lerp(parts[i].transform.position, targetPosition, step);
                    parts[i].transform.position = newPosition;
                    previousPosition = parts[i].transform;
                }
            }
        }
    }
    

   


    public void PartsFeedback()
    {
        StartCoroutine(StartFeedback());
        IEnumerator StartFeedback()
        {
            for (int i = parts.Count; i > 0; i--)
            {
                yield return new WaitForSeconds(0.05f);
                parts[i - 1].Feedback();
            }
        }
        
    }
    
    bool isCalculating = false;
    public void PriceCalculate()
    {
        StartCoroutine(PriceCalculator());

        IEnumerator PriceCalculator()
        {
            while (isCalculating)
            {
                int price = 0;
                for (int i = 0; i < parts.Count; i++)
                {
                    if (i == 0 && !parts[0].transform.GetComponentInParent<PlayerController>())
                    {
                        parts[0].transform.SetParent(PlayerController.I.transform);
                        parts[0].transform.localPosition = Vector3.zero;
                    }
                    price += parts[i].price;
                }
                HandController.I.Price = price;
                yield return new WaitForSeconds(0.1f);
            }
            yield break;
        }
        
    }

    public void AlignCenter()
    {
        moveX = false;
    }
    


    public void AddPart(Part part)
    {
        if (!parts.Contains(part))
        {
            part.tag = "Player";
            parts.Add(part);
            PartsFeedback();
            if (parts.Count > 0)
            {
                isCalculating = true;
                PriceCalculate();
            }
        }
        
    }
    
    public void RemovePart(Part part, bool isCalculate = true)
    {
        if (parts.Contains(part))
        {
            if (isCalculate)
            {
                MoneyTower.I.totalPrice += part.price;
            }
            parts.Remove(part);
            part.transform.SetParent(null);
            if (parts.Count == 0)
            {
                isCalculating = false;
                HandController.I.Price = 0;
            }
        }
    }
    
    #region ObstacleTriggered
    bool isTriggered = false;
    public void ObstacleTriggered()
    {
        if(isTriggered) return;
        isTriggered = true;
        float currentSpeed = _follower.followSpeed;
        _follower.followSpeed = 0.001f;
        new DelayedAction((() =>
        {
            _follower.followSpeed = currentSpeed;
            isTriggered = false;
        }), 1f).Execute(this);
    }
    #endregion
    
}
