using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LCLoadingZone : MonoBehaviour
{
    [SerializeField] private ManagerOfScenes managerOfScenes;
    private bool loaded;

    void OnTriggerEnter(Collider other)
    {
        if (!loaded)
        {
            managerOfScenes.LoadLavaZone();
            loaded = true;
        }
    }
}
