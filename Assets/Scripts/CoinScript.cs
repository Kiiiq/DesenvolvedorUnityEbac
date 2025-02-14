using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinScript : CollectableBase
{
    [Range(0f,60f)]public float speedRotation;
    public GameObject model;
    private bool catched=false;
    public float lerpSpeed;
    public float minDistance;
    

    // Update is called once per frame
    void Update()
    {
        model.transform.Rotate(new Vector3(0,speedRotation*Time.deltaTime,0));

        if (catched)
        {
            transform.position = Vector3.Lerp(transform.position, characterMovement.transform.position,lerpSpeed*Time.deltaTime);
        }

        if (Vector3.Distance(transform.position, characterMovement.transform.position) < minDistance)
        {
            graphicItem.SetActive(false);
            Invoke(nameof(HideObject), timeToHide);
        }
    }

    protected override void Collect()
    {
        OnCollect();
    }

    protected override void OnCollect()
    {
        base.OnCollect();
        catched = true;
    }
}
