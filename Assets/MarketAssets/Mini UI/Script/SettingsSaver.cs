using System;
using System.Collections;
using System.Collections.Generic;
using UA.Toolkit;
using UnityEngine;
using UnityEngine.UI;

public class SettingsSaver : MonoBehaviour
{
    [SerializeField] private GameObject textOFF;
    [SerializeField] private GameObject textON;
    [SerializeField] private Switch_Slide switchSlide;
    [SerializeField] private Slider volumeSlider;


    private void Start()
    {
        volumeSlider.value = SaveLoadManager.GetVolume();
    }

    private void Update()
    {
        if(switchSlide.textIsOn == true)
        {
            SetOn();
        } else
        {
            SetOff();
        }
    }

    public void ChangeSliderValue()
    {
        SaveLoadManager.SetVolume(volumeSlider.value);
    }
    public void SetOn()
    {
        textON.SetActive(true);
        textOFF.SetActive(false);
        Vibrator.EnableVibration(true);
    }

    public void SetOff()
    {
        textON.SetActive(false);
        Vibrator.EnableVibration(false);
        textOFF.SetActive(true);
    }
}
