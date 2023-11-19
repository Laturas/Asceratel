using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;

public class CameraLook : MonoBehaviour
{
    private float Xsensitivity;
    private float Ysensitivity;
    [SerializeField] private SettingsScriptableObj settings;
    [SerializeField] private CameraInfoScriptableObject camInfo;
    [SerializeField] private Volume postProcessorVolume;

    private ColorAdjustments colorAdj;

    private float xRotation;
    private float yRotation;
    
    private float Xrot;
    private float Yrot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settings.UpdateSetting(500F, "Sensitivity Slider");
    }

    // Update is called once per frame
    void Update()
    {
        SetSensitivity(settings.getSensitivity());
        SetBrightness(settings.GetBrightness());

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Xsensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Ysensitivity;
    
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        camInfo.setRotValues(transform.rotation.eulerAngles.x);
    }

    public void SetBrightness(float brightness)
    {
        if (colorAdj == null && postProcessorVolume.profile.TryGet<ColorAdjustments>(out colorAdj))
        {
            colorAdj.postExposure.value = brightness;
        }
        else if (colorAdj != null)
        {
            colorAdj.postExposure.value = brightness;
        }
    }

    public void SetSensitivity(float sensitive)
    {
        Xsensitivity = sensitive;
        Ysensitivity = sensitive;
    }

    public void shakeCam()
    {
        StartCoroutine(camShake());
    }

    IEnumerator camShake()
    {
        Vector3 oldPos = transform.position;

        float shakeMagnitude = 0.5f;

        while (shakeMagnitude > 0f)
        {
            float x = UnityEngine.Random.Range(-1f, 1f) * shakeMagnitude;
            float y = UnityEngine.Random.Range(-1f, 1f) * shakeMagnitude;
            float z = UnityEngine.Random.Range(-1f, 1f) * shakeMagnitude;

            transform.position = new Vector3(
                oldPos.x + x,
                oldPos.y + y,
                oldPos.z + z);

            shakeMagnitude -= Time.deltaTime;
            yield return null;
        }
        transform.position = oldPos;
        yield return null;
    }
}
