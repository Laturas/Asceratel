using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTrigger : MonoBehaviour
{
    [SerializeField] private NoiseMeter noiseMeter;
    [SerializeField] private SharkScript sharkScriptObj;
    [SerializeField] private bool triggersShark;

    private bool triggered;

    public void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            noiseMeter.TriggerEnemy();
            triggered = true;
            if (triggersShark)
            {
                sharkScriptObj.triggerShark();
            }
        }
    }
}
