using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "CameraInfoScriptableObject", menuName = "ScriptableObjects/CamInfo")] 
public class CameraInfoScriptableObject : ScriptableObject
{
    [SerializeField] private float xRot;

    public void setRotValues(float xRotation)
    {
        xRot = xRotation;
    }

    public float getRotValues()
    {
        return xRot;
    }
}
