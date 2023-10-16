using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerOfScenes : MonoBehaviour
{
    private int sceneToLoad;
    private int sceneToUnload;
    [SerializeField] private int activeScene;
    [SerializeField] private int initialLevel;
    [SerializeField] private GameObject menuUi;
    [SerializeField] private GameObject version;
    [SerializeField] private FaderScript faderScript;

    public void NewGame() 
    {
        //Begins a new game
        //WARNING: Should only ever be called from the New Game button on the main menu. Do not ever call from elsewhere.
        faderScript.triggerFade(true, true);

        //starts fading
        //animator.SetTrigger("FadeOut");
    }

    public void ContinueGame()
    {
        faderScript.triggerFade(true, false);
        //Continues from the last save point.
    }

    void Awake()
    {
        if (activeScene != 1) 
        {
            sceneToLoad = 1;
            activeScene = 1;
            StartCoroutine(LoadLevelAsync());
        }
    }

    /*public void FadeToLevel (int levelIndex) 
    {
        //sets the levelToLoad variable to the levelIndex value so we can use it in the next function
        levelToLoad = levelIndex;
        //starts fading
        animator.SetTrigger("FadeOut");
    }*/
    
    public void LoadLavaZone()
    {
        sceneToLoad = 4;
        StartCoroutine(LoadLevelAsync());
    }
    public void UnloadGraveyard()
    {
        sceneToUnload = 3;
        StartCoroutine(UnloadSceneAsync());
    }
    public void LoadCity()
    {
        sceneToLoad = 5;
        StartCoroutine(LoadLevelAsync());
    }
    public void UnloadCity()
    {
        sceneToUnload = 5;
        StartCoroutine(UnloadSceneAsync());
    }
    public void LoadFinalChamber()
    {
        sceneToLoad = 6;
        StartCoroutine(LoadLevelAsync());
    }
    public void UnloadFinalChamber()
    {
        sceneToUnload = 6;
        StartCoroutine(UnloadSceneAsync());
    }

    public void FadeCompleted() 
    {
        activeScene = 2;
        sceneToLoad = 2;
        StartCoroutine(LoadLevelAsync());
        sceneToLoad = 3;
        StartCoroutine(LoadLevelAsync());

        sceneToUnload = 1;
        StartCoroutine(UnloadSceneAsync());
        menuUi.SetActive(false);
        version.SetActive(false);

        faderScript.triggerFade(false, false);
    }
    
    private IEnumerator LoadLevelAsync() 
    {
        var progress = SceneManager.LoadSceneAsync(sceneToLoad, LoadSceneMode.Additive);

        while (!progress.isDone) 
        {
            yield return null;
        }
        SceneManager.SetActiveScene(SceneManager.GetSceneByBuildIndex(activeScene));
        StopCoroutine(LoadLevelAsync());
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
