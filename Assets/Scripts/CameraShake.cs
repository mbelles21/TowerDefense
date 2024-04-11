using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    public CinemachineImpulseSource screenShake;
    public float powerAmount;

    public void ScreenShake()
    {
        screenShake.GenerateImpulse();
    }
}
