using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GraveyardUnloadZone : MonoBehaviour
{
    [SerializeField] private ManagerOfScenes managerOfScenes;

    void OnTriggerEnter(Collider other)
    {
        managerOfScenes.UnloadGraveyard();
    }
}
