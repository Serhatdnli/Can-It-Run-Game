using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DiamondController : MonoBehaviour
{
    [SerializeField] private GameObject diamond, player;

    [SerializeField] private float elmasAraligi, elmasUretimSikligi, elmasUretimBaslangici;

    private float lastDiamondZ = 0;

    public static DiamondController instance;

    private float diamondPosX, diamondPosZ;
    
    private void Awake()
    {
       instance = this;
    }

    void Start()
    {
        diamondPosZ = player.transform.position.z;      // player first pos direk tüy çıksın diye geriye ayarlandı
        for (int i = 0; i < 4; i++)
            createController();             // ilk başta 4 küme elmas üretilir

        InvokeRepeating("createController", elmasUretimBaslangici, elmasUretimSikligi);         // daha sonra zamanla elmas üretilmeye başlanır
    }

    private void createController(){

        diamondPosZ = lastDiamondZ + 10f;               // elmasın z konumu bi önceki elmasın konumundan 10 birim ileri
        int PosX = Random.Range(0,3);                   // elmas grubunun ortak X koordinatı için random sayı alınır
        int DiamondNumber = Random.Range(3,7);          // üretilecek elmas sayısı

        switch (PosX)                                   // Bu sayıya göre X koordinatı alınmış olur
            {
                case 0:         
                    diamondPosX = -3;
                    break;
                case 1:
                    diamondPosX = 0;
                    break;
                default:
                    diamondPosX = 3;
                    break;
            }

        for(int i=0;i < DiamondNumber; i++){            // for döngüsü ile vector oluşturulup üretime yollanır
            Vector3 pos = new Vector3(diamondPosX, 1, diamondPosZ + (i * elmasAraligi) );
            createDiamond(diamond, pos);
        }

        lastDiamondZ = diamondPosZ + (DiamondNumber * elmasAraligi);        // en son üretilen elmasın Z si tutulur

    }

            
            


    private void createDiamond(GameObject diamond, Vector3 pos)
    {
        Instantiate(diamond, pos, Quaternion.identity);
    }



  
}
