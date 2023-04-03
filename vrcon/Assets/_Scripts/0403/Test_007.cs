using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Test_007 : MonoBehaviour
{
    void SayHello()
    {
        Debug.Log("Hello");
    }

    void CallName(string name)
    {
        Debug.Log($"Hello {name}");
    }

    int Add(int a, int b)
    {
        int c = a + b;
        return c;
    }

    void Start()
    {
        SayHello();
        SayHello();

        CallName("VRcon");

        Debug.Log(Add(1, 2));
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
