using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private int plumeCount, diamondCount,bestScore;

    public int PlumeCount { get => plumeCount; set => plumeCount = value; }
    public int DiamondCount { get => diamondCount; set => diamondCount = value; }
    public int BestScore { get => bestScore; set => bestScore = value; }

    // Start is called before the first frame update
    private void Awake()
    {
        instance = this;
        diamondCount = PlayerPrefs.GetInt("Diamonds");
        plumeCount = PlayerPrefs.GetInt("Plumes");
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
