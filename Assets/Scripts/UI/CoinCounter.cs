using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CoinCounter : MonoBehaviour
{
    TextMeshProUGUI text;
    ColectableManager colectableManager;


    private void Start()
    {
        text = GetComponent<TextMeshProUGUI>();
        colectableManager = FindAnyObjectByType<ColectableManager>();
    }

    // Update is called once per frame
    void Update()
    {
        text.text = colectableManager.coinsCollected.ToString();
    }
}
