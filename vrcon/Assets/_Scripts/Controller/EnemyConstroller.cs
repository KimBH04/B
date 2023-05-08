using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstroller : MonoBehaviour
{
    public float Speed = 5f;

    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) > 5f)
        {
            Vector3 direction = (player.position - transform.position).normalized;
            rb.MovePosition(transform.position + Speed * Time.deltaTime * direction);
        }
    }
}
