using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableAudio : MonoBehaviour
{
    private AudioSource audioSource;

    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Start()
    {
        // registering for event
        GameManager.Instance.OnCollectablesChanged += PlayCoinAudio;
    }

    private void OnDestroy()
    {
        GameManager.Instance.OnCollectablesChanged -= PlayCoinAudio;
    }

    private void PlayCoinAudio(int coins)
    {
        if(coins != 0)
            audioSource.Play();
    }
}
