using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float moveSpeed;
    private Rigidbody2D rb;
    public Vector2 moveDirection;

    public int hp;
    private bool timeIsPassed;


    private void Start()
    {
        timeIsPassed = true;
        rb = GetComponent<Rigidbody2D>();
        moveSpeed = 5;
        hp = 100;

    }

    void Update()
    {
        
        ProcessInputs();
        if (hp <= 0)
        {
            canMove = false;
            StopMovement();
        }
        else if (canMove)
            Move();
        else
            StopMovement();
        
    }
    void ProcessInputs(){
        float moveX = Input.GetAxisRaw("Horizontal");
        float moveY = Input.GetAxisRaw("Vertical");
        moveDirection = new Vector2(moveX, moveY).normalized;
    }

    void Move(){
        rb.velocity = new Vector2(moveDirection.x * moveSpeed, moveDirection.y * moveSpeed);
    }

    void StopMovement()
    {
        rb.velocity = new Vector2(0, 0);
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Exorcist" && timeIsPassed)
        {
            hp -= 5;
            timeIsPassed = false;
            StartCoroutine(Waiting());
        }
        
    }


    IEnumerator Waiting()
    {
        yield return new WaitForSeconds(1.5f);
        timeIsPassed = true;
    }

}
