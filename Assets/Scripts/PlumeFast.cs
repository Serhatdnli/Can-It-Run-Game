using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeFast : MonoBehaviour
{
    [SerializeField] private float hizArtirmaKatsayisi;
    
    void Start()
    {
        transform.Rotate(0,180,0);
    }

     private void OnTriggerEnter(Collider other) {
        
        if(other.gameObject.CompareTag("Player")){
            print("Fast");
            Destroy(gameObject);
            
            other.gameObject.GetComponent<Rigidbody>().velocity += Vector3.forward * Time.deltaTime*hizArtirmaKatsayisi; 
            print( other.gameObject.GetComponent<Rigidbody>().velocity);
            print("------------");
        }
    }
}
