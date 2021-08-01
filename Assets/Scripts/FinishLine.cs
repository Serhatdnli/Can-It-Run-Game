using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishLine : MonoBehaviour
{
    private Animator playerAnimator;



    private void OnTriggerEnter(Collider other) {           // bitiş çizgisine dokunulduğunda
        if(other.gameObject.CompareTag("Player")){
            playerAnimator = other.gameObject.GetComponent<Animator>();
            playerAnimator.SetBool("isFishing",true);       // valıklama efekti başla
            Invoke("setFishing",0.5f);               // yarım saniye sonra balıklama efekti değişkeni dur
            //Destroy(gameObject);
        }
    }

    
 
    private void setFishing()
    {
        playerAnimator.SetBool("isFishing",false);
    }

 
}
