using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NoiseMeter : MonoBehaviour
{
    private int noiseDueToNormalMovement;
    private int noiseDueToSpeederMovement;
    private int noiseDueToCamera;

    private int pings;
    private int stage;

    private bool normalMovementActive;
    private bool speederMovementActive;
    private bool cameraActive;

    [Header("Actual Noise Meter Stuff")]
    [SerializeField] private Slider slider;
    [SerializeField] private Gradient gradient;
    [SerializeField] private Image fill;

    [Header("Everything Else")]
    [SerializeField] private Animator movementWarning;
    [SerializeField] private ThePartWhereItKillsYou thePartWhereItKillsYou;

    //*****READ ONLY*****//
    public int totalNoise;
    //*******************//
    public void normalMovement(bool activity)
    {
        normalMovementActive = activity;
    }
    public void speederMovement(bool activity)
    {
        speederMovementActive = activity;
    }
    public void cameraNoise(bool activity)
    {
        cameraActive = activity;
    }

    void Start()
    {
        stage = 0;
    }

    private void FixedUpdate()
    {
        //Welcome to hell
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.S)) 
        {
            normalMovementActive = true;
        }
        else 
        {
            normalMovementActive = false;
        }

        // Normal Movement
        if (normalMovementActive) 
        {
            if (noiseDueToNormalMovement < 200)
            {
                noiseDueToNormalMovement = noiseDueToNormalMovement + 20;
            }
        } 
        else 
        {
            if (noiseDueToNormalMovement > 0)
            {
                noiseDueToNormalMovement = noiseDueToNormalMovement - 2;
            }
        }
        // Speeder Movement
        if (speederMovementActive) 
        {
            if (noiseDueToSpeederMovement < 200)
            {
                noiseDueToSpeederMovement = noiseDueToSpeederMovement + 20;
            }
        } 
        else 
        {
            if (noiseDueToSpeederMovement > 0)
            {
                noiseDueToSpeederMovement = noiseDueToSpeederMovement - 2;
            }
        }
        // Camera Noise
        if (cameraActive) 
        {
            if (noiseDueToCamera < 400)
            {
                noiseDueToCamera = noiseDueToCamera + 100;
            }
        } 
        else 
        {
            if (noiseDueToCamera > 0)
            {
                noiseDueToCamera = noiseDueToCamera - 2;
            }
        }
        totalNoise = noiseDueToNormalMovement + noiseDueToSpeederMovement + noiseDueToCamera;
        slider.value = totalNoise;
        fill.color = gradient.Evaluate(slider.normalizedValue);
    }

    public void TriggerEnemy()
    {
        pings = 0;
        stage = 0;
        movementWarning.ResetTrigger("DisableWarning");
        movementWarning.SetTrigger("Warning");
    }
    public void TriggerSpecter()
    {
        pings = 0;
        stage = 3;
        movementWarning.ResetTrigger("DisableWarning");
        movementWarning.SetTrigger("Medium Warning");
    }

    /**
    * Stage 0 = Slow pinging (default)
    * Stage 1 = Medium pinging (default)
    * Stage 2 = High ping (default)
    * ----------------------------------
    * Stage 3 = Medium ping (specter)
    * Stage 4 = High ping (specter)
    */
    public void Ping()
    {
        switch (stage)
        {
            case 0:
                if (totalNoise < 50)
                {
                    movementWarning.SetTrigger("DisableWarning");
                    movementWarning.ResetTrigger("Warning");
                    pings = 0;
                    stage = 0;
                    break;
                }
                pings++;
                if (pings >= 3)
                {
                    pings = 0;
                    movementWarning.SetTrigger("Medium Warning");
                    movementWarning.ResetTrigger("Warning");
                    stage = 1;
                }
                break;
            case 1:
                if (totalNoise < 50)
                {
                    movementWarning.SetTrigger("DisableWarning");
                    movementWarning.ResetTrigger("Medium Warning");
                    pings = 0;
                    stage = 0;
                    break;
                }
                pings++;
                if (pings >= 5)
                {
                    pings = 0;
                    movementWarning.SetTrigger("High Warning");
                    movementWarning.ResetTrigger("Medium Warning");
                    stage = 2;
                }
                break;
            case 2:
                if (totalNoise < 50)
                {
                    movementWarning.SetTrigger("DisableWarning");
                    movementWarning.ResetTrigger("High Warning");
                    pings = 0;
                    stage = 0;
                    break;
                }
                pings++;
                if (pings >= 10)
                {
                    pings = 0;
                    stage = 0;
                    movementWarning.SetTrigger("DisableWarning");
                    movementWarning.ResetTrigger("High Warning");
                    movementWarning.ResetTrigger("Medium Warning");
                    
                    thePartWhereItKillsYou.ThePartWhereIKillYou();
                }
                break;
            case 3:
                //**SPECTER ENEMY ONLY**
                if (totalNoise < 25)
                {
                    movementWarning.SetTrigger("DisableWarning");
                    movementWarning.ResetTrigger("Medium Warning");
                    pings = 0;
                    stage = 0;
                    break;
                }
                pings++;
                if (pings >= 5)
                {
                    pings = 0;
                    movementWarning.SetTrigger("High Warning");
                    movementWarning.ResetTrigger("Medium Warning");
                    stage = 4;
                }
                break;
            case 4:
                if (totalNoise < 25)
                {
                    movementWarning.SetTrigger("DisableWarning");
                    movementWarning.ResetTrigger("High Warning");
                    pings = 0;
                    stage = 0;
                    break;
                }
                pings++;
                if (pings >= 10)
                {
                    pings = 0;
                    stage = 0;
                    movementWarning.SetTrigger("DisableWarning");
                    movementWarning.ResetTrigger("High Warning");
                    movementWarning.ResetTrigger("Medium Warning");
                    
                    thePartWhereItKillsYou.ThePartWhereIKillYou();
                }
                break;
        }
    }
}
