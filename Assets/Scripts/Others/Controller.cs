using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controller : MonoBehaviour {

    const float MOVE_SPEED = 0.2f;
    const float JUMP_SPEED = 0.001f;
    const float MAX_HEIGHT = 8;
    const float SHELLRADIUS = 0.1f;
    const float GRAVITY_SPEED = -0.1f;

    Rigidbody2D playerBody;

    Vector2 velocity = Vector2.zero;
    float currentHeight = 0;
    bool isJumped = false;
    protected RaycastHit2D[] hitBuffer = new RaycastHit2D[16];

    // Start is called at the start of the Game
    void Start() {
        playerBody = GetComponent<Rigidbody2D>();
    }

    // FixedUpdate is called every 0.02 Seconds
    void FixedUpdate() {

        if (Input.GetButtonDown("Jump")) {
            isJumped = true;
        }
        
        HorizontalMovement();
        VerticalMovement();
    }

    bool CheckForCollision(Vector2 moveInput) {
        int count = playerBody.Cast(moveInput, hitBuffer, moveInput.magnitude);
        
        for (int i = 0; i < count; i++)
        {
            if (hitBuffer[i].transform.gameObject.layer == 0)
            {
                return false;
            }
        }

        return true;
    }

    void HorizontalMovement() {
        Vector2 moveInput = Vector2.zero;

        if (Input.GetKey("d")) {
            moveInput.x = 1 * MOVE_SPEED;
        }

        if (Input.GetKey("a"))
        {
            moveInput.x = -1 * MOVE_SPEED;
        }
        
        if (CheckForCollision(moveInput) && moveInput != Vector2.zero)
        {
            playerBody.position += moveInput;
        }
    }

    void VerticalMovement() {
        Vector2 moveInput = Vector2.zero;

        if (isJumped)
        {
            velocity.y = Mathf.MoveTowards(velocity.y, MAX_HEIGHT, JUMP_SPEED);
            Debug.Log("velocity.y: " + velocity.y);
        }

        if (currentHeight >= MAX_HEIGHT)
        {
            StopVerticalMovement();
        }

        moveInput.y = GRAVITY_SPEED + velocity.y;
        //TODO
        currentHeight = currentHeight + moveInput.y;
        Debug.Log("currentHeight: " + currentHeight);

        if (CheckForCollision(moveInput))
        {
            playerBody.position += moveInput;
        }
        else {
            StopVerticalMovement();
        }
    }

    void StopVerticalMovement() {
        isJumped = false;
        currentHeight = 0;
        velocity.y = 0;
    }
}