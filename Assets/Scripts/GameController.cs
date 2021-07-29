using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static GameController instance;
    [SerializeField] private GameObject player;
    void Start()
    {
        instance = this;
    }
    void Update()
    {
        
    }
}
