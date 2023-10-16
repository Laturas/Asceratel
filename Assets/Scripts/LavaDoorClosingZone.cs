using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDoorClosingZone : MonoBehaviour
{
    [SerializeField] private Animator lavaDoorAnimator;
    void OnTriggerEnter(Collider other)
    {
        lavaDoorAnimator.SetTrigger("Close");
    }
}
