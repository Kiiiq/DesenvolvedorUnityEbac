using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinScript : CollectableScript
{
    [SerializeField] private int coinValue;
    [SerializeField] private float rotationSpeed=5;
    private GameObject CollectableManager;
    private ColectableManager colectableManager;

    
    public override void CollectableAction()
    {
        CollectableManager = GameObject.Find("CollectableManager");
        colectableManager = CollectableManager.GetComponent<ColectableManager>();

        colectableManager.CollectingCoin(coinValue);


    }

    public void Update()
    {
        this.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed*Time.deltaTime);
    }
}
