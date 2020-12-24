using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_moving : MonoBehaviour
{
    public float speed = 1f;
    bool eating = false;
    private Joystick joystick;

    Rigidbody2D rigid;
    Animator animator;

    Vector3 movement;
    // Start is called before the first frame update
    void Start()
    {
        joystick = GameObject.FindObjectOfType<Joystick>();
        rigid = gameObject.GetComponent<Rigidbody2D>();
        animator = gameObject.GetComponentInChildren<Animator>();
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown ("Jump"))
        {
            eating = true;
        }
    }
    private void FixedUpdate()
    {
        if (joystick.Horizontal != 0 || joystick.Vertical != 0)
        {
            Move();
        }
        Eat();
    }
    void Move()
    {
        Vector3 upMovement = Vector3.up * speed * Time.deltaTime * joystick.Vertical;
        Vector3 rightMovement = Vector3.right * speed * Time.deltaTime * joystick.Horizontal;
        transform.position += upMovement;
        transform.position += rightMovement;
        Quaternion quaternion = Quaternion.identity;
        quaternion.eulerAngles = joystick.angle;
        transform.rotation = quaternion;
    }
    void Eat()
    {
        if (!eating)
        {
            //animator.SetBool("eating", false);
        }
        else
        {
            //animator.SetBool("eating", true);
            eating = false;
        }
    }
}
