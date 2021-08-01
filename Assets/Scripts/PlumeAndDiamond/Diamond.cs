using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Diamond : MonoBehaviour, ITouchControl
{
    private GameManager gameManager;

    private CanvasManager canvasManager;

    void Start()
    {
        canvasManager = CanvasManager.instance;
        gameManager = GameManager.instance;
        transform.DORotate(new Vector3(0f, 180f, 0f), 1f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetId(gameObject.GetHashCode());
    }

    public void Touched()
    {

        gameManager.DiamondCount++;
        gameObject.GetComponent<SphereCollider>().enabled = false;
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        rb.AddForce(new Vector3(-15f, 40f, 20f) * 40f);
        DOTween.Kill(gameObject.GetHashCode());
        Destroy(gameObject, 0.3f);
        PlayerPrefs.SetInt("Diamonds", gameManager.DiamondCount);
    }


}
