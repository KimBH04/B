using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_002 : MonoBehaviour
{
    void Start()
    {
        int answer;
        answer = 1 + 2;
        Debug.Log(answer);

        int n1 = 8;
        int n2 = 9;
        int answer2;
        answer2 = n1 + n2;
        Debug.Log(answer2);

        answer2 += 5;
        Debug.Log(answer2);

        answer2++;
        Debug.Log(answer2);
    }

    void Update()
    {

    }
}
