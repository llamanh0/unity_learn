using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Range(150, 450)]
    [SerializeField] private float speed = 300.0f;

    [SerializeField] private GameObject focalPoint;

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        rb.AddForce(focalPoint.transform.forward * forwardInput * speed);
    }
}
