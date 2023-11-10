using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private float Xsensitivity;
    private float Ysensitivity;
    [SerializeField] private SettingsScriptableObj settings;
    [SerializeField] private CameraInfoScriptableObject camInfo;

    private float xRotation;
    private float yRotation;
    
    private float Xrot;
    private float Yrot;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        settings.updateSensitivity(500F);
    }

    // Update is called once per frame
    void Update()
    {
        SetSensitivity(settings.getSensitivity());

        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * Xsensitivity;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * Ysensitivity;
    
        yRotation += mouseX;

        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);

        camInfo.setRotValues(transform.rotation.eulerAngles.x);
    }

    public void SetSensitivity(float sensitive)
    {
        Xsensitivity = sensitive;
        Ysensitivity = sensitive;
    }
}
