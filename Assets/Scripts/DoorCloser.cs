using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorCloser : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;

    void OnTriggerEnter(Collider other)
    {
        doorAnimator.ResetTrigger("OpenDoor");
        doorAnimator.SetTrigger("CloseDoor");
    }
}
