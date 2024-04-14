using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : CollectableScript
{
    [SerializeField] private int coinValue;
    private GameObject CollectableManager;
    private ColectableManager colectableManager;

    
    public override void CollectableAction()
    {
        CollectableManager = GameObject.Find("CollectableManager");
        colectableManager = CollectableManager.GetComponent<ColectableManager>();

        colectableManager.CollectingCoin(coinValue);


    }
}
