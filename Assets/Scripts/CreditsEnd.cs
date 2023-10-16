using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsEnd : MonoBehaviour
{
    [SerializeField] private Animator afterCreditsAnimator;
    [SerializeField] private GameObject afterCredits;
    
    public void CreditsDone()
    {
        afterCredits.SetActive(true);
    }
}
