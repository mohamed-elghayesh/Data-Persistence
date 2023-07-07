using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using System;

#if UNITY_EDITOR
using UnityEditor;
#endif

[DefaultExecutionOrder(1000)]
public class MenuHandler : MonoBehaviour
{
    public TMP_InputField nameInput;
    public TextMeshProUGUI nameValidText;
    public TextMeshProUGUI bestScoreText;

    private void Start()
    {
        bestScoreText.text = $"Best Score: {PersistenceManager.Instance.bestPlayer}, {PersistenceManager.Instance.bestScore}";
    }

    public void StartGame()
    {
        
        // List<string> specialChars = new List<string> { "", " ", ",", "/", "\\"}; // not allowed as names
        // a special char was entered not a name
        if (nameInput.text == string.Empty)
        {
            nameValidText.text = "Please enter a name."; // simple validation
        }
        else
        {
            // set the persistent data and load the scene
            PersistenceManager.Instance.playerName = nameInput.text;
            SceneManager.LoadScene("Main");
        }
    }

    public void ExitGame()
    {
        #if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
        #else
            Application.Quit();
        #endif
    }
}
