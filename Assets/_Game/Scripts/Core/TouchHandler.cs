﻿using MyBox;
using UnityEngine;
using UnityEngine.UI;
using UA.Toolkit.Rays;
using UA.Toolkit.Vector;
using UA.Toolkit.Transforms;

public class TouchHandler : Singleton<TouchHandler>
{

    #region UI
    [Foldout("Joystick Images",false)]
    [SerializeField] Image img_outerCircle, img_innerCircle;
    private float outerSize;

    public bool useJoystick;
    #endregion

    public enum TouchTypes
    {
        NONE = -1,
        Core = 0,
        Joystick = 1,
        SecondaryMechanic = 2
            //.....so on
    }

    TouchTypes activeTouch;

    //Delegate Functions. You can change them at spesific parts like end of
    //the level or at different types of obstacles

    private delegate void OnDownAction();
    private OnDownAction OnDown = null;
    private delegate void OnUpAction();
    private OnUpAction OnUp = null;
    private delegate void OnDragAction();
    private OnDragAction OnDrag = null;

    private bool isDragging = false;
    private bool canPlay = false;

    private Vector3 fp, lp, dif;

    public bool IsActive() => GameManager.isRunning && canPlay;
    public void Enable(bool isActive) => canPlay = isActive;

    private void Update()
    {
        if (IsActive())
            HandleTouch();
    }

    public void OnGameStarted()
    {
        Enable(true);
    }

    void HandleTouch()
    {
        if (!isDragging)
        {
            if (Input.GetMouseButtonDown(0))
            {
                OnDown?.Invoke();
                isDragging = true;
            }
        }
        else
        {
            OnDrag?.Invoke();

            if (Input.GetMouseButtonUp(0))
            {
                OnUp?.Invoke();
                isDragging = false;
            }
        }
    }

    public void Initialize(TouchTypes tt = TouchTypes.Core, bool isStart = false)
    {
        isDragging = false;
        switch(tt)
        {
            case TouchTypes.NONE:
                OnDown = null;
                OnUp = null;
                OnDrag = null;
                Enable(false);
                break;
            case TouchTypes.Core:
                OnDown = CoreDown;
                OnUp = CoreUp;
                OnDrag = CoreDrag;
                break;
            case TouchTypes.Joystick:
                outerSize = (img_outerCircle.rectTransform.rect.width / 2f) - (img_innerCircle.rectTransform.rect.width / 2f);
                OnDown = JoystickDown;
                OnUp = JoystickUp;
                OnDrag = JoystickDrag;
                break;
            case TouchTypes.SecondaryMechanic:
                OnDown = OnDownSecondary;
                OnUp = OnUpSecondary;
                OnDrag = OnDragSecondary;
                break;
            default:
                OnDown = CoreDown;
                OnUp = CoreUp;
                OnDrag = CoreDrag;
                break;
        }

        if(isStart)
            UIManager.I.Initialize();
    }

    #region CORE


    void CoreDown()
    {
    }
    void CoreUp()
    {
    }

    void CoreDrag()
    {
    }


    #endregion

    #region JOYSTICK
    
    private bool _firsInput = true;
    void JoystickDown()
    {
        fp = Input.mousePosition;
        if (_firsInput)
        {
            _firsInput = false;
            return;
        }
        
        img_outerCircle.transform.position = fp;
        img_outerCircle.gameObject.SetActive(true);
    }
    void JoystickDrag()
    {
        lp = Input.mousePosition;


        // Write your control code here
        
        dif = lp - fp;

        SetImagePositions();
        SetPlayerSpeed();
        SetPlayerRotation();

    }
    void JoystickUp()
    {
        img_outerCircle.gameObject.SetActive(false);
    }

    #region PLayerMovement Methods

    void SetImagePositions()
    {
        if (dif.magnitude >= outerSize)
            img_innerCircle.transform.localPosition = dif.normalized * outerSize;
        else
            img_innerCircle.transform.localPosition = dif;

        SetHighlights();
    }

    void SetPlayerSpeed()
    {
        //Set player speed here between 0.1 - 1.0
        //PlayerController.I.speed = Mathf.Clamp(dif.magnitude / outerSize, 0.1f, 1f);
    }

    void SetPlayerRotation()
    {
        Vector3 normPos = dif.normalized;
        
        float rot = (Mathf.Atan2(normPos.y, normPos.x) * Mathf.Rad2Deg) - 90f;

        //Set rotation of player object here on -Y axis
        //PlayerController.I.playerObject.transform.rotation = Quaternion.Euler(Vector3.down * rot);
    }

    void SetHighlights()
    {
        if (dif.x >= 0)
        {
            if (dif.y >= 0)
                UIManager.I.ShowJoystickHighlights(0);
            else
                UIManager.I.ShowJoystickHighlights(3);
        }
        else
        {
            if (dif.y >= 0)
                UIManager.I.ShowJoystickHighlights(1);
            else
                UIManager.I.ShowJoystickHighlights(2);
        }
    }

    #endregion

    #endregion

    #region SECONDARY

    void OnDownSecondary()
    {
    }
    void OnDragSecondary()
    {
    }
    void OnUpSecondary()
    {
    }
    #endregion


}
