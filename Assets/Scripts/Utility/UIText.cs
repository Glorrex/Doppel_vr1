using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class UIText : MonoBehaviour
{
    public Text LivesText;
    public Text scoreText;
    public Text coinsText;
    private GameObject gameManager;
    private int Lives;
    private int coins;
    private int score;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = this.gameObject;
        Lives = gameManager.GetComponent<GameManager>().getLives();
        score = gameManager.GetComponent<GameManager>().getScore();
        coins = gameManager.GetComponent<GameManager>().getCoins();
    }

    // Update is called once per frame
    void Update()
    {
        Lives = gameManager.GetComponent<GameManager>().getLives();
        LivesText.text = "Frogs x " + Lives;
        score = gameManager.GetComponent<GameManager>().getScore();
        scoreText.text = "" + score;
        coins = gameManager.GetComponent<GameManager>().getCoins();
        coinsText.text = "Coins x" + coins;
    }
}
