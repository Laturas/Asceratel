using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriggersScriptableObject", menuName = "ScriptableObjects/Triggers Scriptable Object")] 
public class TriggersScriptableObject : ScriptableObject
{
    public void triggerEntered(string triggerName, GameObject passedGO)
    {
        switch (triggerName)
        {
            case "Lava Door Closing Trigger":
                Animator anim = passedGO.GetComponent<Animator>();
                anim.SetTrigger("Close");

            default:
                break;
        }
    }
}
