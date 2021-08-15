using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinBlock : MonoBehaviour
{
    //Create a Referance for the Game Manager
    private GameManager gameManager;
    // Creaate a standard score for coins
    [SerializeField]
    private int coinPoints = 25;
    // Create counter for numbers of time hit
    [SerializeField]
    private int hitcounter = 0;
    [SerializeField]
    private int hitlimit = 5;
    public AudioClip coinsound;
    // Do some action(s) when the item when the item this script is on is awakened in the scene
    private void Awake()    
    {
        gameManager = FindObjectOfType<GameManager>();
    }
    // do some action when the trigger on this item is entered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("This coin was touched by " + GetComponent < Collider2D>().tag);


        //check for player tag
        if (collision.CompareTag("Player"))
        {
            //if (gameManager.coinboxcounter < 1)
            if (hitcounter<hitlimit)
            {
                AudioSource.PlayClipAtPoint(coinsound, transform.position);
                //Incerased Coin Box counter
                //gameManager.coinboxcounter++;
                hitcounter++;
                //Increase Coin counter
                //Increase Score
                gameManager.addScore(coinPoints);
                gameManager.addCoin();
                //Set this Coin to inactive, visibly removes the object from the world
                gameObject.SetActive(false);
            }
        }


    }
}
