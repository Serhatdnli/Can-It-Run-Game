using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeController : MonoBehaviour
{
    public static PlumeController instance;

    [SerializeField] GameObject increase, subtract, fast, slow, lucky, player;

    [SerializeField] private float DistanceFirstAndSecond;

    private GameObject randPlume;

    private float playerFirstPos, plumePosX, plumePosZ, lastPlums;

    private int number, plumeIndex;

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        plumePosZ = transform.position.z;      // player first pos direk tüy çıksın diye geriye ayarlandı
    }

    private void Update()
    {
        if (player.transform.position.z + 100f >= plumePosZ)
        {   // eğer karakterin z si ilk pozisyonundan belirli mesafe uzaklaşırsa

            number = Random.Range(3, 7);         // kaç adet tüy üretileceği

            for (int numberCount = 0; numberCount < number; numberCount++)
            {          // o kadar adet üret
                plumeIndex = Random.Range(0, 5);     // hangi tüy indexinden üretileceği
                switch (plumeIndex)
                {
                    case 0:         // plumeIndexe göre üret
                        randPlume = increase;
                        break;
                    case 1:
                        randPlume = subtract;
                        break;
                    case 2:
                        randPlume = fast;
                        break;
                    case 3:
                        randPlume = slow;
                        break;
                    default:
                        randPlume = lucky;
                        break;
                }

                plumePosX = Random.Range(-5f, 5f);
                plumePosZ += 10f;
                Vector3 pos = new Vector3(plumePosX, 1, plumePosZ);
                createPlume(randPlume, pos);
            }

        }
    }


    private void createPlume(GameObject plume, Vector3 pos)
    {
        Instantiate(plume, pos, Quaternion.identity);
    }
}
