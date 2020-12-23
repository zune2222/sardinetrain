using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moving : MonoBehaviour
{
    public float movePower = 1f;
    bool eating = false;

    Rigidbody2D rigid;
    Animator animator;

    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetAxisRaw("Horizontal") < 0)
        {
            animator.SetInteger ("direction",1);
        }
        else if (Input.GetAxisRaw("Horizontal") > 0)
        {
            animator.SetInteger("direction", 0);
        }
        else if (Input.GetAxisRaw("Vertical") < 0)
        {
            animator.SetInteger("direction", 3);
        }
        else if (Input.GetAxisRaw("Vertical") > 0)
        {
            animator.SetInteger("direction", 2);
        }
        if (Input.GetButtonDown ("Jump"))
        {
            eating = true;
        }
    }
    private void FixedUpdate()
    {
        Move();
        Eat();
    }
    void Move()
    {
        Vector3 moveVelocity = Vector3.zero;

        if (Input.GetAxisRaw ("Horizontal") < 0)
        {
            moveVelocity = Vector3.left;
        }
        else if(Input.GetAxisRaw ("Horizontal") > 0)
        {
            moveVelocity = Vector3.right;
        }
        else if(Input.GetAxisRaw ("Vertical") < 0)
        {
            moveVelocity = Vector3.down;
        }
        else if(Input.GetAxisRaw ("Vertical") > 0)
        {
            moveVelocity = Vector3.up;
        }

        transform.position += moveVelocity * movePower * Time.deltaTime;
    }
    void Eat()
    {
        if (!eating)
        {
            animator.SetBool("eating", false);
        }
        else
        {
            animator.SetBool("eating", true);
            eating = false;
        }
    }
}
