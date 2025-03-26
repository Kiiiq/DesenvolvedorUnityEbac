using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharactherAnimation : MonoBehaviour
{
    [Header("Animacao")]
    public float startAnimationDur;
    public float powerUpAnimationDur;
    public float spriteScale;
    public GameObject sprite;

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(scaleCharacther());
        sprite.transform.localScale = Vector3.zero;
    }

    // Update is called once per frame
    private IEnumerator scaleCharacther()
    {
        sprite.transform.DOScale(spriteScale, startAnimationDur);
        yield return null;
    }

    public void callAnimation()
    {
        StartCoroutine(powerUpAnimation());
    }

    private IEnumerator powerUpAnimation()
    {
        sprite.transform.DOScale(spriteScale*1.2f, powerUpAnimationDur);
        yield return new WaitForSeconds(powerUpAnimationDur);
        sprite.transform.DOScale(spriteScale, powerUpAnimationDur);

    }
}
