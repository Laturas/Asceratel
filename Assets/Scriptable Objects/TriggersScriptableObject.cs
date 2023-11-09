using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriggersScriptableObject", menuName = "ScriptableObjects/Triggers Scriptable Object")] 
public class TriggersScriptableObject : ScriptableObject
{
    private ManagerOfScenes sm;
    public void triggerEntered(string triggerName, GameObject passedGO)
    {
        if (sm == null) {passedGO.TryGetComponent<ManagerOfScenes>(out sm);}

        switch (triggerName)
        {
            case "Lava Door Closing Trigger":
                Animator anim = passedGO.GetComponent<Animator>();
                AudioSource aud = passedGO.GetComponent<AudioSource>();
                aud.Play();
                anim.SetTrigger("Close");
                break;
            case "Door Closing Zone":
                Animator doorAnimator = passedGO.GetComponent<Animator>();
                doorAnimator.ResetTrigger("OpenDoor");
                doorAnimator.SetTrigger("CloseDoor");
                break;
            case "Graveyard Unloading Zone":
                sm.UnloadGraveyard();
                break;
            case "Lava Caverns Loading Zone":
                sm.LoadLavaZone();
                break;
            case "Amber Eyes Trigger":
                Animator amberEyeAnimator = passedGO.GetComponent<Animator>();
                amberEyeAnimator.SetTrigger("CloseEyes");
                break;
            default:
                break;
        }
    }
}
