using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TriggersScriptableObject", menuName = "ScriptableObjects/Triggers Scriptable Object")] 
public class TriggersScriptableObject : ScriptableObject
{
    private ManagerOfScenes sceneManager;

    /* This used to be spread across 7 scripts. Trust me, this is the better alternative*/
    public void triggerEntered(string triggerName, GameObject passedGO)
    {
        // There is only one scene manager, so if we assign it once it will always be valid
        if (sceneManager == null && passedGO != null) {passedGO.TryGetComponent<ManagerOfScenes>(out sceneManager);}

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
                sceneManager.UnloadGraveyard();
                break;
            case "Lava Caverns Loading Zone":
                sceneManager.LoadLavaZone();
                break;
            case "Amber Eyes Trigger":
                Animator amberEyeAnimator = passedGO.GetComponent<Animator>();
                amberEyeAnimator.SetTrigger("CloseEyes");
                break;
            case "City Loading Trigger":
                sceneManager.LoadCity();
                break;
            case "Watchers Trigger":
                Instantiate(passedGO);
                break;
            case "Sudden Stop Trigger":
                // This is nasty in terms of performance but it only runs once.
                Camera.main.GetComponent<CameraLook>().shakeCam();
                passedGO.GetComponent<ElevatorSceneTrigger>().DisableElevator();
                break;
            case "Hallucination Trigger":
                passedGO.GetComponent<Flashback>().BeginSequence();
                Camera.main.GetComponent<CameraLook>().hallCam.GetComponent<HallucinatingCamera>().BeginSeq();
                break;
            default:
                break;
        }
    }
}
