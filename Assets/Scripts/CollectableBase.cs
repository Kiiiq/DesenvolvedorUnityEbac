using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectableBase : MonoBehaviour
{
    public GameObject graphicItem;
    public ParticleSystem particleSystem;
    public AudioSource audioSource;
    public float timeToHide;
    public string Tag="Player";

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag=="Player")
        {
            Collect();
        }
    }

    protected void Collect()
    {
        if (graphicItem != null) { graphicItem.SetActive(false); }
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    public void HideObject()
    {
        this.gameObject.SetActive(false);
    }

    public void OnCollect()
    {
        if (particleSystem != null) { particleSystem.Play(); }
        if (audioSource != null) { audioSource.Play(); }
    }
}
