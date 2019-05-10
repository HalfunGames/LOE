using UnityEngine;

public class cameraControl : MonoBehaviour
{

    private static float movementSpeed = 0.5f;

    void Update()
    {
        movementSpeed = Mathf.Max(movementSpeed += Input.GetAxis("Mouse ScrollWheel"), 0.0f);
        transform.position += (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical") + transform.up * Input.GetAxis("Depth")) * movementSpeed;
        if (Input.GetMouseButton(2))
        {
            transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }
    }
}