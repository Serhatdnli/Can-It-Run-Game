using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeSmall : MonoBehaviour
{
    [SerializeField] private float kucultmeKatsayisi;
    void Start()
    {
        transform.Rotate(0,180,0);
    }

     private void OnTriggerEnter(Collider other) {
         
         if(other.gameObject.CompareTag("Player")){
            print("Big : " + other.gameObject.transform.localScale.x + "  "  + other.gameObject.transform.localScale.y + "  "  + other.gameObject.transform.localScale.z);
            Destroy(gameObject);
            other.gameObject.transform.localScale = new Vector3( other.gameObject.transform.localScale.x / kucultmeKatsayisi, other.gameObject.transform.localScale.y / kucultmeKatsayisi, other.gameObject.transform.localScale.z / kucultmeKatsayisi);
            print("Big : " + other.gameObject.transform.localScale.x + "  "  + other.gameObject.transform.localScale.y + "  "  + other.gameObject.transform.localScale.z);
            print("-------------------------");
        }
    }
}
