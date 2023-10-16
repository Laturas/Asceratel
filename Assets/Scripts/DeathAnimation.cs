using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathAnimation : MonoBehaviour
{
    private int sceneToLoad;
    private int sceneToUnload;
    public void BloodFadeDone()
    {
        sceneToUnload = 8;
        StartCoroutine(UnloadSceneAsync());
    }

    private IEnumerator LoadSceneAsync() 
    {
        var progress = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!progress.isDone) 
        {
            yield return null;
        }
        StopCoroutine(LoadSceneAsync());
        yield break;
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
