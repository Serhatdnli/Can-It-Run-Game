using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{

    public static PlayerController instance;

    [SerializeField] private Camera ortho;

    [SerializeField] private LayerMask layerMask;

    [SerializeField] private Transform groundCheck;

    [SerializeField] private float forwardSpeed, sensivity, radiusGroundCheck, HorizontalPower;

    private Animator animator;

    private Rigidbody body;

    private Vector3 diff;

    private Vector3 firstPos;

    private Vector3 mousePos;

    private float coolDown;

    public float ForwardSpeed   // property
    {
        get { return forwardSpeed; }
        set { forwardSpeed = value; }
    }

    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        animator = GetComponent<Animator>();
        body = GetComponent<Rigidbody>();
    }
    void Update()
    {
        GroundCheck();          //zemin teması kontrol
        InputControl();             // Input kontrolleri    
    }


    private void InputControl()
    {
        firstPos = Vector3.Lerp(firstPos, mousePos, .1f);

        if (Input.GetMouseButtonDown(0))
            MouseDown(Input.mousePosition);

        else if (Input.GetMouseButtonUp(0))
            MouseUp();

        else if (Input.GetMouseButton(0))
            MouseHold(Input.mousePosition);
    }

    private void MouseDown(Vector3 inputPos)
    {
        mousePos = ortho.ScreenToWorldPoint(inputPos);
        firstPos = mousePos;
    }

    private void MouseHold(Vector3 inputPos)
    {
        mousePos = ortho.ScreenToWorldPoint(inputPos);
        diff = mousePos - firstPos;
        diff *= sensivity;
    }

    private void MouseUp()
    {
        diff = Vector3.zero;
    }


    private void FixedUpdate()
    {

        body.velocity = Vector3.Lerp(body.velocity, new Vector3(diff.x, body.velocity.y, ForwardSpeed), .1f);
        transform.DOLocalRotate(new Vector3(0f, diff.x * 5f, 0f), 0.5f);
        if (animator.GetBool("onGround") && 50 < coolDown && diff.y > 3f && Math.Abs(diff.x) < Math.Abs(diff.y))
        {
            animator.SetBool("isJump", true);
            body.velocity = new Vector3(0f, 1f, 0f) * 6f;
            coolDown = 0;

        }
        else if (diff.y < -3f && Math.Abs(diff.x) < Math.Abs(diff.y))
        {            // eğil
            print("eğildik");
            animator.SetBool("isDown", true);
            Invoke("setAllAnimatorVal", 1f);
        }
        coolDown++;

    }

    public void GroundCheck()
    { // zemin kontrolü
        animator.SetBool("onGround", Physics.CheckSphere(groundCheck.position, radiusGroundCheck, layerMask));
        if (Physics.CheckSphere(groundCheck.position, radiusGroundCheck, layerMask))
        {
            animator.SetBool("isJump", false);
        }
    }

    private void setAllAnimatorVal()
    {
        animator.SetBool("isDown", false);
    }

    private void OnTriggerEnter(Collider other)
    {
        other.gameObject.GetComponent<ITouchControl>()?.Touched(gameObject);
    }
}
