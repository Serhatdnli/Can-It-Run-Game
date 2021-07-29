﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeFast : MonoBehaviour, ITouchControl
{
    [SerializeField] private float hizArtirma;

    void Start()
    {
        transform.Rotate(0,180,0);
    }

    public void Touched(GameObject player){
        Destroy(gameObject);
        PlayerController.instance.ForwardSpeed += hizArtirma;   
    }
}
