using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReusableScripts;
using TMPro;

public class ColectableManager : Singleton<ColectableManager>
{
    [SerializeField] public SOInt coinsCollected;
    [SerializeField] GameObject coinUI;
    [SerializeField] TextMeshProUGUI collectedCoins;


    public void CollectingCoin(int value)
    {
        coinsCollected.value += value;
        StopCoroutine(ShowCoins());
        StartCoroutine(ShowCoins());
        collectedCoins.text = coinsCollected.value.ToString();
    }

    IEnumerator ShowCoins()
    {
        coinUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        coinUI.gameObject.SetActive(false);
    }
}
