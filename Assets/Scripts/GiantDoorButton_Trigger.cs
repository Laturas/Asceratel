using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GiantDoorButton_Trigger : MonoBehaviour
{
    [SerializeField] private Animator giantDoorButtonAnimator;
    [SerializeField] private GameObject giantDoorButtonTrigger;
    [SerializeField] private RawImage crosshair;
    //[SerializeField] private Animator leverAnimator;
    //[SerializeField] private FirstDoor firstDoor;
    
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
        Debug.Log("You ever wonder why we're here?");
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
                giantDoorButtonAnimator.SetTrigger("ButtonPressed");
                deactivated = false;
                crosshair.color = new Color32(255,255,225,0);
                crosshairActive = false;
                giantDoorButtonTrigger.SetActive(false);
            }
        }
    }
}
