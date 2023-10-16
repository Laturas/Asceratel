using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FirstDoor : MonoBehaviour
{
    [SerializeField] private Animator doorAnimator;
    [SerializeField] private AudioSource leverPull;
    [SerializeField] private AudioSource doorOpening;
    public void OnLeverPulled()
    {
        doorAnimator.SetTrigger("OpenDoor");
        doorOpening.Play();
    }
    public void PlaySound()
    {
        leverPull.Play();
    }
}
