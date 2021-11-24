using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class UIManager : MonoBehaviour
{
    public Text bestScoreText;
    public Text nameText;
    public string playerName;

    public GameObject saveData;

    public void Start()
    {
        if (SaveManager.Instance.playerName != null)
        {
            bestScoreText.text = "Best Score : " + SaveManager.Instance.playerName + " : " + SaveManager.Instance.score;

        }
    }

    public void StartNew()
    {
        playerName = nameText.text.ToString();
        SaveManager.Instance.playerName = playerName;
        SceneManager.LoadScene(0);
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