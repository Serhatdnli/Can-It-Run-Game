using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeSlow : MonoBehaviour
{
    [SerializeField] private float hizAzaltmaKatsayisi;
    
    void Start()
    {
        transform.Rotate(0,180,0);
    }

     private void OnTriggerEnter(Collider other) {
         print("Çarpıt slow");
        if(other.gameObject.CompareTag("Player")){
            other.gameObject.GetComponent<Rigidbody>().velocity += Vector3.back * hizAzaltmaKatsayisi; 
            Destroy(gameObject);
        }
    }
}
