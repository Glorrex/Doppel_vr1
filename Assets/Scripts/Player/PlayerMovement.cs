using System.Collections;
using System.Collections.Generic;
using Unity.Jobs.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private GameObject playerRespawnPoint;
    [SerializeField]
    private GameManager gameManager;
    [SerializeField]
    private LayerMask enemyLayerMask;
    public float moveSpeed;
    public float walkingSpeed = 1f;
    public float jumpForce;
    public float runMultiplier = 2f;
    public AudioClip jumpSound;
    Vector2 movement;
    private BoxCollider2D boxCollider;
    private Animator animator;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rb;
    private float moveDirection;
    private bool isJumping = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = walkingSpeed;

    }


    // Update is called once per frame
    void Update()
    {
        ProcessInputs();
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        Move();
    }
    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }

    // Physics Movements
    private void Move()
    {
        float speed = Input.GetAxis("Horizontal") * moveSpeed;

    }


    // Process Keyboard Inputs
    void ProcessInputs()
    {
        //Moves the player left and right
        float speed = Input.GetAxis("Horizontal") * moveSpeed;
        //Moves the player up and down
        moveDirection = Input.GetAxis("Vertical");

        // Use Fire1 Button to Run
        if (Input.GetButtonDown("Fire1"))
        {
            moveSpeed *= runMultiplier;
        }
        // Release Fire1 to stop running
        if (Input.GetButtonUp("Fire1"))
        {
            moveSpeed = walkingSpeed;
        }
    }

    private void OnTriggerEnter2D(Collider2D collider)
    {
        //Check tto see if player is touching an Enemy
        if (collider.CompareTag("Enemy"))
            Die();
        {
            //Debug.Log("The player is touching" + collider.tag + "tag!");
        }
        if (collider.CompareTag("Enemyone"))
        {
            Die();
        }
        if (collider.CompareTag("DeathZone"))
        {
            Debug.Log("The Player Hit The DeathZone");
            Die();
        }
        {
            //Checks to see if the player made it to the end of the level
            //if (collider.CompareTag("WinCondition"))
            SceneManager.LoadScene("GameWinCondition");
        }
        //if (gameObject.transform.position.x>=160)
        {
            //SceneManager.LoadScene("GameWinCondition");
        }
        void Die()
        {
            this.transform.position = playerRespawnPoint.transform.position;
            gameManager.removeLife();
            PlayerPrefs.DeleteAll();
        }
    }
    //void yPositionPitFallDeath()
    // {
    // if(gameObject.transform.position.y < -25)
    //{
    //   this.transform.position = playerRespawnPoint.transform.position;
    // gameManager.removeLife();
}
//}
//}
