using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MainSceneUI : MonoBehaviour
{
    public Text bestScoreText;

    private void Start()
    {
        ShowBestScorer();
    }
    public void ShowBestScorer()
    {
        bestScoreText.text = $"Best Score : {SaveManager.Instance.highScorerName} : {SaveManager.Instance.bestScore} ";
    }

    public void BackToMenu()
    {
        SaveManager.Instance.SaveHighScorerData();
        SceneManager.LoadScene(0);
    }
}