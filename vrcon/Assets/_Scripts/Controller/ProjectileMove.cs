using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ProjectileMove : MonoBehaviour
{
    public enum PROJECTILETYPE
    {
        PLAYER,
        ENEMY
    }

    public Vector3 launchDir;
    public PROJECTILETYPE projectileType = PROJECTILETYPE.PLAYER;

    public int a;

    private void FixedUpdate()
    {
        float moveAmount = 3 * Time.deltaTime;
        transform.Translate(launchDir * moveAmount);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.name.Equals("Wall"))
        {
            Destroy(gameObject);
        }

        if (collision.gameObject.name.Equals("Monster"))
        {
            collision.gameObject.GetComponent<MonsterController>().Damanged(1);
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Wall"))
        {
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Monster") && projectileType == PROJECTILETYPE.PLAYER)
        {
            other.gameObject.GetComponent<MonsterController>().Damanged(1);
            other.transform.DOPunchScale(new Vector3(.2f, .2f, .2f), .2f);
            Destroy(gameObject);
        }

        if (other.gameObject.CompareTag("Player") && projectileType == PROJECTILETYPE.ENEMY)
        {
            other.gameObject.GetComponent<PlayerController>().Damanged(1);
            other.transform.DOPunchScale(new Vector3(.2f, .2f, .2f), .2f);
            Destroy(gameObject);
        }
    }
}
