using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileMove : MonoBehaviour
{
    public Vector3 launchDir;

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
}
