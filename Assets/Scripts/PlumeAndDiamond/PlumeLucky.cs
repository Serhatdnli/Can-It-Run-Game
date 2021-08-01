using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlumeLucky : MonoBehaviour, ITouchControl
{
    [SerializeField] private float hizArtirma, hizAzaltma;

    [SerializeField] private int tuyArtirma, tuyAzaltma;

    [SerializeField] private Transform spriteRenderer;

    private PlayerController playerController;

    private GameManager gameManager;

    void Start()
    {
        playerController = PlayerController.instance;
        gameManager = GameManager.instance;
        transform.Rotate(0, 180, 0);
        spriteRenderer.DOLocalMoveY(spriteRenderer.localPosition.y + 10f, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(spriteRenderer.GetHashCode());
        spriteRenderer.gameObject.GetComponent<SpriteRenderer>().DOColor(Color.red, 0.5f).SetLoops(-1,LoopType.Yoyo).SetId(spriteRenderer.GetHashCode());
    }
    public void Touched()
    {
        gameObject.GetComponent<Collider>().enabled = false;

        Rigidbody rb = gameObject.AddComponent<Rigidbody>();
        if (rb == null)
        {
            rb = gameObject.GetComponent<Rigidbody>();
        }
        rb.AddForce(new Vector3(-15f, 40f, 20f) * 40f);
        DOTween.Kill(gameObject.GetHashCode());
        Destroy(gameObject, 0.3f);



        DOTween.Kill(spriteRenderer.GetHashCode());
        Destroy(gameObject);
            switch ((int)Random.Range(0,4)){
                case 0:                 // hızlan   
                    gameManager.PlumeCount +=  tuyArtirma;
                    PlayerPrefs.SetInt("Plumes", gameManager.DiamondCount);
                break;
                case 1:                 // yavaşla
                    gameManager.PlumeCount -= tuyAzaltma;
                    PlayerPrefs.SetInt("Plumes", gameManager.DiamondCount);
                break;
                case 2:                 // büyüt
                playerController.transform.DOScale(new Vector3(playerController.transform.localScale.x + 2f, playerController.transform.localScale.y + 2f, playerController.transform.localScale.z + 2f),0.5f);
                    break;
                default:                // küçült
                playerController.transform.DOScale(new Vector3(playerController.transform.localScale.x - 2f, playerController.transform.localScale.y - 2f, playerController.transform.localScale.z - 2f), 0.5f); break;
            }   
    }
}
