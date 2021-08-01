using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlumeSlow : MonoBehaviour, ITouchControl
{
    [SerializeField] private float hizAzaltma;
    [SerializeField] private Transform spriteRenderer;
    void Start()
    {
        transform.Rotate(0, 180, 0);
        spriteRenderer.DOLocalMoveY(spriteRenderer.localPosition.y + 10f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(spriteRenderer.GetHashCode());
    }
    public void Touched()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        DOTween.Kill(spriteRenderer.GetHashCode());
        Destroy(gameObject);
        PlayerController.instance.ForwardSpeed -= hizAzaltma;    
    }
}
