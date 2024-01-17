using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] float mouseSensitivity = 100.0f, lookDownClamp = -45f, lookUpClamp = 45f;
    [SerializeField] Transform playerTransf;
    float xRot = 0f;
    
    //Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, lookDownClamp, lookUpClamp);
        transform.localRotation = Quaternion.Euler(xRot, 0f, 0f);
        playerTransf.Rotate(Vector3.up * mouseX);
    }
}
