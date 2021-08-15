using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OneUp : MonoBehaviour
{
    //Create a Referance for the Game Manager
    private GameManager gameManager;
    // Creaate a standard score for coins
    [SerializeField]
    private int scorePoints = 100;
    [SerializeField]
    private int oneuphitcounter = 0;
    [SerializeField]
    private int oneuphitlimit = 5;
    public SpriteRenderer spriteRenderer;
    public AudioClip oneupSound;
    // Do some action(s) when the item when the item this script is on is awakened in the scene
    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
        this.spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // do some action when the trigger on this item is entered
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("This coin was touched by " + GetComponent < Collider2D>().tag);


        //check for player tag
        if (collision.CompareTag("Player"))
        {
            //if (gameManager.coinboxcounter < 1)
            if (oneuphitcounter < oneuphitlimit)
            {
                AudioSource.PlayClipAtPoint(oneupSound, transform.position);
                //Incerased Coin Box counter
                //gameManager.coinboxcounter++;
                oneuphitcounter++;
                //Increase Coin counter
                gameManager.addLife();
                //Increase Score
                gameManager.addScore(scorePoints);
                this.spriteRenderer.enabled = true; // enable the renderer
            }
        }


    }
}
