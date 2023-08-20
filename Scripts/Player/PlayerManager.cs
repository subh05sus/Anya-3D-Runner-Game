using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class PlayerManager : MonoBehaviour
{
    public static bool gameOver=false;
    public GameObject gameOverPanel;
    public GameObject StartingText;
    public GameObject CharcterModel;
    public GameObject PlayerWithData;
    public float delay = 5;
    private float timer;
    public static bool isGameStarted = false;
    public Text coinsText;
    public static int noOfCoins;
    public GameObject CameraMan;



    void Start() {
        noOfCoins=0;
        gameOver = false;
        gameOverPanel.SetActive(false);
            CharcterModel.GetComponent<Animator>().enabled = false;
    }
    void Update()
    {
        if (gameOver)
        {
            // CameraMan.GetComponent<Transform>().rotation.x(80);
            CharcterModel.GetComponent<Animator>().Play("Fail");
            PlayerWithData.GetComponent<PlayerMove>().enabled=false;
            isGameStarted = false;
            timer += Time.deltaTime;
            if (timer>delay)
            {
                runGameOverScreen();
            }
        }

        if(SwipeManager.tap)
        {
            CharcterModel.GetComponent<Animator>().enabled= true;
            isGameStarted = true;
            StartingText.SetActive(false);
        }

        coinsText.text = "" + noOfCoins;

    }

    void runGameOverScreen()
    {
        Time.timeScale = 0;
        gameOverPanel.SetActive(true);
    }




}
