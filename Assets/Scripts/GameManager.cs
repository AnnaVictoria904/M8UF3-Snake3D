using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI currentScore;
    [SerializeField] private GameObject endingPanel;
    [SerializeField] private GameObject stickController;

    private int bestScore = 0;

    private void Awake()
    {
        endingPanel.SetActive(false);
        bestScore = PlayerPrefs.GetInt("BestScore");
        if (PlayerPrefs.GetInt("Multiplayer") == 1)
        {
            stickController.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (PlayerPrefs.GetInt("Finish") == 1)
        {
            StopGame();
        }
        else
        {
            UpdateScore();
        }
    }
    private void UpdateScore()
    {
        currentScore.text = "Score: " + PlayerPrefs.GetInt("Score");

        if (PlayerPrefs.GetInt("Score") > bestScore)
        {
            bestScore++;
            PlayerPrefs.SetInt("BestScore", bestScore);
        }
    }
    public void PrevScene()
    {
        Time.timeScale = 1;
        PlayerPrefs.SetInt("Finish", 0);
        SceneManager.LoadScene(0);
        PlayerPrefs.Save();
    }
    public void EraseBest()
    {
        PlayerPrefs.SetInt("BestScore", 0);
        bestScore = 0;
        PlayerPrefs.Save();
    }
    private void StopGame()
    {
        stickController.SetActive(false);
        endingPanel.SetActive(true);
        Time.timeScale = 0;
    }
}
