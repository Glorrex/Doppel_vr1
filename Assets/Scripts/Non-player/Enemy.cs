using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Rigidbody2D body;

    [SerializeField]
    private float speed;
    private Vector2 movementDirection;
    private GameObject player;
    private GameObject enemy;
    public float distance = 9f;


    private void Awake()
    {
        body = GetComponent<Rigidbody2D>();
        movementDirection = Vector2.left;

    }
    public void Move(Vector2 direction)
    {
        movementDirection = direction;
        body.velocity = new Vector2(direction.x * speed, body.velocity.y);
    }
    // Update is called once per frame
    private void Update()

    {
        player = GameObject.FindGameObjectWithTag("Player");
        enemy = GameObject.FindGameObjectWithTag("Enemy");
        if (Vector2.Distance(gameObject.transform.position, player.transform.position) < distance)

            {
                GetComponent<Rigidbody2D>().WakeUp();
                Debug.Log("Distance is less than 5");
                Move(movementDirection);
            }
        }
    private void OnCollisionEnter2D(Collision2D collider)
    {
        if (collider.gameObject.CompareTag("Enemy")||collider.gameObject.CompareTag("Environment"))
        {
            movementDirection *= -1f;
        }
    }
}
