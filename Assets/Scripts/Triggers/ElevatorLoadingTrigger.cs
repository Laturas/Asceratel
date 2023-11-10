using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElevatorLoadingTrigger : MonoBehaviour
{
    [SerializeField] private ManagerOfScenes sceneManager;
    [SerializeField] private GameObject elevatorLoadingTrigger;

    private bool triggered = false;
    
    void OnTriggerEnter(Collider other)
    {
        if (!triggered)
        {
            triggered = true;
            StartCoroutine(elevationLoading());
        }
    }
    IEnumerator elevationLoading()
    {
        yield return new WaitForSeconds(3F);
        sceneManager.UnloadCity();
        sceneManager.LoadFinalChamber();
        elevatorLoadingTrigger.SetActive(false);
    }
}
