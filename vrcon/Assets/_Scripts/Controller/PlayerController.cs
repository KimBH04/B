using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 6f;
    public GameObject PlayerPivot;
    public ProjectileController proCon;

    Camera viewCamera;
    Vector3 velocity;

    void Start()
    {
        viewCamera = Camera.main;
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            proCon.FireProjectile();
        }

        Vector3 mousePos = viewCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, viewCamera.transform.position.y));
        Vector3 targetPosition = new Vector3(mousePos.x, transform.position.y, mousePos.z);
        PlayerPivot.transform.LookAt(targetPosition, Vector3.up);
        velocity = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical")).normalized * moveSpeed;
    }

    private void FixedUpdate()
    {
        GetComponent<Rigidbody>().MovePosition(GetComponent<Rigidbody>().position + velocity * Time.fixedDeltaTime);
    }
}
