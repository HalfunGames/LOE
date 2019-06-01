using UnityEngine;

public class cameraControl : MonoBehaviour
{

    public float movementSpeed = 0.5f;
    public float scrollSpeed = 10f;

    public Vector3 min;
    public Vector3 max;

    void Update()
    {
        //movementSpeed = Mathf.Max(movementSpeed += Input.GetAxis("Mouse ScrollWheel"), 0.0f);
        transform.position += (transform.right * Input.GetAxis("Horizontal") + transform.forward * Input.GetAxis("Vertical") + transform.up * Input.GetAxis("Depth") + transform.forward * Input.GetAxis("Mouse ScrollWheel") * scrollSpeed) * movementSpeed;
        if (Input.GetMouseButton(2))
        {
            transform.eulerAngles += new Vector3(-Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }
        transform.position = new Vector3(
        Mathf.Clamp(transform.position.x, min.x, max.x),
        Mathf.Clamp(transform.position.y, min.y, max.y),
        Mathf.Clamp(transform.position.z, min.z, max.z));

    }
}