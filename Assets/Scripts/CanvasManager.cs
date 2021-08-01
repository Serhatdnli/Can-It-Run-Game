using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using DG.Tweening;

public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    [SerializeField] private Text diamondScoreText;

    [SerializeField] private GameObject deadScene;

    private GameManager gameManager;
    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameManager.instance;
    }

    // Update is called once per frame
    void Update()
    {
        if (diamondScoreText.text != gameManager.DiamondCount.ToString())
        {
            diamondScoreText.text = gameManager.DiamondCount.ToString();
        }
    }


    public void Restart()
    {
        SceneManager.LoadScene(0);
    }
    public void Dead()
    {
        Invoke("OpenDeadPanel", 3f);
    }


    public void OpenDeadPanel()
    {
        deadScene.SetActive(true);
    }

}
