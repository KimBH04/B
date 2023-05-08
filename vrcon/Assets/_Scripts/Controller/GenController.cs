using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenController : MonoBehaviour
{
    public GameObject MonsterTemp;

    void Update()
    {
        if (Input.GetMouseButtonDown(1))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            if (Physics.Raycast(ray, out RaycastHit hit))
            {
                if (hit.collider.CompareTag("Ground"))
                {
                    GameObject temp = Instantiate(MonsterTemp);
                    temp.transform.position = hit.point + new Vector3(0f, 1f, 0f);
                }

                Debug.DrawLine(ray.origin, hit.point, Color.red, 2f);
                Debug.Log("Hit =>" + hit.collider.name);
            }
        }
    }
}
