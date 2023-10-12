using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Tower))]
public class ProjectileTower : MonoBehaviour
{
    private Tower thisTower;

    public GameObject projectile;
    public Transform firePoint;
    public float timeBetweenShots = 1f;
    private float shotCounter;

    private Transform target;
    public Transform launcherModel;

    void Start()
    {
        thisTower = GetComponent<Tower>();
    }

    void Update()
    {
        if (target != null)
        {
            launcherModel.rotation = Quaternion.LookRotation(target.position - transform.position); // Quaternion.Slerp(launcherModel.rotation, Quaternion.LookRotation(target.position - transform.position), 5f * Time.deltaTime);

            launcherModel.rotation = Quaternion.Euler(0f, launcherModel.rotation.eulerAngles.y, 0f);
        }

        shotCounter -= Time.deltaTime;

        if (shotCounter <= 0 && target != null)
        {
            shotCounter = thisTower.fireRate;

            //firePoint.LookAt(target);

            Instantiate(projectile, firePoint.position, firePoint.rotation);
        }

        if (thisTower.enemiesUpdate)
        {
            if (thisTower.enemiesInRange.Count > 0)
            {
                float minDis = thisTower.range + 1;

                foreach (EnemyController enecon in thisTower.enemiesInRange)
                {
                    if (enecon != null)
                    {
                        float dis = Vector3.Distance(transform.position, enecon.transform.position);
                        if (dis < minDis)
                        {
                            minDis = dis;
                            target = enecon.transform;
                        }
                    }
                }
            }
        }
    }
}
