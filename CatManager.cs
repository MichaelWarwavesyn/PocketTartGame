using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CatManager : MonoBehaviour
{
    public static CatManager Instance { get; private set; }

    private AudioSource audioSource;

    private Rigidbody2D rigidBody2D;

    private void Awake()
    {
        rigidBody2D = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();

        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes it so it is not destroyed when loading new scene
        }
    }

    private void OnLevelWasLoaded(int level)
    {
        gameObject.transform.position = new Vector3(-3, 0, 0);
        
        if (level == 0)
        {
            SetConstraints();
        }
        else if (level == 1)
        {
            audioSource.Play();
            RemoveConstraints();
        }
    }

    private void SetConstraints()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation |
            RigidbodyConstraints2D.FreezePositionY;
    }

    public void RemoveConstraints()
    {
        rigidBody2D.constraints = RigidbodyConstraints2D.None;
        rigidBody2D.constraints = RigidbodyConstraints2D.FreezePositionX | RigidbodyConstraints2D.FreezeRotation;
    }
}
