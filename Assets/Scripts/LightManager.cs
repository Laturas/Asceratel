using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightManager : MonoBehaviour
{
    [SerializeField] private GameObject playerLight;

    private Light lightController_;

    // Caching because GetComponent is very expensive
    void Awake() => lightController_ = GetComponent<Light>();

    public void CameraLightLevelSet(float lightLevel) 
    {
        lightController_.intensity = lightLevel;
    }
}
