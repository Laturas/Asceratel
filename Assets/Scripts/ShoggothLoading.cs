using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ShoggothLoading : MonoBehaviour
{
    private int sceneToLoad;
    private int sceneToUnload;
    [SerializeField] private int activeScene;

    public void onAwakenComplete()
    {
        sceneToLoad = 7;
        sceneToUnload = 6;
        StartCoroutine(UnloadSceneAsync());
    }

    private IEnumerator UnloadSceneAsync() 
    {
        var progress = SceneManager.UnloadSceneAsync(sceneToUnload);

        while (!progress.isDone) 
        {
            yield return null;
        }
        if (sceneToUnload == 6)
        {
            sceneToUnload = 2;
            StartCoroutine(UnloadSceneAsync());
            StartCoroutine(LoadSceneAsync());
        }
        else
        {
            StartCoroutine(LoadSceneAsync());
        }

        StopCoroutine(UnloadSceneAsync());
        yield break;
    }

    private IEnumerator LoadSceneAsync() 
    {
        var progress = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!progress.isDone) 
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(activeScene));
        StopCoroutine(LoadSceneAsync());
        yield break;
    }
    
}
