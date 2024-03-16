using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Camera mainCamera;

    // Start is called before the first frame update
    void Start()
    {
        GameManager.Input.keyAction -= MainCameraMove;
        GameManager.Input.keyAction += MainCameraMove;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MainCameraMove()
    {
        if (Input.GetMouseButton(1)) 
        {
            // Get mouse movement
            float mouseX = Input.GetAxis("Mouse X");
            float mouseY = Input.GetAxis("Mouse Y");

            // Calculate movement direction based on mouse input
            Vector3 moveDirection = new Vector3(mouseX, mouseY, 0f);
            moveDirection.Normalize(); // Normalize to ensure consistent speed in all directions

            // Move the camera along the x and y axes
            mainCamera.transform.Translate(moveDirection * -10.0F * Time.deltaTime);

        }
    }
}
