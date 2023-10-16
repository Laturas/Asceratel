using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LavaDoorScript : MonoBehaviour
{
    private int sceneToUnload;

    [SerializeField] private AudioSource lavaDoorMove;
    
    public void LavaDoorSound()
    {
        lavaDoorMove.Play();
    }

    public void LavaDoorClosed()
    {
        sceneToUnload = 4;
        StartCoroutine(UnloadSceneAsync());
    }

    private IEnumerator UnloadSceneAsync() 
    {
        var progress = SceneManager.UnloadSceneAsync(sceneToUnload);

        while (!progress.isDone) 
        {
            yield return null;
        }
        StopCoroutine(UnloadSceneAsync());
        yield break;
    }
}
