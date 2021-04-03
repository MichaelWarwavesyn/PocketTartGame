using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UICollectablesText : MonoBehaviour
{
    private TextMeshProUGUI tmproText;

    private void Awake()
    {
        tmproText = GetComponent<TextMeshProUGUI>();
    }

    private void Start()
    {
        GameManager.Instance.OnCollectablesChanged += HandleONCollectablesChanged;
    }

    private void HandleONCollectablesChanged(int collectablesCollected)
    {
        tmproText.text = collectablesCollected.ToString();
    }
}
