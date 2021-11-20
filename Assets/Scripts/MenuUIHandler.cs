using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;
using UnityEngine.UI;
using TMPro;

public class MenuUIHandler : MonoBehaviour
{

    public InputField playerNameField;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        SaveManager.Instance.LoadHighScorerData();
        ReadBestScore();
    }

    public void ReadBestScore()
    {
        bestScoreText.text = $"Best Score : {SaveManager.Instance.highScorerName} : {SaveManager.Instance.bestScore}";
    }

    public void ReadInputFromField()
    {
        SaveManager.Instance.playerName = playerNameField.text;
    }

    public void LoadMain()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveManager.Instance.SaveHighScorerData();
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    }
}