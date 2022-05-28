using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrabMovementCB : MonoBehaviour
{

    [SerializeField] private Animator crabAnimator;
    [SerializeField] private Rigidbody2D crab;

    private int moveDirection;
    public float moveSpeed;
    public bool isWalking;

    public float walkTime;
    public float waitTime;
    private float walkCounter;
    private float waitCounter;
    

    // Start is called before the first frame update
    void Start()
    {
        waitCounter = waitTime;
        walkCounter = walkTime;

         ChooseDirection(); 
    }

    // Update is called once per frame
    void Update()
    {
        if ( isWalking ) {
            crabAnimator.SetBool("isWalking", true);

            walkCounter -= Time.deltaTime;

            switch( moveDirection ) {
                case 0:
                    crab.velocity = new Vector2(0, moveSpeed);
                    break;

                case 1:
                    crab.velocity = new Vector2(moveSpeed, 0);
                    break;

                case 2:
                    crab.velocity = new Vector2(0, -moveSpeed);
                    break;

                case 3:
                    crab.velocity = new Vector2(-moveSpeed, 0);
                    break;
            }

            if ( walkCounter < 0 ) {
                isWalking = false;
                waitCounter = waitTime;
            }
        } else {
            crabAnimator.SetBool("isWalking", false);

            waitCounter -= Time.deltaTime;

            crab.velocity = Vector2.zero;            

            if ( waitCounter < 0 ) {
                ChooseDirection();
            }
        }
    }

    public void ChooseDirection() {
        moveDirection = Random.Range(0, 4); // 0 - up, 1 - right, 2 - down, 3 - left

        isWalking = true;
        walkCounter = walkTime;
    }
}
