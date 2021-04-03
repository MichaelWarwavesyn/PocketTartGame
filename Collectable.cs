using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectable : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        TakeCollectable();
    }

    private void TakeCollectable()
    {
        GameManager.Instance.AddCollectable();
        Destroy(gameObject);
    }
}
