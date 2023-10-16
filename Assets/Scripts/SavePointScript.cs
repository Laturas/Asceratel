using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SavePointScript : MonoBehaviour
{
    [SerializeField] private GameSaverScriptableObject gameSaver;
    [SerializeField] private int savePosNumber;

    private bool triggered = false;

    void OnTriggerEnter (Collider other)
    {
        if (!triggered)
        {
            gameSaver.updateSavePos(savePosNumber);
            triggered = true;
        }
    }
}
