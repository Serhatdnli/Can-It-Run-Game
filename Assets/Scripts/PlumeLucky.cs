using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
                    player.gameObject.transform.localScale = new Vector3(player.gameObject.transform.localScale.x * buyutmeKatsayisi,player.gameObject.transform.localScale.y * buyutmeKatsayisi,player.gameObject.transform.localScale.z * buyutmeKatsayisi);
                    break;
                default:                // küçült
                    player.gameObject.transform.localScale = new Vector3(player.gameObject.transform.localScale.x / kucultmeKatsayisi,player.gameObject.transform.localScale.y / kucultmeKatsayisi,player.gameObject.transform.localScale.z / kucultmeKatsayisi);
                    break;
            }   
    }
}
