using UnityEngine;

public class Enemy : MonoBehaviour
{
    [Range(150, 300)]
    [SerializeField] private float speed = 180.0f;

    private GameObject player;

    private Rigidbody enemyRb;

    void Start()
    {
        enemyRb = GetComponent<Rigidbody>();
        player = GameObject.Find("Player");
    }

    void Update()
    {
        Vector3 lookDirection = (player.transform.position - transform.position).normalized;
        enemyRb.AddForce(lookDirection * speed);
    }
}
