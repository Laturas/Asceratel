using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LavaZoneButtonTrigger : MonoBehaviour
{
    [SerializeField] private Animator lavaDoorButtonAnimator;
    [SerializeField] private GameObject lavaDoorButtonTrigger;
    [SerializeField] private RawImage crosshair;
    
    private bool deactivated;
    private bool crosshairActive;

    void Start()
    {
        crosshairActive = false;
        crosshair.color = new Color32(255,255,225,0);
    }

    void OnTriggerEnter(Collider other)
    {
        if (!deactivated) 
        {
            crosshair.color = new Color32(255,255,225,255);
            crosshairActive = true;
        }
    }
    void OnTriggerExit(Collider other)
    {
        if (!deactivated) 
        {
            crosshair.color = new Color32(255,255,225,0);
            crosshairActive = false;
        }
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.E))
        {
            if (crosshairActive)
            {
                lavaDoorButtonAnimator.SetTrigger("PressButton");
                deactivated = false;
                crosshair.color = new Color32(255,255,225,0);
                crosshairActive = false;
                lavaDoorButtonTrigger.SetActive(false);
            }
        }
    }
}
