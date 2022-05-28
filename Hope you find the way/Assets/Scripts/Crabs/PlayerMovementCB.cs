using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementCB : MonoBehaviour
{


    [SerializeField] private Rigidbody2D body;

    Vector2 movement;

    private float speed = 10f;
    
    void Update() {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate() {
        body.MovePosition(body.position + movement * speed * Time.fixedDeltaTime );
    }
}
