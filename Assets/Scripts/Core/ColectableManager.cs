using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using ReusableScripts;

public class ColectableManager : Singleton<ColectableManager>
{
    [SerializeField] protected int coinsCollected;

    public void CollectingCoin(int value)
    {
        coinsCollected += value;
    }
}
