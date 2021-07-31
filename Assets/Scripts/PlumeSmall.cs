using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlumeSmall : MonoBehaviour, ITouchControl
{
    [SerializeField] private float kucultmeKatsayisi;

    [SerializeField] private Transform spriteRenderer;

    private PlayerController playerController;
    void Start()
    {
        playerController = PlayerController.instance;
        transform.Rotate(0, 180, 0);
        spriteRenderer.DOLocalMoveY(spriteRenderer.localPosition.y + 10f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(spriteRenderer.GetHashCode());
    }
    public void Touched()
    {
        DOTween.Kill(spriteRenderer.GetHashCode());
        Destroy(gameObject);
        playerController.transform.DOScale(new Vector3(playerController.transform.localScale.x - 2f, playerController.transform.localScale.y - 2f, playerController.transform.localScale.z - 2f), 0.5f);
    }
}
