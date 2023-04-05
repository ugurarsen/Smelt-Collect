using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Level : MonoBehaviour
{
    Skybox _skybox;
    public Material skyboxMaterial;
    private void Start()
    {
        RenderSettings.skybox = skyboxMaterial;
    }
}
