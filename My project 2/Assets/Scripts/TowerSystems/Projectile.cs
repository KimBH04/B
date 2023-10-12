using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Projectile : MonoBehaviour
{
    private Rigidbody rb;

    public float moveSpeed;
    public float damagedAmount;
    private bool hasDamaged;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = transform.forward * moveSpeed;
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Pakin");
        if (other.CompareTag("Enemy") && !hasDamaged)
        {
            hasDamaged = true;
            Destroy(gameObject);
        }
    }
}
