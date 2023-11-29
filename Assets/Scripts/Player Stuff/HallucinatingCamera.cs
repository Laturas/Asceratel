using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HallucinatingCamera : MonoBehaviour
{
    private Camera thisCam;
    private bool sequencing;
    void Awake()
    {
        thisCam = GetComponent<Camera>();
        sequencing = false;
    }

    public void BeginSeq()
    {
        sequencing = true;
    }

    void Update()
    {
        if (sequencing && thisCam.nearClipPlane > 0.01)
        {
            thisCam.nearClipPlane -= Time.deltaTime * 10f;
            if (thisCam.nearClipPlane < 0.01f)
            {
                thisCam.nearClipPlane = 0.01f;
            }
        }
        else
        {
            sequencing = false;
        }
    }
}
