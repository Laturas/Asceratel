using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaDoorButtonScript : MonoBehaviour
{
    [SerializeField] private Animator lavaDoorAnimator;
    private AudioSource source;
    public void FinishPressed()
    {
        source = lavaDoorAnimator.gameObject.GetComponent<AudioSource>();
        lavaDoorAnimator.SetTrigger("Move");
        if (!source.isPlaying)
        {
            source.Play();
        }
    }
}
