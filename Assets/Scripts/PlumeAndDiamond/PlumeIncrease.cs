using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlumeIncrease : MonoBehaviour , ITouchControl
{

    private GameManager gameManager;

    private CanvasManager canvasManager;

    void Start()
    {
        canvasManager = CanvasManager.instance;
        gameManager = GameManager.instance;
        transform.Rotate(0, 180, 0);
    }

    public void Touched()
    {
        gameObject.GetComponent<Collider>().enabled = false;
        gameManager.PlumeCount++;
  
  
        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        rb.AddForce(new Vector3(-15f, 40f, 20f) * 40f);
        DOTween.Kill(gameObject.GetHashCode());
        Destroy(gameObject, 0.3f);
        PlayerPrefs.SetInt("Plumes", gameManager.DiamondCount);
    }


}
