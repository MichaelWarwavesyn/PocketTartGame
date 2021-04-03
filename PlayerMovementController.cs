using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementController : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 2;
    [SerializeField]
    private float jumpForce = 800;
    [SerializeField]
    private int maxSpeed = 10;

    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            rigidBody2D.AddForce(Vector2.up * jumpForce);
        }

        // Clamping position
        Vector3 clampedPosition = transform.position;
        clampedPosition.y = Mathf.Clamp(clampedPosition.y, -4.1f, 4.1f);
        transform.position = clampedPosition;

        // Clamping velocity
        rigidBody2D.velocity = new Vector2(0, Mathf.Clamp(rigidBody2D.velocity.y, -maxSpeed, maxSpeed));
    }
}
