using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance { get; private set; }
    
    public event Action<int> OnCollectablesChanged;

    private AudioSource audioSource;

    private int collectableCollected;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Makes it so it is not destroyed when loading new scene

            audioSource = GetComponent<AudioSource>();

            RestartGame();
        }
    }

    internal void KillPlayer()
    {
        audioSource.Play();
        RestartGame();
    }

    internal void AddCollectable()
    {
        collectableCollected++;

        if (OnCollectablesChanged != null)
            OnCollectablesChanged(collectableCollected);
    }

    private void RestartGame()
    {
        collectableCollected = 0;

        if (OnCollectablesChanged != null)
            OnCollectablesChanged(collectableCollected);

        SceneManager.LoadScene(0);
    }
}
