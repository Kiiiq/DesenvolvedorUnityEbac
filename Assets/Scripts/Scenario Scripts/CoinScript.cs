using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CoinScript : CollectableScript
{
    [SerializeField] public ParticleScript coinParticles;
    [SerializeField] private int coinValue;
    [SerializeField] private float rotationSpeed=5;
    private GameObject CollectableManager;
    private ColectableManager colectableManager;
    


    
    public override void CollectableAction()
    {
        coinParticles=GetComponent<ParticleScript>();
        CollectableManager = GameObject.Find("CollectableManager");
        colectableManager = CollectableManager.GetComponent<ColectableManager>();

        colectableManager.CollectingCoin(coinValue);

        coinParticles.PlayParticles();
    }

    public void Update()
    {
        this.transform.Rotate(new Vector3(0, 1, 0), rotationSpeed*Time.deltaTime);
    }
}
