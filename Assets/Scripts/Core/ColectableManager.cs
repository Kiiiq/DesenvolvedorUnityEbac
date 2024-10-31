using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReusableScripts;
using TMPro;

public class ColectableManager : Singleton<ColectableManager>
{
    [SerializeField] public int coinsCollected;
    [SerializeField] GameObject coinUI;
    [SerializeField] TextMeshProUGUI collectedCoins;


    public void CollectingCoin(int value)
    {
        coinsCollected += value;
        StopCoroutine(ShowCoins());
        StartCoroutine(ShowCoins());
        collectedCoins.text = coinsCollected.ToString();
    }

    IEnumerator ShowCoins()
    {
        coinUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        coinUI.gameObject.SetActive(false);
    }
}
