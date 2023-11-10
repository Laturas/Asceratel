using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioTrigger : MonoBehaviour
{
    //This is a general audio trigger that should (hopefully)
    //Work for any audio source that needs to be triggered in the game.

    [SerializeField] private GameObject trigger;
    private Collider triggerCol;
    [SerializeField] private GameObject source;
    private AudioSource audSource;
    private bool paused;
    void Awake()
    {
        triggerCol = trigger.GetComponent<Collider>();
        audSource = source.GetComponent<AudioSource>();
    }

    public void OnTriggerEnter(Collider other)
    {
        source.SetActive(true);
        Destroy(triggerCol);
    }

    void Update()
    {
        if (paused)
        {
            if (Time.timeScale > 0.000001f)
            {
                audSource.Play();
                paused = false;
                return;
            }
            return;
        }
        if (Time.timeScale < 0.000001f)
        {
            audSource.Pause();
            paused = true;
        }
    }
}
