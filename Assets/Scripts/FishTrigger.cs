using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishTrigger : MonoBehaviour
{
    [SerializeField] private GameObject leftFishSpawner;
    [SerializeField] private GameObject rightFishSpawner;

    void OnTriggerEnter(Collider other)
    {
        leftFishSpawner.SetActive(false);
        rightFishSpawner.SetActive(false);
    }
    void OnTriggerExit(Collider other)
    {
        leftFishSpawner.SetActive(true);
        rightFishSpawner.SetActive(true);
    }
}
