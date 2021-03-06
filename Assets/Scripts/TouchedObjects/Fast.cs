using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Fast : MonoBehaviour, ITouchControl
{
    [SerializeField] private float hizArtirma, asagiYukariKaymaAraligi, animasyonSuresi;

    [SerializeField] private Transform spriteRenderer;
    void Start()
    {
        spriteRenderer.DOLocalMoveY(spriteRenderer.localPosition.y + asagiYukariKaymaAraligi, animasyonSuresi).SetLoops(-1, LoopType.Yoyo).SetId(spriteRenderer.GetHashCode());
    }
    public void Touched()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        DOTween.Kill(spriteRenderer.GetHashCode());
        Destroy(gameObject);
        PlayerController.instance.ForwardSpeed += hizArtirma;
    }
}
