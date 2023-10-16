using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AmberEyesTrigger : MonoBehaviour
{
    [SerializeField] private Animator amberEyeAnimator;
    void OnTriggerEnter(Collider other)
    {
        amberEyeAnimator.SetTrigger("CloseEyes");
    }
}
