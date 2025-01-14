using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private GameObject camera;
    private Rigidbody rb;

    private float mouseX, mouseY, xRotation, yRotation;
    public float mouseSensitivity;
    private float inputH, inputV;
    public float moveSpeed;

    private void Awake()
    {
        camera = transform.GetChild(0).gameObject;
        rb = GetComponent<Rigidbody>();
    }

    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;

        transform.localRotation = Quaternion.identity;
        camera.transform.localRotation = Quaternion.identity;
    }

    private void Update()
    {
        //�ӽ��ƶ�
        mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation += mouseY;
        xRotation = Mathf.Clamp(xRotation, -90, 90);
        yRotation += mouseX;

        transform.localRotation = Quaternion.Euler(0, yRotation, 0);
        camera.transform.localRotation = Quaternion.Euler(-xRotation, 0, 0);

        //����ƶ�
        inputH = Input.GetAxis("Horizontal") * moveSpeed * Time.deltaTime;
        inputV = Input.GetAxis("Vertical") * moveSpeed * Time.deltaTime;
        transform.Translate(new Vector3(inputH, 0, inputV), relativeTo: Space.Self);
    }
}
