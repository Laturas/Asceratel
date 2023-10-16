using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IntroManagerScript : MonoBehaviour
{
    [SerializeField] private Animator introAnim;

    public void BeginIntro()
    {
        introAnim.SetTrigger("Activate");
    }
}
