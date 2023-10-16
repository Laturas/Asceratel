using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CongregationScript : MonoBehaviour
{
    [SerializeField] private GameObject congregation;
    [SerializeField] private GameObject congregationTrigger;

    private bool congregationTriggered;

    // Start is called before the first frame update
    void Start()
    {
        congregation.SetActive(false);
    }
    
    public void setCongregation(bool activity)
    {
        //This controls the activity status of the actual people object.
        congregation.SetActive(activity);
    }
    public void OnTriggerEnter(Collider other)
    {
        congregationTriggered = true;
        congregationTrigger.SetActive(false);
    }

    public bool getCongTriggered()
    {
        //Returns whether the trigger has been touched.
        return congregationTriggered;
    }

    public void setCongregationTriggered(bool status)
    {
        congregationTriggered = status;
    }
}
