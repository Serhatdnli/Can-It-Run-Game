using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Animator animator;
    private Rigidbody rb;
    [SerializeField] private LayerMask layerMask;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private float speed,power,radiusGroundCheck,HorizontalPower;
    private float coolDown;
    private Vector2 firstPressPos, secondPressPos,currentSwipe;
    private Vector3 lastPosition;
    void Start()
    {
        lastPosition = transform.position;
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
        firstPressPos = new Vector2(0,0);
    }
    void Update()
    {

        GroundCheck();
        
        if (Input.GetMouseButtonDown (0)) {         // Ekrana dokunulduğu anda
            firstPressPos.x = Input.mousePosition.x;        // ilk x
            firstPressPos.y = Input.mousePosition.y;            // ilk y
        }
        if(Input.GetMouseButton(0)){
            secondPressPos = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            currentSwipe = new Vector2(secondPressPos.x - firstPressPos.x, secondPressPos.y - firstPressPos.y);
        }
        if (Input.GetMouseButtonUp (0)) {           // Ekranı bırakma anı
            currentSwipe = Vector2.zero;
            secondPressPos = Vector2.zero;
        }
        if(currentSwipe.y >100 && coolDown > 100){
            animator.SetBool("isJump",true);
        }    
    }



    private void FixedUpdate() {        
        if(currentSwipe.x > 0f){
           transform.position += new Vector3((0.002f*currentSwipe.x),0,0);

        }else if(currentSwipe.x < 0f){
            transform.position += new Vector3((0.002f*currentSwipe.x),0,0);
           

        }else if(animator.GetBool("onGround") && 100 < coolDown && animator.GetBool("isJump")){
            GetComponent<Rigidbody>().velocity = new Vector3(0f,1f,0f) * power;
            coolDown = 0;
            
        }else if(currentSwipe.y < -40f){
            print("Eğildik");
        }
        print(currentSwipe.y);
        coolDown++;
    }

    public void GroundCheck(){ // zemin kontrolü

        animator.SetBool("onGround",Physics.CheckSphere(groundCheck.position,radiusGroundCheck,layerMask));
        if(Physics.CheckSphere(groundCheck.position,radiusGroundCheck,layerMask)){
            animator.SetBool("isJump",false);
        }
    }
}
