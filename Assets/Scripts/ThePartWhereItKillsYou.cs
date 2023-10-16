using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code manages killing the player
*/

public class ThePartWhereItKillsYou : MonoBehaviour
{
    [SerializeField] private int savePointNumber;

    [SerializeField] private GameObject player;
    [SerializeField] private Transform playerTransform;
    [SerializeField] private GameObject deathCam;
    [SerializeField] private GameObject blood;
    [SerializeField] private Animator bloodAnimator;
    [SerializeField] private GameSaverScriptableObject gameSaver;

    public void ThePartWhereIKillYou()
    {
        //This is that part
        player.SetActive(false);
        deathCam.SetActive(true);
        blood.SetActive(true);
        bloodAnimator.SetTrigger("Kill");
    }

    public void DeathComplete()
    {
        deathCam.SetActive(false);
        player.SetActive(true);
        switch (gameSaver.getCurrentSavePos())
        {
            case 0:
                playerTransform.transform.position = new Vector3(0, 0, -10);
                break;
            case 1:
                playerTransform.transform.position = new Vector3(-4, -74, 256);
                break;
            case 2:
            //Need to test
                playerTransform.transform.position = new Vector3(123, -38, 552);
                break;
            case 3:
            //Need to test
                playerTransform.transform.position = new Vector3(473, -193, 199);
                break;
            case 4:
                playerTransform.transform.position = new Vector3(459, -493, 198);
                break;
        }
        bloodAnimator.ResetTrigger("Kill");
        bloodAnimator.SetTrigger("FadeOut");
    }
}
