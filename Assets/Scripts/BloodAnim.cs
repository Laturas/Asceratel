using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodAnim : MonoBehaviour
{
    [SerializeField] private ThePartWhereItKillsYou thePartWhereItKillsYou;
    [SerializeField] private GameObject blood;

    public void OnDeathFinished()
    {
        thePartWhereItKillsYou.DeathComplete();
    }
    public void FadedOut()
    {
        blood.SetActive(false);
    }
}
