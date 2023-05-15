using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyConstroller : MonoBehaviour
{
    public float Speed = 5f;

    public float rotationSpeed = 1f;
    public GameObject bulletPrefab;
    public GameObject enemyPivot;
    public Transform firePoint;
    public float fireRate = 1f;
    public float nextFireTime;

    private Rigidbody rb;
    private Transform player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        GameObject temp = GameObject.FindGameObjectWithTag("Player");
        player = temp == null ? null : temp.transform;
    }

    void Update()
    {
        if (player != null)
        {
            if (Vector3.Distance(player.position, transform.position) > 5f)
            {
                Vector3 direction = (player.position - transform.position).normalized;
                rb.MovePosition(transform.position + Speed * Time.deltaTime * direction);
            }

            Vector3 targetDirection = (player.position - enemyPivot.transform.position).normalized;
            Quaternion targetRotate = Quaternion.LookRotation(targetDirection);
            enemyPivot.transform.rotation = Quaternion.Lerp(enemyPivot.transform.rotation, targetRotate, rotationSpeed * Time.deltaTime);

            if (Time.time > nextFireTime)
            {
                nextFireTime = Time.time + 1f / fireRate;
                GameObject temp = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
                temp.GetComponent<ProjectileMove>().launchDir = firePoint.localRotation * Vector3.forward;
                temp.GetComponent<ProjectileMove>().projectileType = ProjectileMove.PROJECTILETYPE.ENEMY;
            }
        }
    }
}
