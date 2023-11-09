using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensitivitySlider : MonoBehaviour
{
    [SerializeField] SettingsScriptableObj settings;
    
    public void OnValueChanged(float newValue)
    {
        settings.updateSensitivity(newValue);
    }
}
