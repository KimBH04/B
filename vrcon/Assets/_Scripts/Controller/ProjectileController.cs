using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour
{
    public GameObject Projectile;
    
    public void FireProjectile()
    {
        GameObject temp = Instantiate(Projectile);

        temp.transform.position = gameObject.transform.position;
        temp.GetComponent<ProjectileMove>().launchDir = transform.forward;
        Destroy(temp, 10f);
    }
}
