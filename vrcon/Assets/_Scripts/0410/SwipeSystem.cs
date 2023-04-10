using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwipeSystem : MonoBehaviour
{
    public GameObject Character;
    private Vector2 initialPos;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            initialPos = Input.mousePosition;
        }

        if (Input.GetMouseButtonUp(0))
        {
            Calculate(Input.mousePosition);
        }
    }

    void Calculate(Vector3 finalPos)
    {
        float disX = Mathf.Abs(initialPos.x - finalPos.x);
        float disY = Mathf.Abs(initialPos.y - finalPos.y);

        if (disX > 0 || disY > 0)
        {
            if (disX > disY)
            {
                if (initialPos.x > finalPos.x)
                {
                    Debug.Log("Left");
                    Character.transform.position += new Vector3(-1f, .0f, .0f);
                }
                else
                {
                    Debug.Log("Right");
                    Character.transform.position += new Vector3(1f, .0f, .0f);
                }
            }
            else
            {
                if (initialPos.y > finalPos.y)
                {
                    Debug.Log("Down");
                    Character.transform.position += new Vector3(0f, .0f, -1f);
                }
                else
                {
                    Debug.Log("Up");
                    Character.transform.position += new Vector3(0f, .0f, 1f);
                }
            }
        }
    }
}
