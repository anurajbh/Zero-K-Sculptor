using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    float maxMouse;
    public Transform playerBody;

    float xRotation = 0;

    public TimeProgression time;
    private void Awake()
    {
        Cursor.lockState = CursorLockMode.Locked;
        maxMouse = mouseSensitivity;
        time = GameObject.Find("Time").GetComponent<TimeProgression>();
        InvokeRepeating("SlowCam", 1f, 1f);

    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;


        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        playerBody.Rotate(Vector3.up * mouseX);

    }

    private void SlowCam()
    {
        mouseSensitivity = time.SlowDownGame(mouseSensitivity, maxMouse);
    }
}
