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
    [SerializeField] public CharacterMovement characterMovement;
    [SerializeField] public CharactherAnimation characterAnimation;
    [SerializeField] public GameObject sprite;


    protected virtual void Start()
    {
        characterMovement=FindObjectOfType<CharacterMovement>();
        
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.transform.tag==Tag)
        {
            Collect();
        }
    }

    protected virtual void Collect()
    {
        if (graphicItem != null) { graphicItem.SetActive(false); }
        Invoke("HideObject", timeToHide);
        OnCollect();
    }

    public void HideObject()
    {
        this.gameObject.SetActive(false);
    }

    protected virtual void OnCollect()
    {
        if (particleSystem != null) {
            particleSystem.transform.SetParent(null);
            particleSystem.Play(); 
        }
        if (audioSource != null) { audioSource.Play(); }
    }
}
