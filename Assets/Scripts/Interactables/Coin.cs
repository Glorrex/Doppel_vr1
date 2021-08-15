using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    //Create a Referance for the Game Manager
    private GameManager gameManager;
    // Creaate a standard score for coins
    [SerializeField]
    private int coinPoints = 100;
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
            //Increase Coin counter
            gameManager.addCoin();
            //Increase Score
            gameManager.addScore(coinPoints);
            //Set this Coin to inactive, visibly removes the object from the world
            gameObject.SetActive(false);

        }
    

    }
}

