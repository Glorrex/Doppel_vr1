using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PointAndClickMovement : MonoBehaviour
{
    public float speed = 10f;
    Vector2 lastClickedPos;
    bool moving;

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            lastClickedPos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            moving = true;
        }
        // This is saying that if we're moving and we're not at the same position as where we clicked, we will move to where we clicked.
        if (moving && (Vector2)transform.position != lastClickedPos)
        {
            // This is ensureing that slower computers have the player move at the same speed regaurdless of their poor preformance.
            float step = speed * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, lastClickedPos, step);
        }
        else { 
            moving = false; 
        }
    }
}
