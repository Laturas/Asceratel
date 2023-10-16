using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SettingsScriptableObject", menuName = "ScriptableObjects/Settings")] 
public class SettingsScriptableObj : ScriptableObject
{
    [SerializeField] private float sensitivity;

    void Start()
    {
        sensitivity = 500F;
    }

    public void updateSensitivity(float val)
    {
        sensitivity = val;
    }

    public float getSensitivity()
    {
        return sensitivity;
    }
}
