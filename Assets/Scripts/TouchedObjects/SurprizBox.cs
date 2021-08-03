using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class SurprizBox : MonoBehaviour, ITouchControl
{
    [SerializeField] private float hizArtirma, kutuYukselmeAraligi, yukselmeZamani;

    [SerializeField] private SpriteRenderer front, back, left, right;

    [SerializeField] private GameObject diamond;

    private PlayerController playerController;

    private GameManager gameManager;

    private Vector3 position;

    void Start()
    {
        playerController = PlayerController.instance;
        gameManager = GameManager.instance;
        transform.DOLocalMoveY(transform.localPosition.y + kutuYukselmeAraligi, yukselmeZamani).SetLoops(-1, LoopType.Yoyo).SetId(transform.GetHashCode());
        transform.DORotate(new Vector3(0f, 180f, 0f), 1f).SetLoops(-1, LoopType.Incremental).SetEase(Ease.Linear).SetId(gameObject.GetHashCode());

        // Sürpriz kutusundaki soru işaretlerinin renk değiştirmesi
        front.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(front.GetHashCode());
        back.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(back.GetHashCode());
        left.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(left.GetHashCode());
        right.DOColor(Color.red, 0.5f).SetLoops(-1, LoopType.Yoyo).SetId(right.GetHashCode());
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
        DOTween.Kill(transform.GetHashCode());
        Destroy(gameObject, 0.3f);


        // Sürpriz kutusundaki soru işaretlerinin hareketinin yok edilmesi
        DOTween.Kill(front.GetHashCode());
        DOTween.Kill(back.GetHashCode());
        DOTween.Kill(left.GetHashCode());
        DOTween.Kill(right.GetHashCode());

        Destroy(gameObject);
        switch ((int)Random.Range(0, 2))
        {
            case 0:                 // Elmas üret  

                int elmasGelmeOranlari = Random.Range(0, 100);          // oranları dağıtmak için değişken
                position = new Vector3(transform.position.x, transform.position.y, transform.position.z);                               // toplu üretilecek elmasların konumu kutu çine ayarlandı
                int uretilecekElmasSayisi;

                if (elmasGelmeOranlari > 90)         // değişkenin yüksek olmasına göre elmas üretim oranı ayarlandı
                {
                    uretilecekElmasSayisi = 100;
                }
                else if (elmasGelmeOranlari > 75)
                {
                    uretilecekElmasSayisi = 50;
                }
                else if (elmasGelmeOranlari > 40)
                {
                    uretilecekElmasSayisi = 25;
                }
                else
                {
                    uretilecekElmasSayisi = 10;
                }


                for (int i = 0; i < uretilecekElmasSayisi; i++)
                {
                    Instantiate(diamond, position, Quaternion.identity);
                }


                break;
            case 1:                 // Hızlan
                playerController.ForwardSpeed += 2;
                break;



        }
    }
}
