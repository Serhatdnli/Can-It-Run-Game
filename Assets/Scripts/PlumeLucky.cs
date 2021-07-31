using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlumeLucky : MonoBehaviour, ITouchControl
{
    [SerializeField] private float hizArtirma,hizAzaltma,buyutmeKatsayisi,kucultmeKatsayisi;


    void Start()
    {
        transform.Rotate(0,180,0);
    }

   
      public void Touched(GameObject player){
            Destroy(gameObject);
            switch ((int)Random.Range(0,4)){
                case 0:                 // hızlan   
                    PlayerController.instance.ForwardSpeed += hizArtirma;
                    break;
                case 1:                 // yavaşla
                    PlayerController.instance.ForwardSpeed -= hizAzaltma;
                    break;
                case 2:                 // büyüt
                player.gameObject.transform.DOScale(new Vector3(player.gameObject.transform.localScale.x + 2f, player.gameObject.transform.localScale.y + 2f, player.gameObject.transform.localScale.z + 2f),0.5f);
                    break;
                default:                // küçült
                player.gameObject.transform.DOScale(new Vector3(player.gameObject.transform.localScale.x - 2f, player.gameObject.transform.localScale.y - 2f, player.gameObject.transform.localScale.z - 2f), 0.5f); break;
            }   
    }
}
