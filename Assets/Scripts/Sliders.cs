using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sliders : MonoBehaviour
{
    [SerializeField] SettingsScriptableObj settings;
    string objName;
    
    void Awake()
    {
        objName = transform.gameObject.name;
    }

    public void OnValueChanged(float newValue)
    {
        settings.UpdateSetting(newValue, objName);
    }
}
