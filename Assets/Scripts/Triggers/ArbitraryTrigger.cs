using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArbitraryTrigger : MonoBehaviour
{
    [SerializeField] TriggersScriptableObject triggerSO;

    [Header("Optional stuff")]
    [SerializeField] GameObject optionalGameObject;

    void OnTriggerEnter(Collider other)
    {
        triggerSO.triggerEntered(transform.gameObject.name, optionalGameObject);
        Destroy(this);
    }
}
