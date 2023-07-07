using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class MainHandler : MonoBehaviour
{
    public TextMeshProUGUI menuBestScoreText;

    public void QuitGame()
    {
        SceneManager.LoadScene("Menu");
    }
}
