using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyTheGame : MonoBehaviour
{
    public void KillMe()
    {
        //Shamelessly stolen code from some guy on StackOverflow
        #if UNITY_STANDALONE
            Application.Quit();
        #endif
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
    }
}
