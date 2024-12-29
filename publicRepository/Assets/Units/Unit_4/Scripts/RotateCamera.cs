using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Range(50, 150)]
    [SerializeField] private float rotationSpeed = 50.0f;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
