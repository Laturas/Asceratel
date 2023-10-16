using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LostCamScript : MonoBehaviour
{
    private bool triggered;
    private bool waiting;
    [SerializeField] private GameObject lostCam;
    [SerializeField] private GameObject screenCam;
    [SerializeField] private RawImage crosshair;

    void Start()
    {
        waiting = false;
        crosshair.color = new Color32(255,255,225,0);
    }

    void OnTriggerEnter(Collider other)
    {
        waiting = true;
        crosshair.color = new Color32(255,255,225,255);
    }

    void OnTriggerExit(Collider other)
    {
        waiting = false;
        crosshair.color = new Color32(255,255,225,0);
    }

    void Update()
    {
        if (waiting && Input.GetKey(KeyCode.E))
        {
            if (!triggered)
            {
                crosshair.color = new Color32(255,255,225,0);
                triggered = true;
                screenCam.SetActive(true);
                lostCam.SetActive(false);
            }
        }
    }
}
