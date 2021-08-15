using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class QuitGame : MonoBehaviour
{
    public Button quitButton;
    void Start()
    {
        quitButton.onClick.AddListener(quitGame);
    }
    public void quitGame()
    {
        Application.Quit();
    }

}

