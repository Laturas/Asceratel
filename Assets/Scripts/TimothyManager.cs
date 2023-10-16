using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimothyManager : MonoBehaviour
{
    //True if it activates Timothy, false if it deactivates him.
    [Header("Type of Object")]
    [SerializeField] private bool timothyActivator;

    [Header("GameObjects")]
    [SerializeField] private GameObject timothy;
    [SerializeField] private GameObject timothyNoise;
    [SerializeField] private GameObject trigger;

    public void OnTriggerEnter(Collider other)
    {
        timothy.SetActive(timothyActivator);
        if (timothyActivator)
        {
            timothyNoise.SetActive(timothyActivator);
        }
        trigger.SetActive(false);
    }
}
