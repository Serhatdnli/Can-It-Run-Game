using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeSmall : MonoBehaviour, ITouchControl
{
    [SerializeField] private float kucultmeKatsayisi;

    void Start()
    {
        transform.Rotate(0,180,0);
    }



    public void Touched(GameObject player){
        Destroy(gameObject);
        player.gameObject.transform.localScale = new Vector3( player.gameObject.transform.localScale.x / kucultmeKatsayisi, player.gameObject.transform.localScale.y / kucultmeKatsayisi, player.gameObject.transform.localScale.z / kucultmeKatsayisi);
           
    }
}
