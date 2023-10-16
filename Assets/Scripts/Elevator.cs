using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    [SerializeField] private Animator elevatorAnimator;
    [SerializeField] private Animator elevator2Animator;
    [SerializeField] private Transform elevatorTransform;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private Light playerLight;
    [SerializeField] private AudioSource doorOpenSound;
    [SerializeField] private GameObject rideSound;

    public void DoorCloseFinished()
    {
        StartCoroutine(elevation());
    }

    public void OpenDoor()
    {
        //elevatorAnimator.ResetTrigger("CloseDoor");
        //elevatorAnimator.SetTrigger("OpenDoor");
        playerTransform.position = new Vector3(playerTransform.position.x, playerTransform.position.y-195.28F, playerTransform.position.z);
        elevator2Animator.SetTrigger("OpenElevator");
    }

    public void DoorOpenFinished()
    {
        playerLight.range = 10F;
        playerLight.intensity = 1F;
    }

    public void DoorOpenBegin()
    {
        doorOpenSound.Play();
    }

    IEnumerator elevation()
    {
        rideSound.SetActive(true);
        yield return new WaitForSeconds(10.0F);
        OpenDoor();
    }
}
