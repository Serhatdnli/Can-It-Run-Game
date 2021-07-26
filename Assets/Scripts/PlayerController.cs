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
        
        GroundCheck();          //zemin teması kontrol
        InputControl();             // Input kontrolleri

        
         
    }

    private void OnTriggerEnter(Collider other) {
        if(other.gameObject.CompareTag("big")){
            print("big");
            transform.localScale = new Vector3(transform.localScale.x * 2f,transform.localScale.y * 2f,transform.localScale.z * 2f);
            Destroy(other.gameObject);
        } 
        if(other.gameObject.CompareTag("small")){
            print("small");
            transform.localScale = new Vector3(transform.localScale.x / 2f,transform.localScale.y / 2f,transform.localScale.z / 2f);
            Destroy(other.gameObject);
        }
        if(other.gameObject.CompareTag("lucky")){
            print("lucky");
            int rnd = Random.Range(0,2);
            if(rnd == 0){
                transform.localScale = new Vector3(transform.localScale.x / 3f,transform.localScale.y / 3f,transform.localScale.z / 3f);
            }else{
                transform.localScale = new Vector3(transform.localScale.x * 3f,transform.localScale.y * 3f,transform.localScale.z * 3f);
            }
            Destroy(other.gameObject);
        }
    }

    private void InputControl(){
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
        rb.velocity = Vector3.forward * Time.deltaTime * speed;       
        if(currentSwipe.x != 0){
            rb.velocity = new Vector3((0.02f*currentSwipe.x),rb.velocity.y,rb.velocity.z);         // sağa ya da sola git
        }
        
        if(animator.GetBool("onGround") && 100 < coolDown && animator.GetBool("isJump")){       // zıpla
            rb.velocity = new Vector3(0f,1f,0f) * power;
            coolDown = 0;
            
        }else if(currentSwipe.y < -20f){            // eğil
            animator.SetBool("isDown",true);
            Invoke("setAllAnimatorVal",1f);
        }
        coolDown++;

    }

    public void GroundCheck(){ // zemin kontrolü
        animator.SetBool("onGround",Physics.CheckSphere(groundCheck.position,radiusGroundCheck,layerMask));
        if(Physics.CheckSphere(groundCheck.position,radiusGroundCheck,layerMask)){
            animator.SetBool("isJump",false);
        }
    }

    private void setAllAnimatorVal(){
        animator.SetBool("isDown",false);
    }
}
