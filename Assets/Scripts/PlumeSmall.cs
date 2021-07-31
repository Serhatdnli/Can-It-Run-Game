using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlumeSmall : MonoBehaviour, ITouchControl
{
    [SerializeField] private float kucultmeKatsayisi;
    [SerializeField] private Transform spriteRenderer;
    void Start()
    {
        transform.Rotate(0, 180, 0);
        spriteRenderer.DOLocalMoveY(spriteRenderer.localPosition.y + 10f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(spriteRenderer.GetHashCode());
    }
    public void Touched(GameObject player)
    {
        DOTween.Kill(spriteRenderer.GetHashCode());
        Destroy(gameObject);
        player.gameObject.transform.DOScale(new Vector3(player.gameObject.transform.localScale.x - 2f, player.gameObject.transform.localScale.y - 2f, player.gameObject.transform.localScale.z - 2f), 0.5f);
    }
}
