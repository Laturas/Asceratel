using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skull : MonoBehaviour
{
    [SerializeField] private GameObject asceratelTitle;

    void Start()
    {
        asceratelTitle.SetActive(false);
    }
    public void OnSkullAnimationComplete()
    {
        asceratelTitle.SetActive(true);
    }
}
