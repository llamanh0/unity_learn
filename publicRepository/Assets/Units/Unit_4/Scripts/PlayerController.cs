using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{
    [Range(150, 450)]
    [SerializeField] private float speed = 300.0f;
    [SerializeField] private float powerUpStrenght = 900.0f;

    [SerializeField] private GameObject focalPoint;
    [SerializeField] private GameObject powerupIndicator;

    private Rigidbody rb;

    public bool hasPowerUp = false;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        float forwardInput = Input.GetAxis("Vertical");

        rb.AddForce(focalPoint.transform.forward * forwardInput * speed);

        FollowThePlayer();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Powerup"))
        {
            hasPowerUp = true;
            powerupIndicator.gameObject.SetActive(true);
            Destroy(other.gameObject);
            StartCoroutine(PowerupCountdownRoutine());
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy") && hasPowerUp)
        {
            Rigidbody enemyRigidbody = collision.gameObject.GetComponent<Rigidbody>();
            Vector3 awayFromPlayer = collision.gameObject.transform.position - transform.position;
            enemyRigidbody.AddForce(awayFromPlayer * powerUpStrenght, ForceMode.Impulse);
            Debug.Log("Collided with " + collision.gameObject.name + "with powerup set to " + hasPowerUp);
        }
    }

    IEnumerator PowerupCountdownRoutine()
    {
        yield return new WaitForSeconds(7);
        hasPowerUp = false;
        powerupIndicator.gameObject.SetActive(false);
    }

    private void FollowThePlayer()
    {
        powerupIndicator.gameObject.transform.position = transform.position + new Vector3(0, -.5f, 0);
    }
   
}
