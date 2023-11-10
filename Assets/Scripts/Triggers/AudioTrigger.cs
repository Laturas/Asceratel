using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    //This is a general audio trigger that should (hopefully)
    //Work for any audio source that needs to be triggered in the game.

    [SerializeField] private GameObject trigger;
    [SerializeField] private GameObject source;

    public void OnTriggerEnter(Collider other)
    {
        source.SetActive(true);
        trigger.SetActive(false);
    }
}
