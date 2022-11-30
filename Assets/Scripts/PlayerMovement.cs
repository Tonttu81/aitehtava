using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] float movementSpeed;
    [SerializeField] float mouseSensitivity;

    [SerializeField] Transform cameraTransform;
    [SerializeField] CharacterController characterController;

    float xRotation = 0;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        //movement
        float movementX = Input.GetAxisRaw("Horizontal");
        float movementZ = Input.GetAxisRaw("Vertical");

        Vector3 movement = transform.right * movementX + transform.forward * movementZ;
        characterController.Move(movement * movementSpeed * Time.deltaTime);

        //camera
        float x = Input.GetAxis("Mouse X");
        float y = Input.GetAxis("Mouse Y");

        xRotation -= y;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        cameraTransform.localRotation = Quaternion.Euler(xRotation, 0, 0);
        transform.Rotate(Vector3.up * x);
    }
}
