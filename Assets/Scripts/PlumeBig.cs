using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeBig : MonoBehaviour
{
    [SerializeField] private float buyutmeKatsayisi;
    void Start()
    {
        transform.Rotate(0,180,0);
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("Player")){
            
            Destroy(gameObject);
            print("Big : " + other.gameObject.transform.localScale.x + "  "  + other.gameObject.transform.localScale.y + "  "  + other.gameObject.transform.localScale.z);
            other.gameObject.transform.localScale = new Vector3( other.gameObject.transform.localScale.x * buyutmeKatsayisi, other.gameObject.transform.localScale.y * buyutmeKatsayisi, other.gameObject.transform.localScale.z * buyutmeKatsayisi);
            print("Big : " + other.gameObject.transform.localScale.x + "  "  + other.gameObject.transform.localScale.y + "  "  + other.gameObject.transform.localScale.z);
            print("-----------------------------");
        }
    }


}
