using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HallucinationScriptableObject", menuName = "ScriptableObjects/Hallucination Scriptable Object")] 
public class HallucinationScriptableObject : ScriptableObject
{
    [SerializeField] private Camera mainCam;
    [SerializeField] private Camera hallCam;

    void CamEffect()
    {
    }
}
