using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsScriptableObject", menuName = "ScriptableObjects/Settings")] 
public class SettingsScriptableObj : ScriptableObject
{
    [SerializeField] private float sensitivity;
    [SerializeField] private float brightness;

    public void UpdateSetting(float val, string slider)
    {
        switch (slider)
        {
            case "Sensitivity Slider":
                sensitivity = val;
                break;
            case "Brightness Slider":
                brightness = val;
                break;
            default:
                Debug.LogError("A slider update has been called when no such slider exists!");
                break;
        }
    }

    public void DefaultSettings()
    {
        sensitivity = 500F;
        brightness = 1F;
    }

    public float getSensitivity()
    {
        return sensitivity;
    }

    public float GetBrightness()
    {
        return brightness;
    }
}
