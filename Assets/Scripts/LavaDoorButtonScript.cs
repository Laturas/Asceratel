using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDoorButtonScript : MonoBehaviour
{
    [SerializeField] private Animator lavaDoorAnimator;
    public void FinishPressed()
    {
        lavaDoorAnimator.SetTrigger("Move");
    }
}
