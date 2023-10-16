using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CityLoadingTrigger : MonoBehaviour
{
    [SerializeField] private ManagerOfScenes managerOfScenes;
    private bool loaded;

    void OnTriggerEnter(Collider other)
    {
        if (!loaded)
        {
            managerOfScenes.LoadCity();
            loaded = true;
        }
    }
}
