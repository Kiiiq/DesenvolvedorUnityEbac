using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReusableScripts;

public class ColectableManager : Singleton<ColectableManager>
{
    [SerializeField] public int coinsCollected;
    [SerializeField] GameObject CoinUI;


    public void CollectingCoin(int value)
    {
        coinsCollected += value;
        StartCoroutine(ShowCoins());
    }

    IEnumerator ShowCoins()
    {
        CoinUI.gameObject.SetActive(true);
        yield return new WaitForSeconds(5f);
        CoinUI.gameObject.SetActive(false);
    }
}
