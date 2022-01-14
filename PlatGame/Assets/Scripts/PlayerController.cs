using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private Rigidbody2D myrigidBody;
    private bool isFacingRight = true;
    private float movementInputDirection;
    public float moveSpeed = 10.0f;
    private float jumpForce = 16.0f;
    void Start()
    {
        myrigidBody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        CheckInput();
        CheckMovementDirection();
    }

    private void FixedUpdate() {

        ApplyMovement();
    }

    private void CheckInput(){

        movementInputDirection = Input.GetAxisRaw("Horizontal");

        if(Input.GetButtonDown("Jump")){
            Jump();
        }
        
    }

    private void ApplyMovement(){
        myrigidBody.velocity = new Vector2(moveSpeed * movementInputDirection,myrigidBody.velocity.y);
    }

    private void CheckMovementDirection(){
        if(isFacingRight && movementInputDirection < 0){
            Flip();
        }
        else if(!isFacingRight && movementInputDirection > 0){
            Flip();
        }
    }

    private void Jump(){
        myrigidBody.velocity = new Vector2(myrigidBody.velocity.x, jumpForce);

    }

    private void Flip(){
        isFacingRight = !isFacingRight;
        transform.Rotate(0.0f, 180.0f , 0.0f);
    }

}
