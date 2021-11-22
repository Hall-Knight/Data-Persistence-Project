using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    public Text bestScoreText;
    public TMP_InputField playerName;

    public void Start()
    {
        bestScoreText.text = "Best Score : " + SaveManager.Instance.playerName + " : " + SaveManager.Instance.score;
    }

    public void EnteredName(string name)
    {
        Debug.Log(playerName.text);
        SaveManager.Instance.newPlayerName = playerName.text;
    }

    public void StartNew()
    {
        SceneManager.LoadScene(0);
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene(1);
    }

    public void Exit()
    {
        SaveManager.Instance.SaveStats();

#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}