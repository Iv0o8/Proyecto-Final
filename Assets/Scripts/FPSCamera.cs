using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSCamera : MonoBehaviour
{

    public Vector2 sensibility;
    private new Transform camera;

    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
        camera = transform.Find("Camera");

    }

    void Update()
    {

        float horizontal = Input.GetAxis("Mouse X");
        float vertical = Input.GetAxis("Mouse Y");

        // Rotacion Horizontal
        if (horizontal != 0){

            transform.Rotate(Vector3.up * horizontal * sensibility.x);

        }

        // Rotacion Vertical
        if (vertical != 0){

            float angle = (camera.localEulerAngles.x - vertical * sensibility.y + 360) % 360;
            if (angle > 180) { angle -= 360; }
            angle = Mathf.Clamp(angle, -80, 80);

            camera.localEulerAngles = Vector3.right * angle;

        }
        
    }
}
