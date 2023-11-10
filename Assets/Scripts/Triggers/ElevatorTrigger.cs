using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorTrigger : MonoBehaviour
{
    [SerializeField] private Animator elevatorAnimator;
    [SerializeField] private GameObject elevatorTrigger;
    //[SerializeField] private Light playerLight;

    void OnTriggerEnter(Collider other)
    {
        //playerLight.intensity = 0.0F;
        elevatorAnimator.ResetTrigger("OpenDoor");
        elevatorAnimator.SetTrigger("CloseDoor");
        elevatorTrigger.SetActive(false);
    }
}
