using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using DG.Tweening;

public class AnimateImage : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public GameObject button;
    public float animationDuration=0.5f, scaleMultiplicator=1.2f;
    private Vector3 defautScale;
    Tween actualTween;


    public void Awake()
    {
        defautScale = transform.localScale;
    }
    public void OnPointerEnter(PointerEventData pointer)
    {
        actualTween=button.transform.DOScale(defautScale * scaleMultiplicator, animationDuration);
    }


    public void OnPointerExit(PointerEventData pointer)
    {
        actualTween.Kill();
        button.transform.DOScale(defautScale, animationDuration);
    }
}
