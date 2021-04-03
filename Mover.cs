using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private float movementSpeed = 5;

    void Update()
    {
        Vector3 movement = new Vector3(-1, 0);

        transform.position += movement * movementSpeed * Time.deltaTime;
    }
}
