using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashierWalkCM : MonoBehaviour
{
   
    [SerializeField] private Rigidbody2D cashier;
    
    private int moveDirection;
    [SerializeField] private float moveSpeed;
    [SerializeField] private bool isWalking;
    [SerializeField] private float walkTime;
    [SerializeField] private float waitTime;
    private float walkCounter;
    private float waitCounter;

    void Start() {
        waitCounter = waitTime;
        walkCounter = walkTime;

        ChooseDirection();
    }

    void Update() {
        if ( isWalking ){
            walkCounter -= Time.deltaTime;

            switch ( moveDirection ){
                case 0:
                    cashier.MovePosition( cashier.position + new Vector2( -1, 0 ) * moveSpeed * Time.deltaTime );
                    break;
                
                case 1:
                    cashier.MovePosition( cashier.position + new Vector2( 1, 0 ) * moveSpeed * Time.deltaTime );
                    break;
            }

            if ( walkCounter < 0 ){
                isWalking = false;
                waitCounter = waitTime;
            }
        } else {
            // isWalking = false;
            waitCounter -= Time.deltaTime;
            cashier.velocity = Vector2.zero;

            if ( waitCounter < 0 )
                ChooseDirection();        
        }
    }

    void ChooseDirection() {
        moveDirection = Random.Range( 0, 2 );
        isWalking = true;
        walkCounter = walkTime;
    }
}
