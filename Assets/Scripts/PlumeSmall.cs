using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlumeSmall : MonoBehaviour, ITouchControl
{
    [SerializeField] private float kucultmeKatsayisi;

    void Start()
    {
        transform.Rotate(0,180,0);
    }



    public void Touched(GameObject player){
        Destroy(gameObject);
        player.gameObject.transform.DOScale(new Vector3(player.gameObject.transform.localScale.x - 2f, player.gameObject.transform.localScale.y - 2f, player.gameObject.transform.localScale.z - 2f), 0.5f);
    }
}
