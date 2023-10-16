using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StaticElevator : MonoBehaviour
{
    [SerializeField] private AudioSource doorOpenSound;

    public void OnDoorOpenBegin()
    {
        doorOpenSound.Play();
    }
}
