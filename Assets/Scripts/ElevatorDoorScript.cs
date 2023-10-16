using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorDoorScript : MonoBehaviour
{
    [SerializeField] private Animator elevatorDoorAnimator;
    [SerializeField] private ElevatorSceneTrigger elevatorTriggerScript;

    public void CloseDoor()
    {
        elevatorDoorAnimator.SetTrigger("CloseDoor");
    }

    public void DoorClosingFinished()
    {
        elevatorTriggerScript.TriggerElevator();
    }
}
