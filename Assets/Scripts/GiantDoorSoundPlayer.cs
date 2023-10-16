using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiantDoorSoundPlayer : MonoBehaviour
{
    [SerializeField] AudioSource bigDoorSoundEffect;
    public void onAnimationBegin()
    {
        bigDoorSoundEffect.Play();
    }
}
