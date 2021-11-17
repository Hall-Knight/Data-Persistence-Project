using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
#if UNITY_EDITOR
using UnityEditor;
#endif

public class MenuUIHandler : MonoBehaviour
{
    InputField iField;

    string playerName;

    private void Start()
    {
        iField = GameObject.Find("Name Field").GetComponent<InputField>();
    }

    public void PlayBtnClicked()
    {

        playerName = iField.text;
        DataPersist.Instance.playerName = playerName;
        SceneManager.LoadScene(1);

    }

    public void Exit()
    {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit(); // original code to quit Unity player
#endif
    }
}