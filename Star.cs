using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Star : MonoBehaviour
{
    [SerializeField]
    private float destroyAfterSecounds = 10;

    private void Awake()
    {
        Destroy(this.gameObject, destroyAfterSecounds);
    }
}
