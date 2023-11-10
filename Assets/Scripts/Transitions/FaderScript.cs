using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaderScript : MonoBehaviour
{
    public Animator animator;
    [SerializeField] private ManagerOfScenes managerOfScenes;
    [SerializeField] private GameObject bgIntroAnimator;
    [SerializeField] private GameObject goofyObjects;
    
    private bool newGame;

    // Start is called before the first frame update
    public void OnFadeComplete()
    {
        //managerOfScenes.FadeCompleted();
        if (newGame)
        {
            bgIntroAnimator.SetActive(true);
        }
        else
        {
            managerOfScenes.FadeCompleted();
            goofyObjects.SetActive(true);
        }
    }

    public void beginProper()
    {
        managerOfScenes.FadeCompleted();
        goofyObjects.SetActive(true);
    }

    public void triggerFade(bool fading, bool newStatus)
    {
        newGame = newStatus;
        if (fading) 
        {
            animator.ResetTrigger("Unfade");
            animator.SetTrigger("Fade");
        }
        else
        {
            animator.ResetTrigger("Fade");
            animator.SetTrigger("Unfade");
        }
    }
}
