using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GameSaverScriptableObject", menuName = "ScriptableObjects/SavePos")] 
public class GameSaverScriptableObject : ScriptableObject
{
    [SerializeField] private int currentSavePos = 0;

    void Start()
    {
        currentSavePos = 0;
    }

    public void updateSavePos(int savePos)
    {
        currentSavePos = savePos;
    }

    public int getCurrentSavePos()
    {
        return currentSavePos;
    }
}
