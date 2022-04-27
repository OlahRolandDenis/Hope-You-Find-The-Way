 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{


    [SerializeField] private Rigidbody2D body;
    [SerializeField] private float moveSpeed;

    private Vector2 moveDirection;

    void Update() {
        ProcessInputs();
    }

    void FixedUpdate() {
        Move();
    }

    void ProcessInputs() {
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");

        moveDirection = new Vector2( moveX, moveY ).normalized;
    }

    void Move() {
        body.velocity = new Vector2( moveDirection.x * moveSpeed, moveDirection.y * moveSpeed );
    }
}
