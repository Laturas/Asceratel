using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroBG : MonoBehaviour
{
    [SerializeField] private GameObject textObj;
    [SerializeField] private GameObject bgObj;
    [SerializeField] private Animator textAnimator;
    [SerializeField] private Animator bgAnimator;
    [SerializeField] private FaderScript fadeScript;

    private bool fadeDone;
    private bool completelyFinished;

    public void OnFadeInDone()
    {
        textObj.SetActive(true);
        fadeDone = true;
    }

    void Update()
    {
        if (fadeDone && !completelyFinished)
        {
            if (Input.GetKey(KeyCode.Return))
            {
                textAnimator.SetTrigger("TxtFadeOut");
                bgAnimator.SetTrigger("FadeOut");
                completelyFinished = true;
            }
        }
    }

    public void FadedOut()
    {
        fadeScript.beginProper();
        bgObj.SetActive(false);
        textObj.SetActive(false);
    }
}
