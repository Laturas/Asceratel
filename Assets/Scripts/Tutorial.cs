using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tutorial : MonoBehaviour
{
    [SerializeField] private Animator wsAnimator;
    [SerializeField] private Animator shiftAnimator;
    [SerializeField] private Animator fAnimator;
    [SerializeField] private Animator clickAnimator;

    [SerializeField] private GameObject wsTut;
    [SerializeField] private GameObject shiftTut;
    [SerializeField] private GameObject fTut;
    [SerializeField] private GameObject clickTut;

    [SerializeField] private int stage;

    void Start()
    {
        wsAnimator.SetTrigger("TutFadeIn");
        stage = 1;
        shiftTut.SetActive(false);
    }

    void Update()
    {
        switch (stage)
        {
            case 0:
                break;
            case 1:
                if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S))
                {
                    shiftTut.SetActive(true);
                    wsAnimator.SetTrigger("TutFadeOut");
                    shiftAnimator.SetTrigger("ShiftTutBegin");
                    stage = 2;
                }
                break;
            case 2:
                if (Input.GetKey(KeyCode.LeftShift))
                {
                    wsTut.SetActive(false);
                    shiftAnimator.SetTrigger("ShiftTutEnd");
                    fAnimator.SetTrigger("BeginFTut");
                    stage = 3;
                }
                break;
            case 3:
                if (Input.GetMouseButtonDown(1))
                {
                    //All of this code refers to "F" since F used to be the
                    //Button that pulled up the camera. Too lazy to change.
                    fAnimator.SetTrigger("EndFTut");
                    clickAnimator.SetTrigger("BeginClickTut");
                    stage = 4;
                }
                break;
            case 4:
                if (Input.GetMouseButtonDown(0))
                {
                    wsTut.SetActive(false);
                    shiftTut.SetActive(false);
                    fTut.SetActive(false);
                    clickTut.SetActive(false);
                    stage = 5;
                }
                break;
            case 5:
                break;
        }
    }
}
