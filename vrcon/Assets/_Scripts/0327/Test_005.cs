using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_005 : MonoBehaviour
{
    void Start()
    {
        for (int i = 0; i < 5; i++)
        {
            Debug.Log(i);
        }

        for (int i = 0; i < 10; i++)
        {
            Debug.Log(i);
        }

        for (int i = 3; i > 0; i--)
        {
            Debug.Log(i);
        }

        int sum = 0;
        for (int i = 1; i < 10; i++)
        {
            sum += i;
        }
        Debug.Log(sum);
    }

    void Update()
    {
        
    }
}
