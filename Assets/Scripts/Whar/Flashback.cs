using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashback : MonoBehaviour
{
    [SerializeField] private GameObject spookySoundSource;

    void Awake()
    {
        spookySoundSource.SetActive(false);
    }

    public void BeginSequence()
    {
        
    }
}
