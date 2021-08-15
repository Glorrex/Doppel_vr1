using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class WinningScreenToMainMenu : MonoBehaviour
{
    // Start is called before the first frame update
    private void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.CompareTag("LoadMainMenu"))
        {
            SceneManager.LoadScene("StartGame");
        }
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
