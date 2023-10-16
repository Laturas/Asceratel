using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpecterTrigger : MonoBehaviour
{
    [SerializeField] private NoiseMeter noiseMeter;

    private bool triggered;

    public void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            noiseMeter.TriggerSpecter();
            triggered = true;
        }
    }
}
