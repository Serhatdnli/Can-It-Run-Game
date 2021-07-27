using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeLucky : MonoBehaviour
{
    [SerializeField] private float hizArtirmaKatsayisi,hizAzaltmaKatsayisi,buyutmeKatsayisi,kucultmeKatsayisi;
    
    void Start()
    {
        transform.Rotate(0,180,0);
    }

     private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
                print("Lucky");
                Destroy(gameObject);
                switch ((int)Random.Range(0,4)){
                    case 0:                 // hızlan   
                        other.gameObject.GetComponent<Rigidbody>().velocity += Vector3.forward * hizArtirmaKatsayisi; 
                        break;
                    case 1:                 // yavaşla
                        other.gameObject.GetComponent<Rigidbody>().velocity += Vector3.back * hizAzaltmaKatsayisi; 
                        break;
                    case 2:                 // büyüt
                        other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x * buyutmeKatsayisi,other.gameObject.transform.localScale.y * buyutmeKatsayisi,other.gameObject.transform.localScale.z * buyutmeKatsayisi);
                        break;
                    default:                // küçült
                        other.gameObject.transform.localScale = new Vector3(other.gameObject.transform.localScale.x / kucultmeKatsayisi,other.gameObject.transform.localScale.y / kucultmeKatsayisi,other.gameObject.transform.localScale.z / kucultmeKatsayisi);
                        break;
                }   
        } 
    }
}
