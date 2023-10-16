using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SharkScriptableObject", menuName = "ScriptableObjects/Shark")] 
public class SharkScript : ScriptableObject
{
    [SerializeField] private bool sharkTriggered;
    [SerializeField] private bool sharkActive;

    void Start()
    {
        sharkTriggered = false;
        sharkActive = false;
    }

    public void triggerShark()
    {
        if (!sharkTriggered)
        {
            sharkActive = true;
            sharkTriggered = true;
        }
    }

    public void summonShark()
    {
        if (sharkActive)
        {
            sharkActive = false;
        }
    }

    public void sharkReset()
    {
        sharkTriggered = false;
        sharkActive = false;
    }

    public bool getSharkTriggered()
    {
        return sharkTriggered;
    }
    public bool getSharkActive()
    {
        return sharkActive;
    }
}
