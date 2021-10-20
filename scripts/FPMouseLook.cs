using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPMouseLook : MonoBehaviour
{
    Transform CameraTransform;
    Vector3 CameraRotation;
    public float MouseSensitivity;
    public Vector2 MaxAngleX;
    
    public Transform characterTransform;
    // Start is called before the first frame update
    void Start()
    {
        CameraTransform = GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        var mouseX = Input.GetAxis("Mouse X");
        var mouseY = Input.GetAxis("Mouse Y");
        CameraRotation.y += mouseX * MouseSensitivity;
        CameraRotation.x += mouseY * MouseSensitivity;
        CameraRotation.x = Mathf.Clamp(CameraRotation.x, MaxAngleX.x, MaxAngleX.y);
        
        CameraTransform.rotation = Quaternion.Euler(CameraRotation.x,CameraRotation.y, 0);
        characterTransform.rotation = Quaternion.Euler(0, CameraRotation.y, 0);
    }
}
