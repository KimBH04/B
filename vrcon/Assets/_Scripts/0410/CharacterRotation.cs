using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterRotation : MonoBehaviour
{
    float rotSpeed;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            rotSpeed = 1000;
        }

        transform.Rotate(0, rotSpeed * Time.deltaTime, 0);

        rotSpeed *= .99f;
    }
}
