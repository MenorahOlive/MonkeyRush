using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    [SerializeField] private int score;
    [SerializeField] private float detectionThreshold = 10f;
    private bool isDetected = false;
    private bool pauseTime = false;
    private float timeDetected = 0; // Time detected in seconds
    private int gameScore = 0;
    [SerializeField] private TMP_Text scoreText;
    [SerializeField] private TMP_Text timeText;
    [SerializeField] private GameObject detectedUI;
    [SerializeField] private float restartDelay = 2f;
    private void Start()
    {
        InvokeRepeating("UpdateScore", 5f, 2f);
    }

    private void Update()
    {
        if (isDetected && !pauseTime)
        {
            timeDetected += Time.deltaTime;
           
            if ((int) timeDetected == (int)detectionThreshold)
            {
                FinishGame();
            }
            else
            {
                int timeRemaining = (int)(detectionThreshold - timeDetected);

                if (timeRemaining > 0)
                {

                    timeText.SetText(timeRemaining.ToString());
                }
            }


        }


    }
    public void TogglePauseTime()
    {
        pauseTime = !pauseTime;
    }

    private void UpdateScore()
    {
        if (!isDetected)
        {
            gameScore++;
            scoreText.SetText(gameScore.ToString());
        }
    }
    public void setDetected(bool value)
    {

        isDetected = value;

        if (value)
        {
            ShowDetectedBanner();
        }
        else
        {
            timeDetected = 0f;
            HideDetectedBanner();
        }
    }
    public void ShowDetectedBanner()
    {
        detectedUI.SetActive(true);
    }
    public void HideDetectedBanner()
    {
        detectedUI.SetActive(false);
    }

    private void FinishGame()
    {
        Debug.LogWarning("Finishing The game");
        Invoke("GameOverPage", restartDelay);
    }

    void GameOverPage()
    {
        SceneManager.LoadSceneAsync(2);
    }


}
