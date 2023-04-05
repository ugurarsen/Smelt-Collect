using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class SmokeControl : MonoBehaviour
{
    public ParticleSystem particleSystem;
    void OnTriggerEnter (Collider trig)
    {
        if(trig.gameObject.tag == "Ground")
        {
            particleSystem.Play();
        }
    }    
}
