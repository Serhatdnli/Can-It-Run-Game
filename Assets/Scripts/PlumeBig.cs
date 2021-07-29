using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeBig : MonoBehaviour , ITouchControl
{
    [SerializeField] private float buyutmeKatsayisi;
    void Start()
    {
        transform.Rotate(0,180,0);
        
    }

    public void Touched(GameObject player){
            Destroy(gameObject);          
            player.gameObject.transform.localScale = new Vector3( player.gameObject.transform.localScale.x * buyutmeKatsayisi, player.gameObject.transform.localScale.y * buyutmeKatsayisi, player.gameObject.transform.localScale.z * buyutmeKatsayisi);
    }


}
