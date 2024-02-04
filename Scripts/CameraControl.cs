using UnityEngine;

public class CameraControl : MonoBehaviour
{

    public Rigidbody playerRigidbody;
    public Transform cameraTransform;

    float xRot;
    float yRot;

    public float xSens;
    public float ySens;

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
    }

    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * xSens;
        float mouseY = Input.GetAxis("Mouse Y") * ySens;

        yRot += mouseX;
        xRot -= mouseY;
        xRot = Mathf.Clamp(xRot, -90f, 90f);
        playerRigidbody.MoveRotation(Quaternion.Euler(0, yRot, 0));
        cameraTransform.rotation = Quaternion.Euler(xRot, yRot, 0);
    }
}