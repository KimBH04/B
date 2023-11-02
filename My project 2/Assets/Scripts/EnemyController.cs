using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float moveSpeed = 1f;
    public float speedMod = 1f;
    public float timeSinceStart = 0f;

    private MonsterPath thePath;
    private int currentPoint;
    private bool reachedEnd;

    private bool modEnd = true;

    void Start()
    {
        if (thePath == null)
        {
            thePath = FindObjectOfType<MonsterPath>();
        }
    }

    void Update()
    {
        if (!modEnd)
        {
            timeSinceStart -= Time.deltaTime;

            if (timeSinceStart < 0f)
            {
                speedMod = 1f;
                modEnd = true;
            }
        }

        if (!reachedEnd)
        {
            transform.LookAt(thePath.points[currentPoint]);

            transform.position = Vector3.MoveTowards(transform.position
                , thePath.points[currentPoint].position, moveSpeed * Time.deltaTime * speedMod);

            if (Vector3.Distance(transform.position, thePath.points[currentPoint].position) < 0.01f)
            {
                currentPoint += 1;

                if (currentPoint >= thePath.points.Length)
                {
                    reachedEnd = true;
                }
            }
        }
    }

    public void SetMode(float value)
    {
        modEnd = false;
        speedMod = value;
        timeSinceStart = 2f;
    }
}