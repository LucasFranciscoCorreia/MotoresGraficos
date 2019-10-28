using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private const float Y_ANGLE_MIN = 10.0f;
    private const float Y_ANGLE_MAX = 50.0f;

    public Transform lookAt;
    public Transform camTransform;

    Camera camera;
    float distance = 5f;
    float currentX = 0f;
    float currentY = 0f;
    float sensivityX = 4f;
    float sensivityY = 1f;

    CharacterScript character;



    public void Start()
    {
        camTransform = transform;
        camera = Camera.main;
        character = FindObjectOfType<CharacterScript>();
    }

    private void Update()
    {
        if (!character.isTalking)
        {
            currentX += Input.GetAxis("Mouse Y");
            currentY += Input.GetAxis("Mouse X");
            currentX = Mathf.Clamp(currentX, Y_ANGLE_MIN, Y_ANGLE_MAX);
        }
    }

    private void LateUpdate()
    {
        Vector3 dir = new Vector3(0, 0, -distance);
        Quaternion rotation = Quaternion.Euler(currentX, currentY, 0);
        camTransform.position = lookAt.position + rotation * dir;
        camTransform.LookAt(lookAt.position);
    }
}
