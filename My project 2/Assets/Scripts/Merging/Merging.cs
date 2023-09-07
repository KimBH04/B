using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Merging : MonoBehaviour
{
    [SerializeField]
    private Transform camTr;

    void Start()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition, Camera.MonoOrStereoscopicEye.Mono);
        Vector3 v = ray.direction;
    }

    void Update()
    {
        
    }
}
