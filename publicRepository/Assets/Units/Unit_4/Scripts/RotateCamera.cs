using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    [Range(30, 70)]
    [SerializeField] private float rotationSpeed = 50.0f;

    void FixedUpdate()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, horizontalInput * rotationSpeed * Time.deltaTime);
    }
}
