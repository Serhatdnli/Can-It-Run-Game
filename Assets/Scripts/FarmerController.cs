using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerController : MonoBehaviour
{
    private PlayerController player;

    private Animator anim;
    void Start()
    {
        player = PlayerController.instance;
        anim = gameObject.GetComponent<Animator>();
    }


    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, player.transform.position.z - 4f);

        anim.SetBool("isJump", player.Anim.GetBool("isJump"));

        anim.SetBool("isDown", player.Anim.GetBool("isDown"));
 
    }
}
