using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WatcherTrigger : MonoBehaviour
{
    [SerializeField] private GameObject watchers;
    [SerializeField] private GameObject trigger;

    void OnTriggerEnter(Collider other)
    {
        watchers.SetActive(true);
        trigger.SetActive(false);
    }
}
