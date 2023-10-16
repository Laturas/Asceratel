using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShoggothTrigger : MonoBehaviour
{
    [SerializeField] private GameObject shoggoth;
    [SerializeField] private GameObject shoggothTrigger;
    [SerializeField] private Animator shoggothAnimator;
    [SerializeField] private Animator ghostLightAnimator;

    void Start()
    {
        shoggoth.SetActive(false);
    }

    public void OnTriggerEnter(Collider other)
    {
        shoggoth.SetActive(true);
        ghostLightAnimator.SetTrigger("fadeOutLight");
        shoggothTrigger.SetActive(false);
        shoggothAnimator.SetTrigger("Open Eyes");
    }
}
