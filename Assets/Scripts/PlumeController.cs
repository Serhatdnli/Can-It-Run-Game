using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlumeController : MonoBehaviour
{
    public static PlumeController instance;
    [SerializeField] GameObject big,small,fast,slow,lucky,player;
    private GameObject randPlume;
    private float playerFirstPos,plumePosX,plumePosZ;
    
    [SerializeField] private float DistanceFirstAndSecond;
    private int number,plumeIndex;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        playerFirstPos = player.transform.position.z - DistanceFirstAndSecond;      // player first pos direk tüy çıksın diye geriye ayarlandı
    }

    private void Update() {
        if(player.transform.position.z - playerFirstPos > DistanceFirstAndSecond){   // eğer karakterin z si ilk pozisyonundan belirli mesafe uzaklaşırsa
           
            number = Random.Range(3,7);         // kaç adet tüy üretileceği
            
            for(int numberCount = 0; numberCount < number; numberCount++){          // o kadar adet üret
                plumeIndex = Random.Range(0,5);     // hangi tüy indexinden üretileceği
                switch (plumeIndex)         
                {
                    case 0:         // plumeIndexe göre üret
                        randPlume = big;
                        break;
                    case 1:
                        randPlume = small;
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
                
                plumePosX = Random.Range(-3,4);
                // tüyün X aralığı
                plumePosZ = Random.Range(player.transform.position.z + 3f, player.transform.position.z + DistanceFirstAndSecond);
                // tüyün Z aralığı
                Vector3 pos = new Vector3(plumePosX,1,plumePosZ);
                createPlume(randPlume,pos);  
                playerFirstPos = player.gameObject.transform.position.z;
            }

        }
    }
    // Update is called once per frame
    private void createPlume(GameObject plume,Vector3 pos){
        Instantiate(plume, pos, Quaternion.identity);
    }
}
