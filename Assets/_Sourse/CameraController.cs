using UnityEngine;

public class CameraController : MonoBehaviour
{
    public float speed = 2.0f;
    public float sensitivity = 2.0f;

    private float x = 0.0f;
    private float y = 0.0f;

    void Update()
    {
        x += Input.GetAxis("Mouse X") * sensitivity;
        y -= Input.GetAxis("Mouse Y") * sensitivity;

        transform.eulerAngles = new Vector3(y, x, 0.0f);
    }
}