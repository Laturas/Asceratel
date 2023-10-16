using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AfterCreditsEnjoyer : MonoBehaviour
{
    [SerializeField] private GameObject afterCredits;
    [SerializeField] private Animator afterCreditsAnimator;

    private bool waiting;

    public void OnAfterCreditsLoaded()
    {
        waiting = true;
    }

    void Update()
    {
        if (waiting)
        {
            if (Input.GetKeyDown(KeyCode.Return))
            {
                afterCreditsAnimator.SetTrigger("Close");
            }
        }
    }
}
