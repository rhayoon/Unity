using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class MovementController : MonoBehaviour
{
    public float movement_speed = 3.0f;
    Vector2 movement = new Vector2();
    
    Rigidbody2D rb2D;
    Animator animator;
    string animationState = "AnimationState";

    enum CharStates
    { 
        walk_east = 1,
        walk_south =2,
        walk_west = 3,
        walk_north= 4,
        idle_south= 5
    
    }
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();

    }

    // Update is called once per frame
    void Update()
    {
        UpdateState();
    }
    void FixedUpdate()
    {
        MoveCharacter();
        
    }

    private void MoveCharacter()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
      
        movement.Normalize();

        rb2D.velocity = movement * movement_speed;
    }
    private void UpdateState()
    {
        if (movement.x > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walk_east);
        }
        else if (movement.x < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walk_west);
        }
        else if (movement.y > 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walk_north);
        }
        else if (movement.y < 0)
        {
            animator.SetInteger(animationState, (int)CharStates.walk_south);
        }
        else
        {
            animator.SetInteger(animationState, (int)CharStates.idle_south);
        }

    }
}
